using DataZipper.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DataZipper
{
	public partial class MainForm : Form
	{
		private string m_AppDataPath;
		private string m_TemporaryPath;
		private string m_LogPath;
		private string m_ConfigurationsPath;

		private List<Configuration> m_Configurations;
		private List<Zipper> m_Zippers = new List<Zipper>();

		private Logger m_Logger;

		//private Configuration config { get; set; }
		//private Logger logger { get; set; }
		//private string configPath { get; set; }
		//private string logPath { get; set; }
		//private string tmpPath { get; set; }

		public MainForm()
		{
			InitializeComponent();

			PrepareAppDataPaths();
			LoadConfigurations();

			InitializeLogger();
			
			InitializeTemporaryPaths(m_Configurations);
			InitializeConfigurations(m_Configurations);


			UpdateConfigListBox();
		}

		private void InitializeLogger()
		{
			m_Logger = new Logger(m_LogPath);
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

		private string ReplaceInvalidChars(string filename)
		{
			return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
		}

		private void UpdateConfigListBox()
		{
			foreach (Configuration configuration in m_Configurations)
			{
				listBoxConfigs.Items.Add(configuration.Name);
			}
		}

		private void InitializeNewConfiguration(Configuration newConfiguration)
		{
			List<Configuration> newConfigurations = new List<Configuration>() { newConfiguration };

			InitializeTemporaryPaths(newConfigurations);
			InitializeConfigurations(newConfigurations);
			
		}


		// OLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLDOLD




		// === Initialization ===
		//private void InitializeDataZipperold()
		//{
		//	string applicationDataFolder = Environment.ExpandEnvironmentVariables($@"%AppData%\Data Zipper\");

		//	logPath = applicationDataFolder + DateTime.Now.ToString("yyyyMMdd") + ".log";
		//	configPath = applicationDataFolder + "configuration.xml";
		//	tmpPath = applicationDataFolder + "tmp";

		//	logger = new Logger(logPath);

		//	if (File.Exists(configPath))
		//	{
		//		config = LoadConfig(configPath);

		//		timerMain.Interval = config.Interval * 60 * 1000;
		//		timerMain.Start();
		//		DataZip();
		//	}
		//	else
		//	{
		//		config = new Configuration();
		//	}

		//	if (this.WindowState == FormWindowState.Minimized)
		//	{
		//		Hide();
		//		notifyIcon.Visible = true;
		//	}
		//	else
		//	{
		//		timerLogRefresher.Interval = 1000;
		//		timerLogRefresher.Start();
		//	}
		//}

		private void SaveConfigurations(List<Configuration> configurations)
		{
			string json = JsonConvert.SerializeObject(configurations, Newtonsoft.Json.Formatting.Indented);

			File.WriteAllText(m_ConfigurationsPath, json);

			
		}


		private void buttonNewConfig_Click(object sender, EventArgs e)
		{
			ConfigurationForm configurationForm = new ConfigurationForm(new Configuration());
			configurationForm.Text = configurationForm.Text.Replace("%ACTION%", "New");

			if (configurationForm.ShowDialog() == DialogResult.OK)
			{
				Configuration newConfiguration = configurationForm.Configuration;

				m_Configurations.Add(newConfiguration);
				SaveConfigurations(m_Configurations);
				InitializeNewConfiguration(newConfiguration);
			}

		}

		private void buttonEditConfig_Click(object sender, EventArgs e)
		{

		}

		private void buttonTrashConfig_Click(object sender, EventArgs e)
		{

		}


















		//// === Config operations ===
		//public Configuration LoadConfig(string FileName)
		//{
		//	using (var stream = System.IO.File.OpenRead(FileName))
		//	{
		//		var serializer = new XmlSerializer(typeof(Configuration));
		//		return serializer.Deserialize(stream) as Configuration;
		//	}
		//}

		//public void SaveConfig(string FileName, Configuration toSerialize)
		//{
		//	using (StreamWriter writer = new StreamWriter(FileName))
		//	{
		//		var serializer = new XmlSerializer(toSerialize.GetType());
		//		serializer.Serialize(writer, toSerialize);
		//	}
		//}


		//// === Form hiding as notify icon ===
		private void notifyIcon_Click(object sender, EventArgs e)
		{
			Show();
			this.WindowState = FormWindowState.Normal;
			notifyIcon.Visible = false;

			timerLogRefresher.Start();
		}

		//private void FormMain_Resize(object sender, EventArgs e)
		//{
		//	if (this.WindowState == FormWindowState.Minimized)
		//	{
		//		Hide();
		//		notifyIcon.Visible = true;

		//		timerLogRefresher.Stop();
		//	}
		//}


		//// === Form actions ===
		//private void buttonSources_Click(object sender, EventArgs e)
		//{
		//	using (OpenFileDialog openFileDialog = new OpenFileDialog())
		//	{
		//		openFileDialog.InitialDirectory = @"C:\";
		//		openFileDialog.Multiselect = true;

		//		if (openFileDialog.ShowDialog() == DialogResult.OK)
		//		{
		//			config.Sources.Clear();

		//			foreach (var item in openFileDialog.FileNames)
		//			{
		//				config.Sources.Add(item);
		//			}
		//		}
		//	}
		//}

		//private void buttonDestination_Click(object sender, EventArgs e)
		//{
		//	using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
		//	{
		//		DialogResult result = folderBrowserDialog.ShowDialog();
		//		if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
		//		{
		//			config.Destination = folderBrowserDialog.SelectedPath;
		//		}
		//	}
		//}

		//private void numericUpDownInterval_ValueChanged(object sender, EventArgs e)
		//{
		//	//config.Interval = (int)numericUpDownInterval.Value;
		//}

		//private void textBoxName_TextChanged(object sender, EventArgs e)
		//{
		//	//config.Name = textBoxName.Text;
		//}

		//private void buttonSaveConfig_Click(object sender, EventArgs e)
		//{
		//	SaveConfig(configPath, config);

		//	MessageBox.Show("Successfully saved.");
		//}

		//private void buttonRestartZipper_Click(object sender, EventArgs e)
		//{
		//	if (File.Exists(configPath))
		//	{
		//		config = LoadConfig(configPath);

		//		if (timerMain.Enabled)
		//		{
		//			timerMain.Stop();
		//		}

		//		timerMain.Interval = config.Interval * 60 * 1000;
		//		timerMain.Start();

		//		logger.Log("Data Zipper restarted.");
		//		DataZip();
		//	}
		//	else
		//	{
		//		logger.Log("Data Zipper restarted.");
		//	}
		//}


		//// === Data zipping ===
		//private void DataZip()
		//{
		//	Stopwatch zippingTime = new Stopwatch();
		//	zippingTime.Start();

		//	if (Directory.Exists(tmpPath))
		//	{
		//		foreach (var item in Directory.GetFiles(tmpPath))
		//		{
		//			File.Delete(item);
		//		}

		//		Directory.Delete(tmpPath);
		//	}
		//	Directory.CreateDirectory(tmpPath);

		//	try
		//	{
		//		foreach (var item in config.Sources)
		//		{
		//			File.Copy(item, tmpPath + @"\" + item.Substring(item.LastIndexOf('\\')));
		//		}

		//		string fullDestination = config.Destination + @"\" + config.Name + ".zip";
		//		string temporaryDestination = tmpPath + config.Name + ".zip";

		//		ZipFile.CreateFromDirectory(tmpPath, temporaryDestination);


		//		File.Copy(temporaryDestination, fullDestination, true);

		//		File.Delete(temporaryDestination);

		//		logger.Log($"Zipping finished successfully in {zippingTime.ElapsedMilliseconds} ms.");
		//	}
		//	catch (Exception ex)
		//	{
		//		logger.Log($"Zipping failed after {zippingTime.ElapsedMilliseconds} ms.");
		//		logger.Log($"Error message: {ex.Message}");
		//	}
		//}


		//// === Timers ===
		//private void timerMain_Tick(object sender, EventArgs e)
		//{
		//	DataZip();
		//}

		private void timerLogRefresher_Tick(object sender, EventArgs e)
		{
			using (StreamReader sr = new StreamReader(m_LogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log"))
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


		//// === Other ===
		//private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		//{
		//	logger.Log("Data Zipper stoppped.");
		//}

		private void listBox1_TabIndexChanged(object sender, EventArgs e)
		{
			var x = listBoxConfigs.Items[listBoxConfigs.TabIndex];

			;

		}

		private void listBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			var x = listBoxConfigs.Items[listBoxConfigs.SelectedIndex];

			;
		}

		
	}
}
