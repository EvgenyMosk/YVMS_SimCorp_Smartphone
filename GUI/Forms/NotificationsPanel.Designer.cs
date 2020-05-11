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
			this.comboBoxFormattingStyle = new System.Windows.Forms.ComboBox();
			this.comboBoxSender = new System.Windows.Forms.ComboBox();
			this.datePickerFromDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxMsgContainsText = new System.Windows.Forms.TextBox();
			this.datePickerToDate = new System.Windows.Forms.DateTimePicker();
			this.groupBoxFilters = new System.Windows.Forms.GroupBox();
			this.checkBoxMsgSentBetweenDates = new System.Windows.Forms.CheckBox();
			this.checkBoxMsgContainsText = new System.Windows.Forms.CheckBox();
			this.checkBoxUseSender = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.listViewNotifications = new System.Windows.Forms.ListView();
			this.From = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Received = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.checkBoxApplyFilters = new System.Windows.Forms.CheckBox();
			this.radioButtonAndOperator = new System.Windows.Forms.RadioButton();
			this.radioButtonOrOperator = new System.Windows.Forms.RadioButton();
			this.groupBoxLogicalOperators = new System.Windows.Forms.GroupBox();
			this.labelBatteryPercentage = new System.Windows.Forms.Label();
			this.progressBarBatteryPercentage = new System.Windows.Forms.ProgressBar();
			this.buttonChargePhone = new System.Windows.Forms.Button();
			this.groupBoxFilters.SuspendLayout();
			this.groupBoxLogicalOperators.SuspendLayout();
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
			this.comboBoxFormattingStyle.Location = new System.Drawing.Point(13, 57);
			this.comboBoxFormattingStyle.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxFormattingStyle.Name = "comboBoxFormattingStyle";
			this.comboBoxFormattingStyle.Size = new System.Drawing.Size(245, 27);
			this.comboBoxFormattingStyle.TabIndex = 1;
			this.comboBoxFormattingStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormattingStyle_SelectedIndexChanged);
			// 
			// comboBoxSender
			// 
			this.comboBoxSender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSender.Enabled = false;
			this.comboBoxSender.FormattingEnabled = true;
			this.comboBoxSender.Location = new System.Drawing.Point(182, 23);
			this.comboBoxSender.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxSender.Name = "comboBoxSender";
			this.comboBoxSender.Size = new System.Drawing.Size(245, 27);
			this.comboBoxSender.TabIndex = 2;
			this.comboBoxSender.SelectedIndexChanged += new System.EventHandler(this.comboBoxSender_SelectedIndexChanged);
			// 
			// datePickerFromDate
			// 
			this.datePickerFromDate.Enabled = false;
			this.datePickerFromDate.Location = new System.Drawing.Point(182, 95);
			this.datePickerFromDate.Margin = new System.Windows.Forms.Padding(4);
			this.datePickerFromDate.Name = "datePickerFromDate";
			this.datePickerFromDate.Size = new System.Drawing.Size(245, 26);
			this.datePickerFromDate.TabIndex = 3;
			this.datePickerFromDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.datePickerFromDate.ValueChanged += new System.EventHandler(this.datePickerFromDate_ValueChanged);
			// 
			// textBoxMsgContainsText
			// 
			this.textBoxMsgContainsText.Enabled = false;
			this.textBoxMsgContainsText.Location = new System.Drawing.Point(182, 61);
			this.textBoxMsgContainsText.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxMsgContainsText.Name = "textBoxMsgContainsText";
			this.textBoxMsgContainsText.Size = new System.Drawing.Size(245, 26);
			this.textBoxMsgContainsText.TabIndex = 4;
			this.textBoxMsgContainsText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// datePickerToDate
			// 
			this.datePickerToDate.Enabled = false;
			this.datePickerToDate.Location = new System.Drawing.Point(182, 131);
			this.datePickerToDate.Margin = new System.Windows.Forms.Padding(4);
			this.datePickerToDate.Name = "datePickerToDate";
			this.datePickerToDate.Size = new System.Drawing.Size(245, 26);
			this.datePickerToDate.TabIndex = 5;
			this.datePickerToDate.Value = new System.DateTime(2020, 4, 21, 0, 0, 0, 0);
			this.datePickerToDate.ValueChanged += new System.EventHandler(this.datePickerToDate_ValueChanged);
			// 
			// groupBoxFilters
			// 
			this.groupBoxFilters.Controls.Add(this.checkBoxMsgSentBetweenDates);
			this.groupBoxFilters.Controls.Add(this.checkBoxMsgContainsText);
			this.groupBoxFilters.Controls.Add(this.checkBoxUseSender);
			this.groupBoxFilters.Controls.Add(this.label4);
			this.groupBoxFilters.Controls.Add(this.label3);
			this.groupBoxFilters.Controls.Add(this.comboBoxSender);
			this.groupBoxFilters.Controls.Add(this.datePickerToDate);
			this.groupBoxFilters.Controls.Add(this.textBoxMsgContainsText);
			this.groupBoxFilters.Controls.Add(this.datePickerFromDate);
			this.groupBoxFilters.Enabled = false;
			this.groupBoxFilters.Location = new System.Drawing.Point(265, 34);
			this.groupBoxFilters.Name = "groupBoxFilters";
			this.groupBoxFilters.Size = new System.Drawing.Size(434, 166);
			this.groupBoxFilters.TabIndex = 6;
			this.groupBoxFilters.TabStop = false;
			this.groupBoxFilters.Text = "Message filters";
			// 
			// checkBoxMsgSentBetweenDates
			// 
			this.checkBoxMsgSentBetweenDates.AutoSize = true;
			this.checkBoxMsgSentBetweenDates.Location = new System.Drawing.Point(6, 113);
			this.checkBoxMsgSentBetweenDates.Name = "checkBoxMsgSentBetweenDates";
			this.checkBoxMsgSentBetweenDates.Size = new System.Drawing.Size(110, 23);
			this.checkBoxMsgSentBetweenDates.TabIndex = 17;
			this.checkBoxMsgSentBetweenDates.Text = "Sent between";
			this.checkBoxMsgSentBetweenDates.UseVisualStyleBackColor = true;
			this.checkBoxMsgSentBetweenDates.CheckedChanged += new System.EventHandler(this.checkBoxMsgSentBetweenDates_CheckedChanged);
			// 
			// checkBoxMsgContainsText
			// 
			this.checkBoxMsgContainsText.AutoSize = true;
			this.checkBoxMsgContainsText.Location = new System.Drawing.Point(6, 63);
			this.checkBoxMsgContainsText.Name = "checkBoxMsgContainsText";
			this.checkBoxMsgContainsText.Size = new System.Drawing.Size(141, 23);
			this.checkBoxMsgContainsText.TabIndex = 16;
			this.checkBoxMsgContainsText.Text = "Messages contains";
			this.checkBoxMsgContainsText.UseVisualStyleBackColor = true;
			this.checkBoxMsgContainsText.CheckedChanged += new System.EventHandler(this.checkBoxMsgContainsText_CheckedChanged);
			// 
			// checkBoxUseSender
			// 
			this.checkBoxUseSender.AutoSize = true;
			this.checkBoxUseSender.Location = new System.Drawing.Point(6, 25);
			this.checkBoxUseSender.Name = "checkBoxUseSender";
			this.checkBoxUseSender.Size = new System.Drawing.Size(135, 23);
			this.checkBoxUseSender.TabIndex = 15;
			this.checkBoxUseSender.Text = "Messages sent by";
			this.checkBoxUseSender.UseVisualStyleBackColor = true;
			this.checkBoxUseSender.CheckedChanged += new System.EventHandler(this.checkBoxUseSender_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(119, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 19);
			this.label4.TabIndex = 9;
			this.label4.Text = "Date #2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(119, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 19);
			this.label3.TabIndex = 8;
			this.label3.Text = "Date #1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 34);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(141, 19);
			this.label5.TabIndex = 10;
			this.label5.Text = "Select formatting style";
			// 
			// listViewNotifications
			// 
			this.listViewNotifications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.From,
            this.Message,
            this.Received});
			this.listViewNotifications.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listViewNotifications.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewNotifications.HideSelection = false;
			this.listViewNotifications.Location = new System.Drawing.Point(0, 206);
			this.listViewNotifications.Name = "listViewNotifications";
			this.listViewNotifications.Size = new System.Drawing.Size(706, 475);
			this.listViewNotifications.TabIndex = 12;
			this.listViewNotifications.TileSize = new System.Drawing.Size(550, 50);
			this.listViewNotifications.UseCompatibleStateImageBehavior = false;
			this.listViewNotifications.View = System.Windows.Forms.View.Tile;
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
			// buttonRefresh
			// 
			this.buttonRefresh.Location = new System.Drawing.Point(13, 174);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(245, 26);
			this.buttonRefresh.TabIndex = 13;
			this.buttonRefresh.Text = "Refresh list";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// checkBoxApplyFilters
			// 
			this.checkBoxApplyFilters.AutoSize = true;
			this.checkBoxApplyFilters.Location = new System.Drawing.Point(18, 91);
			this.checkBoxApplyFilters.Name = "checkBoxApplyFilters";
			this.checkBoxApplyFilters.Size = new System.Drawing.Size(156, 23);
			this.checkBoxApplyFilters.TabIndex = 14;
			this.checkBoxApplyFilters.Text = "Apply message filters";
			this.checkBoxApplyFilters.UseVisualStyleBackColor = true;
			this.checkBoxApplyFilters.CheckedChanged += new System.EventHandler(this.checkBoxApplyFilters_CheckedChanged);
			// 
			// radioButtonAndOperator
			// 
			this.radioButtonAndOperator.AutoSize = true;
			this.radioButtonAndOperator.Checked = true;
			this.radioButtonAndOperator.Location = new System.Drawing.Point(6, 21);
			this.radioButtonAndOperator.Name = "radioButtonAndOperator";
			this.radioButtonAndOperator.Size = new System.Drawing.Size(145, 23);
			this.radioButtonAndOperator.TabIndex = 15;
			this.radioButtonAndOperator.TabStop = true;
			this.radioButtonAndOperator.Text = "Use AND for filters";
			this.radioButtonAndOperator.UseVisualStyleBackColor = true;
			this.radioButtonAndOperator.CheckedChanged += new System.EventHandler(this.radioButtonAndOperator_CheckedChanged);
			// 
			// radioButtonOrOperator
			// 
			this.radioButtonOrOperator.AutoSize = true;
			this.radioButtonOrOperator.Location = new System.Drawing.Point(157, 21);
			this.radioButtonOrOperator.Name = "radioButtonOrOperator";
			this.radioButtonOrOperator.Size = new System.Drawing.Size(77, 23);
			this.radioButtonOrOperator.TabIndex = 16;
			this.radioButtonOrOperator.Text = "Use OR";
			this.radioButtonOrOperator.UseVisualStyleBackColor = true;
			this.radioButtonOrOperator.CheckedChanged += new System.EventHandler(this.radioButtonOrOperator_CheckedChanged);
			// 
			// groupBoxLogicalOperators
			// 
			this.groupBoxLogicalOperators.Controls.Add(this.radioButtonAndOperator);
			this.groupBoxLogicalOperators.Controls.Add(this.radioButtonOrOperator);
			this.groupBoxLogicalOperators.Enabled = false;
			this.groupBoxLogicalOperators.Location = new System.Drawing.Point(13, 116);
			this.groupBoxLogicalOperators.Name = "groupBoxLogicalOperators";
			this.groupBoxLogicalOperators.Size = new System.Drawing.Size(245, 54);
			this.groupBoxLogicalOperators.TabIndex = 17;
			this.groupBoxLogicalOperators.TabStop = false;
			this.groupBoxLogicalOperators.Text = "Logical operators";
			// 
			// labelBatteryPercentage
			// 
			this.labelBatteryPercentage.AutoSize = true;
			this.labelBatteryPercentage.Location = new System.Drawing.Point(12, 9);
			this.labelBatteryPercentage.Name = "labelBatteryPercentage";
			this.labelBatteryPercentage.Size = new System.Drawing.Size(123, 19);
			this.labelBatteryPercentage.TabIndex = 18;
			this.labelBatteryPercentage.Text = "Battery percentage";
			// 
			// progressBarBatteryPercentage
			// 
			this.progressBarBatteryPercentage.ForeColor = System.Drawing.Color.MediumSlateBlue;
			this.progressBarBatteryPercentage.Location = new System.Drawing.Point(141, 5);
			this.progressBarBatteryPercentage.Name = "progressBarBatteryPercentage";
			this.progressBarBatteryPercentage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.progressBarBatteryPercentage.Size = new System.Drawing.Size(440, 26);
			this.progressBarBatteryPercentage.Step = 1;
			this.progressBarBatteryPercentage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBarBatteryPercentage.TabIndex = 19;
			// 
			// buttonChargePhone
			// 
			this.buttonChargePhone.Location = new System.Drawing.Point(587, 5);
			this.buttonChargePhone.Name = "buttonChargePhone";
			this.buttonChargePhone.Size = new System.Drawing.Size(112, 26);
			this.buttonChargePhone.TabIndex = 20;
			this.buttonChargePhone.Text = "Charge Phone";
			this.buttonChargePhone.UseVisualStyleBackColor = true;
			this.buttonChargePhone.Click += new System.EventHandler(this.buttonChargePhone_Click);
			// 
			// NotificationsPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 681);
			this.Controls.Add(this.buttonChargePhone);
			this.Controls.Add(this.progressBarBatteryPercentage);
			this.Controls.Add(this.labelBatteryPercentage);
			this.Controls.Add(this.groupBoxLogicalOperators);
			this.Controls.Add(this.checkBoxApplyFilters);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.listViewNotifications);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBoxFilters);
			this.Controls.Add(this.comboBoxFormattingStyle);
			this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "NotificationsPanel";
			this.Text = "Notifications Panel";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotificationsPanel_FormClosing);
			this.groupBoxFilters.ResumeLayout(false);
			this.groupBoxFilters.PerformLayout();
			this.groupBoxLogicalOperators.ResumeLayout(false);
			this.groupBoxLogicalOperators.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox comboBoxFormattingStyle;
		private System.Windows.Forms.ComboBox comboBoxSender;
		private System.Windows.Forms.DateTimePicker datePickerFromDate;
		private System.Windows.Forms.TextBox textBoxMsgContainsText;
		private System.Windows.Forms.DateTimePicker datePickerToDate;
		private System.Windows.Forms.GroupBox groupBoxFilters;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListView listViewNotifications;
		private System.Windows.Forms.ColumnHeader From;
		private System.Windows.Forms.ColumnHeader Message;
		private System.Windows.Forms.ColumnHeader Received;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.CheckBox checkBoxApplyFilters;
		private System.Windows.Forms.CheckBox checkBoxUseSender;
		private System.Windows.Forms.CheckBox checkBoxMsgSentBetweenDates;
		private System.Windows.Forms.CheckBox checkBoxMsgContainsText;
		private System.Windows.Forms.RadioButton radioButtonAndOperator;
		private System.Windows.Forms.RadioButton radioButtonOrOperator;
		private System.Windows.Forms.GroupBox groupBoxLogicalOperators;
		private System.Windows.Forms.Label labelBatteryPercentage;
		private System.Windows.Forms.ProgressBar progressBarBatteryPercentage;
		private System.Windows.Forms.Button buttonChargePhone;
	}
}