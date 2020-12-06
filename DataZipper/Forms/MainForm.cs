using DataZipper.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DataZipper
{
	public partial class MainForm : Form
	{
		private string m_AppDataPath;
		private string m_TemporaryPath;
		private string m_LogPath;
		private string m_ConfigurationsPath;

		private string m_SelectedConfigName;

		private List<Configuration> m_Configurations;
		private List<Zipper> m_Zippers = new List<Zipper>();

		private Logger m_Logger;

		private readonly object m_Lock = new object();

		public MainForm()
		{
			InitializeComponent();
		}

		#region Form events
		private void MainForm_Shown(object sender, EventArgs e)
		{
			PrepareAppDataPaths();
			LoadConfigurations();

			InitializeLogger();
			InitializeDataZipper();

			InitializeTemporaryPaths(m_Configurations);
			InitializeConfigurations(m_Configurations);
			CleanupTemporaryPaths();

			UpdateConfigListBox();
		}

		private void buttonNewConfig_Click(object sender, EventArgs e)
		{
			ConfigurationForm configurationForm = new ConfigurationForm(new Configuration());
			configurationForm.Text = configurationForm.Text.Replace("%ACTION%", "New");

			if (configurationForm.ShowDialog() == DialogResult.OK)
			{
				Configuration newConfiguration = configurationForm.Configuration;
				m_Logger.Log("Configuration created", newConfiguration.Name);

				m_Configurations.Add(newConfiguration);
				SaveConfigurations(m_Configurations);

				List<Configuration> newConfigurations = new List<Configuration>() { newConfiguration };
				InitializeTemporaryPaths(newConfigurations);
				InitializeConfigurations(newConfigurations);

				UpdateConfigListBox();

				m_SelectedConfigName = null;
			}
		}

		private void buttonEditConfig_Click(object sender, EventArgs e)
		{
			if (m_SelectedConfigName == null)
			{
				MessageBox.Show("Select configuration to edit");
				return;
			}

			Configuration configurationEdit = m_Configurations.Where(x => x.Name == m_SelectedConfigName).First();
			Zipper zipperEdit = m_Zippers.Where(x => x.Configuration == configurationEdit).First();
			zipperEdit.Stop();

			ConfigurationForm configurationForm = new ConfigurationForm(configurationEdit);
			configurationForm.Text = configurationForm.Text.Replace("%ACTION%", "Edit");

			if (configurationForm.ShowDialog() == DialogResult.OK)
			{
				configurationEdit = configurationForm.Configuration;
				m_Logger.Log("Configuration edited", configurationEdit.Name);

				InitializeTemporaryPaths(new List<Configuration>() { configurationEdit });

				SaveConfigurations(m_Configurations);

				UpdateConfigListBox();

				m_SelectedConfigName = null;

				zipperEdit.Start();
			}
		}

		private void buttonTrashConfig_Click(object sender, EventArgs e)
		{
			if (m_SelectedConfigName == null)
			{
				MessageBox.Show("Select configuration to delete");
				return;
			}

			if (MessageBox.Show($"This will delete configuration: {m_SelectedConfigName}", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Configuration configurationDelete = m_Configurations.Where(x => x.Name == m_SelectedConfigName).First();
				Zipper zipperDelete = m_Zippers.Where(x => x.Configuration == configurationDelete).First();

				zipperDelete.Stop();

				m_Zippers = m_Zippers.Where(x => x.Configuration != configurationDelete).ToList();
				m_Configurations = m_Configurations.Where(x => x != configurationDelete).ToList();

				SaveConfigurations(m_Configurations);
				UpdateConfigListBox();
				m_SelectedConfigName = null;

				m_Logger.Log("Configuration deleted", configurationDelete.Name);
			}
		}

		private void notifyIcon_Click(object sender, EventArgs e)
		{
			Show();
			this.WindowState = FormWindowState.Normal;
			notifyIcon.Visible = false;

			timerLogRefresher.Start();
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				Hide();
				notifyIcon.Visible = true;

				timerLogRefresher.Stop();
			}
		}

		private void buttonRestartZipper_Click(object sender, EventArgs e)
		{
			m_Logger.Log("### Data Zipper successfully restarted ###");

			foreach (Zipper zipper in m_Zippers)
			{
				zipper.Restart();
			}
		}

		private void timerLogRefresher_Tick(object sender, EventArgs e)
		{
			lock (m_Lock)
			{
				string currentLogPath = m_LogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

				if (!File.Exists(currentLogPath))
				{
					var newLog = File.Create(currentLogPath);
					newLog.Close();
				}

				using (StreamReader sr = new StreamReader(currentLogPath))
				{
					List<string> lines = new List<string>();

					while (!sr.EndOfStream)
					{
						lines.Add(sr.ReadLine());
					}

					int count = lines.Count;
					int visibleItems = listBoxLog.ClientSize.Height / listBoxLog.ItemHeight;

					if (count > visibleItems)
					{
						lines.RemoveRange(0, count - visibleItems);
					}

					listBoxLog.Items.Clear();
					listBoxLog.Items.AddRange(lines.ToArray());
				}
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_Logger.Log("### Data Zipper stoppped ###");
		}

		private void listBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			if (listBoxConfigs.SelectedIndex == -1)
			{
				return;
			}

			m_SelectedConfigName = listBoxConfigs.Items[listBoxConfigs.SelectedIndex].ToString();
		}

		#endregion

		private void InitializeDataZipper()
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				Hide();
				notifyIcon.Visible = true;
			}
			else
			{
				timerLogRefresher.Interval = 1000;
				timerLogRefresher.Start();
			}
		}

		private void InitializeLogger()
		{
			m_Logger = new Logger(m_LogPath, m_Lock);
		}

		private void PrepareAppDataPaths()
		{
			m_AppDataPath = Environment.ExpandEnvironmentVariables($@"%AppData%\Data Zipper\");
			m_TemporaryPath = Environment.ExpandEnvironmentVariables($@"%AppData%\Data Zipper\Temp\");
			m_LogPath = Environment.ExpandEnvironmentVariables($@"%AppData%\Data Zipper\Log\");
			m_ConfigurationsPath = m_AppDataPath + "configuration.json";

			foreach (var path in new string[] { m_AppDataPath, m_TemporaryPath, m_LogPath })
			{
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
			}
		}

		private void LoadConfigurations()
		{
			if (File.Exists(m_ConfigurationsPath))
			{
				using (StreamReader streamReader = new StreamReader(m_ConfigurationsPath))
				{
					m_Configurations = JsonConvert.DeserializeObject<List<Configuration>>(streamReader.ReadToEnd());
				}
			}
			else
			{
				m_Configurations = new List<Configuration>();
				var newJson = File.Create(m_ConfigurationsPath);
				newJson.Close();
				File.WriteAllText(m_ConfigurationsPath, "[\n]");
			}
		}

		private void InitializeConfigurations(List<Configuration> configurations)
		{
			foreach (Configuration configuration in configurations)
			{
				Zipper zipper = new Zipper(configuration, m_Logger);
				m_Zippers.Add(zipper);
			}
		}

		private void InitializeTemporaryPaths(List<Configuration> configurations)
		{
			foreach (Configuration configuration in configurations)
			{
				string configurationTemporaryPathName = ReplaceInvalidChars(configuration.Name);
				string configurationTemporaryPath = m_TemporaryPath + configurationTemporaryPathName;

				if (!Directory.Exists(m_TemporaryPath + configurationTemporaryPath))
				{
					Directory.CreateDirectory(configurationTemporaryPath);
				}

				configuration.TemporaryPath = configurationTemporaryPath + "\\";
			}
		}

		private void CleanupTemporaryPaths()
		{
			foreach (var directory in new DirectoryInfo(m_TemporaryPath).GetDirectories())
			{
				int matchingDirectories = m_Configurations.Where(x => x.Name == directory.Name).Count();

				if (matchingDirectories == 0)
				{
					Directory.Delete(directory.FullName, true);
				}
			}
		}

		private string ReplaceInvalidChars(string filename)
		{
			return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
		}

		private void UpdateConfigListBox()
		{
			listBoxConfigs.Items.Clear();

			foreach (Configuration configuration in m_Configurations)
			{
				listBoxConfigs.Items.Add(configuration.Name);
			}
		}

		private void SaveConfigurations(List<Configuration> configurations)
		{
			string json = JsonConvert.SerializeObject(configurations, Newtonsoft.Json.Formatting.Indented);

			File.WriteAllText(m_ConfigurationsPath, json);
		}
	}
}
