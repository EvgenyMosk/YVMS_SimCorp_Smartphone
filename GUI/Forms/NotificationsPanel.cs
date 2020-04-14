﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.SoftwareComponents;
using Core.Writers;

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class NotificationsPanel : Form {
		private readonly PhoneControl PhoneControl;
		private readonly Random Random;
		private delegate string MessageFormatDelegate(string text);
		private MessageFormatDelegate Formatter;
		public NotificationsPanel(PhoneControl phoneControl) {
			if (phoneControl == null) {
				throw new ArgumentNullException(nameof(phoneControl));
			}
			InitializeComponent();

			comboBoxFormattingStyle.SelectedIndex = 0;

			PhoneControl = phoneControl;
			IOutput output = new ListViewWriter(listViewNorifications);
			PhoneControl.EnableNotifications(output);

			Random = new Random();
			timerNotifications.Enabled = true;

			Formatter = TextProcessor.FormatByDefault;
		}

		private void timerNotifications_Tick(object sender, EventArgs e) {
			int senderNameLength = Random.Next(15);
			int messageLength = Random.Next(100);
			string senderName = TextProcessor.GenerateRandomString(senderNameLength, Random);
			string messageBody = TextProcessor.GenerateRandomString(messageLength, Random);
			messageBody = Formatter(messageBody);

			PhoneControl.mobilePhone.NotificationService.ReceiveMessage(senderName, messageBody);
		}

		private void NotificationsPanel_FormClosed(object sender, FormClosedEventArgs e) {
			timerNotifications.Enabled = false;
			PhoneControl.DisableNotifications();
		}

		private void comboBoxFormattingStyle_SelectedIndexChanged(object sender, EventArgs e) {
			SelectFormatter(comboBoxFormattingStyle.SelectedIndex);
		}

		private void SelectFormatter(int indexSelected) {
			switch (indexSelected) {
				case 0:
					Formatter = TextProcessor.FormatByDefault;
					break;
				case 1:
					Formatter = TextProcessor.FormatWithDateAtStart;
					break;
				case 2:
					Formatter = TextProcessor.FormatWithDateAtEnd;
					break;
				case 3:
					Formatter = TextProcessor.FormatWithUppercase;
					break;
				case 4:
					Formatter = TextProcessor.FormatWithLowercase;
					break;
				default:
					throw new ArgumentException("Given argument is not supported!", nameof(indexSelected));
			}
		}

	}
}
