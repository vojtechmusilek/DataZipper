using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataZipper.Forms
{
	public partial class ConfigurationForm : Form
	{
		public Configuration Configuration;

		public ConfigurationForm(Configuration configuration)
		{
			InitializeComponent();

			Configuration = configuration;
		}



		private void ConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//this.DialogResult = DialogResult.Cancel;
		}

		private void buttonSaveConfig_Click(object sender, EventArgs e)
		{
			Configuration.Name = textBoxName.Text;
			Configuration.Interval = (int)numericUpDownInterval.Value;
			Configuration.Enabled = checkBoxEnabled.Checked;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonSources_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = @"C:\";
				openFileDialog.Multiselect = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					Configuration.SourcePaths.Clear();

					foreach (var item in openFileDialog.FileNames)
					{
						Configuration.SourcePaths.Add(item);
					}
				}
			}
		}

		private void buttonDestination_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				DialogResult result = folderBrowserDialog.ShowDialog();
				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					Configuration.DestinationPath = folderBrowserDialog.SelectedPath;
				}
			}
		}
	}
}
