namespace GUI {
	partial class PlaybackControl {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.textBoxAudioFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonPlay = new System.Windows.Forms.Button();
			this.comboBoxDeviceToPlay = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.visualConsole = new System.Windows.Forms.RichTextBox();
			this.buttonNotificationsFormLaunch = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.buttonStop);
			this.groupBox1.Controls.Add(this.textBoxAudioFile);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.buttonPlay);
			this.groupBox1.Controls.Add(this.comboBoxDeviceToPlay);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox1.Size = new System.Drawing.Size(359, 131);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Playback settings";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(317, 55);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(30, 26);
			this.button3.TabIndex = 6;
			this.button3.Text = "...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(182, 87);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(165, 33);
			this.buttonStop.TabIndex = 5;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// textBoxAudioFile
			// 
			this.textBoxAudioFile.Location = new System.Drawing.Point(88, 55);
			this.textBoxAudioFile.Name = "textBoxAudioFile";
			this.textBoxAudioFile.Size = new System.Drawing.Size(223, 26);
			this.textBoxAudioFile.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Audio file";
			// 
			// buttonPlay
			// 
			this.buttonPlay.Location = new System.Drawing.Point(12, 87);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(165, 33);
			this.buttonPlay.TabIndex = 2;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
			// 
			// comboBoxDeviceToPlay
			// 
			this.comboBoxDeviceToPlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDeviceToPlay.FormattingEnabled = true;
			this.comboBoxDeviceToPlay.Location = new System.Drawing.Point(88, 21);
			this.comboBoxDeviceToPlay.Name = "comboBoxDeviceToPlay";
			this.comboBoxDeviceToPlay.Size = new System.Drawing.Size(259, 28);
			this.comboBoxDeviceToPlay.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Device";
			// 
			// visualConsole
			// 
			this.visualConsole.Dock = System.Windows.Forms.DockStyle.Top;
			this.visualConsole.Location = new System.Drawing.Point(0, 131);
			this.visualConsole.Name = "visualConsole";
			this.visualConsole.Size = new System.Drawing.Size(359, 441);
			this.visualConsole.TabIndex = 1;
			this.visualConsole.Text = "";
			// 
			// buttonNotificationsFormLaunch
			// 
			this.buttonNotificationsFormLaunch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonNotificationsFormLaunch.Location = new System.Drawing.Point(0, 572);
			this.buttonNotificationsFormLaunch.Name = "buttonNotificationsFormLaunch";
			this.buttonNotificationsFormLaunch.Size = new System.Drawing.Size(359, 39);
			this.buttonNotificationsFormLaunch.TabIndex = 7;
			this.buttonNotificationsFormLaunch.Text = "Notifications panel";
			this.buttonNotificationsFormLaunch.UseVisualStyleBackColor = true;
			this.buttonNotificationsFormLaunch.Click += new System.EventHandler(this.buttonNotificationsFormLaunch_Click);
			// 
			// PlaybackControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 611);
			this.Controls.Add(this.buttonNotificationsFormLaunch);
			this.Controls.Add(this.visualConsole);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(5);
			this.MaximizeBox = false;
			this.Name = "PlaybackControl";
			this.Text = "Remote phone playback control";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBoxDeviceToPlay;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.TextBox textBoxAudioFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.RichTextBox visualConsole;
		private System.Windows.Forms.Button buttonNotificationsFormLaunch;
	}
}

