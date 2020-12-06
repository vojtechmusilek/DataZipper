namespace DataZipper
{
    partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.timerLogRefresher = new System.Windows.Forms.Timer(this.components);
			this.buttonRestartZipper = new System.Windows.Forms.Button();
			this.listBoxLog = new System.Windows.Forms.ListBox();
			this.listBoxConfigs = new System.Windows.Forms.ListBox();
			this.buttonNewConfig = new System.Windows.Forms.Button();
			this.buttonEditConfig = new System.Windows.Forms.Button();
			this.buttonTrashConfig = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Data Zipper";
			this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Configurations";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(226, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 15);
			this.label4.TabIndex = 9;
			this.label4.Text = "Log";
			// 
			// timerLogRefresher
			// 
			this.timerLogRefresher.Enabled = true;
			this.timerLogRefresher.Interval = 1000;
			this.timerLogRefresher.Tick += new System.EventHandler(this.timerLogRefresher_Tick);
			// 
			// buttonRestartZipper
			// 
			this.buttonRestartZipper.Location = new System.Drawing.Point(229, 37);
			this.buttonRestartZipper.Name = "buttonRestartZipper";
			this.buttonRestartZipper.Size = new System.Drawing.Size(137, 23);
			this.buttonRestartZipper.TabIndex = 14;
			this.buttonRestartZipper.Text = "Restart data zipper";
			this.buttonRestartZipper.UseVisualStyleBackColor = true;
			this.buttonRestartZipper.Click += new System.EventHandler(this.buttonRestartZipper_Click);
			// 
			// listBoxLog
			// 
			this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listBoxLog.FormattingEnabled = true;
			this.listBoxLog.Location = new System.Drawing.Point(229, 66);
			this.listBoxLog.Name = "listBoxLog";
			this.listBoxLog.Size = new System.Drawing.Size(406, 199);
			this.listBoxLog.TabIndex = 15;
			// 
			// listBoxConfigs
			// 
			this.listBoxConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxConfigs.FormattingEnabled = true;
			this.listBoxConfigs.Location = new System.Drawing.Point(12, 66);
			this.listBoxConfigs.Name = "listBoxConfigs";
			this.listBoxConfigs.Size = new System.Drawing.Size(192, 199);
			this.listBoxConfigs.TabIndex = 16;
			this.listBoxConfigs.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
			// 
			// buttonNewConfig
			// 
			this.buttonNewConfig.Location = new System.Drawing.Point(12, 37);
			this.buttonNewConfig.Name = "buttonNewConfig";
			this.buttonNewConfig.Size = new System.Drawing.Size(60, 23);
			this.buttonNewConfig.TabIndex = 17;
			this.buttonNewConfig.Text = "New";
			this.buttonNewConfig.UseVisualStyleBackColor = true;
			this.buttonNewConfig.Click += new System.EventHandler(this.buttonNewConfig_Click);
			// 
			// buttonEditConfig
			// 
			this.buttonEditConfig.Location = new System.Drawing.Point(78, 37);
			this.buttonEditConfig.Name = "buttonEditConfig";
			this.buttonEditConfig.Size = new System.Drawing.Size(60, 23);
			this.buttonEditConfig.TabIndex = 18;
			this.buttonEditConfig.Text = "Edit";
			this.buttonEditConfig.UseVisualStyleBackColor = true;
			this.buttonEditConfig.Click += new System.EventHandler(this.buttonEditConfig_Click);
			// 
			// buttonTrashConfig
			// 
			this.buttonTrashConfig.Location = new System.Drawing.Point(144, 37);
			this.buttonTrashConfig.Name = "buttonTrashConfig";
			this.buttonTrashConfig.Size = new System.Drawing.Size(60, 23);
			this.buttonTrashConfig.TabIndex = 19;
			this.buttonTrashConfig.Text = "Trash";
			this.buttonTrashConfig.UseVisualStyleBackColor = true;
			this.buttonTrashConfig.Click += new System.EventHandler(this.buttonTrashConfig_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(647, 277);
			this.Controls.Add(this.buttonTrashConfig);
			this.Controls.Add(this.buttonEditConfig);
			this.Controls.Add(this.buttonNewConfig);
			this.Controls.Add(this.listBoxConfigs);
			this.Controls.Add(this.listBoxLog);
			this.Controls.Add(this.buttonRestartZipper);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(663, 316);
			this.Name = "MainForm";
			this.Text = "Data Zipper";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerLogRefresher;
        private System.Windows.Forms.Button buttonRestartZipper;
        private System.Windows.Forms.ListBox listBoxLog;
		private System.Windows.Forms.ListBox listBoxConfigs;
		private System.Windows.Forms.Button buttonNewConfig;
		private System.Windows.Forms.Button buttonEditConfig;
		private System.Windows.Forms.Button buttonTrashConfig;
	}
}

