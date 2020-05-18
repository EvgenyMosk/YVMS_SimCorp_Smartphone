namespace GUI.Forms {
	partial class PhoneCallsPanelForm {
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
			this.listViewPhoneCalls = new System.Windows.Forms.ListView();
			this.contactName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.callDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.callDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label1 = new System.Windows.Forms.Label();
			this.richTextBoxLastMessage = new System.Windows.Forms.RichTextBox();
			this.mergedWithPrev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.phoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listViewPhoneCalls
			// 
			this.listViewPhoneCalls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.contactName,
            this.phoneNumber,
            this.callDirection,
            this.callDate,
            this.mergedWithPrev});
			this.listViewPhoneCalls.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listViewPhoneCalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewPhoneCalls.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewPhoneCalls.HideSelection = false;
			this.listViewPhoneCalls.HoverSelection = true;
			this.listViewPhoneCalls.Location = new System.Drawing.Point(0, 109);
			this.listViewPhoneCalls.Name = "listViewPhoneCalls";
			this.listViewPhoneCalls.Size = new System.Drawing.Size(1071, 572);
			this.listViewPhoneCalls.TabIndex = 0;
			this.listViewPhoneCalls.UseCompatibleStateImageBehavior = false;
			this.listViewPhoneCalls.View = System.Windows.Forms.View.Details;
			// 
			// contactName
			// 
			this.contactName.Text = "Contact Name";
			this.contactName.Width = 160;
			// 
			// callDirection
			// 
			this.callDirection.Text = "Call Direction";
			this.callDirection.Width = 150;
			// 
			// callDate
			// 
			this.callDate.Text = "Call Date";
			this.callDate.Width = 300;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(186, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Last generated message";
			// 
			// richTextBoxLastMessage
			// 
			this.richTextBoxLastMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.richTextBoxLastMessage.Location = new System.Drawing.Point(0, 38);
			this.richTextBoxLastMessage.Name = "richTextBoxLastMessage";
			this.richTextBoxLastMessage.Size = new System.Drawing.Size(1071, 71);
			this.richTextBoxLastMessage.TabIndex = 2;
			this.richTextBoxLastMessage.Text = "";
			// 
			// mergedWithPrev
			// 
			this.mergedWithPrev.Text = "Merged with previous";
			this.mergedWithPrev.Width = 140;
			// 
			// phoneNumber
			// 
			this.phoneNumber.Text = "Contact phone number";
			this.phoneNumber.Width = 160;
			// 
			// PhoneCallsPanelForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1071, 681);
			this.Controls.Add(this.richTextBoxLastMessage);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listViewPhoneCalls);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "PhoneCallsPanelForm";
			this.Text = "Phone Calls Panel";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhoneCallsPanelForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listViewPhoneCalls;
		private System.Windows.Forms.ColumnHeader contactName;
		private System.Windows.Forms.ColumnHeader callDirection;
		private System.Windows.Forms.ColumnHeader callDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox richTextBoxLastMessage;
		private System.Windows.Forms.ColumnHeader mergedWithPrev;
		private System.Windows.Forms.ColumnHeader phoneNumber;
	}
}