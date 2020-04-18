namespace GUI {
	partial class NotificationsPanel {
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
			this.components = new System.ComponentModel.Container();
			this.comboBoxFormattingStyle = new System.Windows.Forms.ComboBox();
			this.comboBoxSender = new System.Windows.Forms.ComboBox();
			this.datePickerFromDate = new System.Windows.Forms.DateTimePicker();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.groupBoxFilters = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.timerNotifications_SimCorp = new System.Windows.Forms.Timer(this.components);
			this.listViewNorifications = new System.Windows.Forms.ListView();
			this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Received = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.timerNotifications_Microsoft = new System.Windows.Forms.Timer(this.components);
			this.timerNotifications_System = new System.Windows.Forms.Timer(this.components);
			this.groupBoxFilters.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBoxFormattingStyle
			// 
			this.comboBoxFormattingStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFormattingStyle.FormattingEnabled = true;
			this.comboBoxFormattingStyle.Items.AddRange(new object[] {
            "Clear formatting",
            "Date at the beginning",
            "Date at the end",
            "All in uppercase",
            "All in lowercase"});
			this.comboBoxFormattingStyle.Location = new System.Drawing.Point(13, 32);
			this.comboBoxFormattingStyle.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxFormattingStyle.Name = "comboBoxFormattingStyle";
			this.comboBoxFormattingStyle.Size = new System.Drawing.Size(245, 27);
			this.comboBoxFormattingStyle.TabIndex = 1;
			this.comboBoxFormattingStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormattingStyle_SelectedIndexChanged);
			// 
			// comboBoxSender
			// 
			this.comboBoxSender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSender.FormattingEnabled = true;
			this.comboBoxSender.Location = new System.Drawing.Point(85, 26);
			this.comboBoxSender.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxSender.Name = "comboBoxSender";
			this.comboBoxSender.Size = new System.Drawing.Size(245, 27);
			this.comboBoxSender.TabIndex = 2;
			// 
			// datePickerFromDate
			// 
			this.datePickerFromDate.Location = new System.Drawing.Point(85, 95);
			this.datePickerFromDate.Margin = new System.Windows.Forms.Padding(4);
			this.datePickerFromDate.Name = "datePickerFromDate";
			this.datePickerFromDate.Size = new System.Drawing.Size(245, 26);
			this.datePickerFromDate.TabIndex = 3;
			this.datePickerFromDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(85, 61);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(245, 26);
			this.textBox1.TabIndex = 4;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(85, 129);
			this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(245, 26);
			this.dateTimePicker2.TabIndex = 5;
			this.dateTimePicker2.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			// 
			// groupBoxFilters
			// 
			this.groupBoxFilters.Controls.Add(this.label4);
			this.groupBoxFilters.Controls.Add(this.label3);
			this.groupBoxFilters.Controls.Add(this.label2);
			this.groupBoxFilters.Controls.Add(this.label1);
			this.groupBoxFilters.Controls.Add(this.comboBoxSender);
			this.groupBoxFilters.Controls.Add(this.dateTimePicker2);
			this.groupBoxFilters.Controls.Add(this.textBox1);
			this.groupBoxFilters.Controls.Add(this.datePickerFromDate);
			this.groupBoxFilters.Location = new System.Drawing.Point(265, 9);
			this.groupBoxFilters.Name = "groupBoxFilters";
			this.groupBoxFilters.Size = new System.Drawing.Size(340, 165);
			this.groupBoxFilters.TabIndex = 6;
			this.groupBoxFilters.TabStop = false;
			this.groupBoxFilters.Text = "Message filters";
			this.groupBoxFilters.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 19);
			this.label4.TabIndex = 9;
			this.label4.Text = "To date";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 19);
			this.label3.TabIndex = 8;
			this.label3.Text = "From date";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 19);
			this.label2.TabIndex = 7;
			this.label2.Text = "Text";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 19);
			this.label1.TabIndex = 6;
			this.label1.Text = "Sender";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(141, 19);
			this.label5.TabIndex = 10;
			this.label5.Text = "Select formatting style";
			// 
			// timerNotifications_SimCorp
			// 
			this.timerNotifications_SimCorp.Interval = 3333;
			this.timerNotifications_SimCorp.Tick += new System.EventHandler(this.timerNotifications_SimCorp_Tick);
			// 
			// listViewNorifications
			// 
			this.listViewNorifications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.From,
            this.Message,
            this.Received});
			this.listViewNorifications.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listViewNorifications.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewNorifications.HideSelection = false;
			this.listViewNorifications.Location = new System.Drawing.Point(0, 180);
			this.listViewNorifications.Name = "listViewNorifications";
			this.listViewNorifications.Size = new System.Drawing.Size(609, 529);
			this.listViewNorifications.TabIndex = 12;
			this.listViewNorifications.TileSize = new System.Drawing.Size(550, 50);
			this.listViewNorifications.UseCompatibleStateImageBehavior = false;
			this.listViewNorifications.View = System.Windows.Forms.View.Tile;
			// 
			// From
			// 
			this.From.Text = "From";
			this.From.Width = 100;
			// 
			// Message
			// 
			this.Message.Text = "Norification text";
			this.Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Message.Width = 300;
			// 
			// Received
			// 
			this.Received.Text = "Date received";
			this.Received.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Received.Width = 200;
			// 
			// timerNotifications_Microsoft
			// 
			this.timerNotifications_Microsoft.Interval = 5000;
			this.timerNotifications_Microsoft.Tick += new System.EventHandler(this.timeNotifications_Microsoft_Tick);
			// 
			// timerNotifications_System
			// 
			this.timerNotifications_System.Interval = 7500;
			this.timerNotifications_System.Tick += new System.EventHandler(this.timerNotifications_System_Tick);
			// 
			// NotificationsPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 709);
			this.Controls.Add(this.listViewNorifications);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBoxFilters);
			this.Controls.Add(this.comboBoxFormattingStyle);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "NotificationsPanel";
			this.Text = "Notifications Panel";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotificationsPanel_FormClosed);
			this.groupBoxFilters.ResumeLayout(false);
			this.groupBoxFilters.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox comboBoxFormattingStyle;
		private System.Windows.Forms.ComboBox comboBoxSender;
		private System.Windows.Forms.DateTimePicker datePickerFromDate;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.GroupBox groupBoxFilters;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Timer timerNotifications_SimCorp;
		private System.Windows.Forms.ListView listViewNorifications;
		private System.Windows.Forms.ColumnHeader From;
		private System.Windows.Forms.ColumnHeader Message;
		private System.Windows.Forms.ColumnHeader Received;
		private System.Windows.Forms.Timer timerNotifications_Microsoft;
		private System.Windows.Forms.Timer timerNotifications_System;
	}
}