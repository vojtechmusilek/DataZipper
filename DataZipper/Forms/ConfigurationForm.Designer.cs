namespace DataZipper.Forms
{
	partial class ConfigurationForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.buttonSaveConfig = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
			this.buttonDestination = new System.Windows.Forms.Button();
			this.buttonSources = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
			this.buttonSourceFolder = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "Configuration name:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(119, 6);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(163, 20);
			this.textBoxName.TabIndex = 18;
			// 
			// buttonSaveConfig
			// 
			this.buttonSaveConfig.Location = new System.Drawing.Point(15, 202);
			this.buttonSaveConfig.Name = "buttonSaveConfig";
			this.buttonSaveConfig.Size = new System.Drawing.Size(270, 30);
			this.buttonSaveConfig.TabIndex = 17;
			this.buttonSaveConfig.Text = "Save configuration";
			this.buttonSaveConfig.UseVisualStyleBackColor = true;
			this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(239, 142);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "minutes";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 142);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Interval:";
			// 
			// numericUpDownInterval
			// 
			this.numericUpDownInterval.Location = new System.Drawing.Point(119, 140);
			this.numericUpDownInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numericUpDownInterval.Name = "numericUpDownInterval";
			this.numericUpDownInterval.Size = new System.Drawing.Size(114, 20);
			this.numericUpDownInterval.TabIndex = 14;
			// 
			// buttonDestination
			// 
			this.buttonDestination.Location = new System.Drawing.Point(119, 104);
			this.buttonDestination.Name = "buttonDestination";
			this.buttonDestination.Size = new System.Drawing.Size(163, 30);
			this.buttonDestination.TabIndex = 13;
			this.buttonDestination.Text = "Select zip destination";
			this.buttonDestination.UseVisualStyleBackColor = true;
			this.buttonDestination.Click += new System.EventHandler(this.buttonDestination_Click);
			// 
			// buttonSources
			// 
			this.buttonSources.Location = new System.Drawing.Point(119, 32);
			this.buttonSources.Name = "buttonSources";
			this.buttonSources.Size = new System.Drawing.Size(163, 30);
			this.buttonSources.TabIndex = 12;
			this.buttonSources.Text = "Select source file/s";
			this.buttonSources.UseVisualStyleBackColor = true;
			this.buttonSources.Click += new System.EventHandler(this.buttonSources_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Source files:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Zip destination:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 166);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 13);
			this.label6.TabIndex = 22;
			this.label6.Text = "Enabled:";
			// 
			// checkBoxEnabled
			// 
			this.checkBoxEnabled.AutoSize = true;
			this.checkBoxEnabled.Checked = true;
			this.checkBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxEnabled.Location = new System.Drawing.Point(119, 166);
			this.checkBoxEnabled.Name = "checkBoxEnabled";
			this.checkBoxEnabled.Size = new System.Drawing.Size(15, 14);
			this.checkBoxEnabled.TabIndex = 23;
			this.checkBoxEnabled.UseVisualStyleBackColor = true;
			// 
			// buttonSourceFolder
			// 
			this.buttonSourceFolder.Location = new System.Drawing.Point(119, 68);
			this.buttonSourceFolder.Name = "buttonSourceFolder";
			this.buttonSourceFolder.Size = new System.Drawing.Size(163, 30);
			this.buttonSourceFolder.TabIndex = 24;
			this.buttonSourceFolder.Text = "Select source folder";
			this.buttonSourceFolder.UseVisualStyleBackColor = true;
			this.buttonSourceFolder.Click += new System.EventHandler(this.buttonSourceFolders_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 77);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 13);
			this.label7.TabIndex = 25;
			this.label7.Text = "Source folders:";
			// 
			// ConfigurationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 246);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.buttonSourceFolder);
			this.Controls.Add(this.checkBoxEnabled);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.buttonSaveConfig);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDownInterval);
			this.Controls.Add(this.buttonDestination);
			this.Controls.Add(this.buttonSources);
			this.Name = "ConfigurationForm";
			this.Text = "%ACTION% Configuration";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Button buttonSaveConfig;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDownInterval;
		private System.Windows.Forms.Button buttonDestination;
		private System.Windows.Forms.Button buttonSources;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBoxEnabled;
		private System.Windows.Forms.Button buttonSourceFolder;
		private System.Windows.Forms.Label label7;
	}
}