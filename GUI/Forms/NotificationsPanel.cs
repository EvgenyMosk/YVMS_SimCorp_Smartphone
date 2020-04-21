using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Interfaces;
using Core.SoftwareComponents;
using Core.Writers;

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class NotificationsPanel : Form {
		private readonly PhoneControl PhoneControl;
		private readonly Random Random;
		private delegate string MessageFormatDelegate(string text);
		private MessageFormatDelegate Formatter;
		private static readonly string[] _messagesTexts = { "Payment successful! See details at: https://privatbank.ua/payments/mypayments",
			"Your order arrived at destination country!",
			"Update available!",
		"You missed 3 calls from +3809987654321",
		"Money transfer successful!",
		"New video from Metallica Official Channel, watch now: you.tu/jsdka",
		".NET Core 3.3.3.81 available for download!",
		"Login to your account from new device."};
		private static readonly string[] _messagesSenders = { "SimCorp Ltd.", "Microsoft Corporation", "System Notification Service" };

		public NotificationsPanel(PhoneControl phoneControl) {
			if (phoneControl == null) {
				throw new ArgumentNullException(nameof(phoneControl));
			}
			InitializeComponent();

			comboBoxFormattingStyle.SelectedIndex = 0;

			PhoneControl = phoneControl;

			PhoneControl.EnableNotifications(listViewNotifications);

			Random = new Random();
			SwitchOnOffTimers(true); // Turn on timers

			Formatter = TextProcessor.FormatByDefault;
		}

		private void SwitchOnOffTimers(bool turnOn) {
			if (turnOn) {
				timerNotifications.Enabled = true;
			} else {
				timerNotifications.Enabled = false;
			}
		}
		private void NotificationsPanel_FormClosed(object sender, FormClosedEventArgs e) {
			SwitchOnOffTimers(false); // Turn off timers
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
					throw new ArgumentException("Given value is not supported!", nameof(indexSelected));
			}
		}

		#region Timers ticks events
		private void timerNotifications_Tick(object sender, EventArgs e) {
			string senderName = GetRandomSender();
			string messageBody = GetRandomMessage();
			messageBody = Formatter(messageBody);

			SendMessageToSmartphone(senderName, messageBody);
		}
		private void timerNotifications_System_Tick(object sender, EventArgs e) {
			string senderName = "System Notification Service";

			string messageBody = GetRandomMessage();
			messageBody = Formatter(messageBody);

			SendMessageToSmartphone(senderName, messageBody);
		}
		#endregion
		private string GetRandomSender() {
			int senderIndex = Random.Next(_messagesSenders.Length);
			return _messagesSenders[senderIndex];
		}
		private string GetRandomMessage() {
			int messageIndex = Random.Next(_messagesTexts.Length);
			return _messagesTexts[messageIndex];
		}
		private void SendMessageToSmartphone(string senderName, string messageBody) {
			PhoneControl.MobilePhone.ReceiveMessage(senderName, messageBody);
		}

		private void buttonRefresh_Click(object sender, EventArgs e) {
			PhoneControl.ClearListView();
			PhoneControl.PrintAllMessages();
		}

		private void checkBoxApplyFilters_CheckedChanged(object sender, EventArgs e) {
			if (checkBoxApplyFilters.Checked == true) {
				PhoneControl.DisableNotifications();
				SwitchOnOffFilters(true);
			} else {
				PhoneControl.EnableNotifications(listViewNotifications);
				SwitchOnOffFilters(false);
			}
		}
		private void SwitchOnOffFilters(bool switchOn) {
			if (switchOn) {
				groupBoxFilters.Enabled = true;
				PhoneControl.FiltersActive = true;
			} else {
				groupBoxFilters.Enabled = false;
				PhoneControl.FiltersActive = false;
			}
		}

		private void comboBoxSender_SelectedIndexChanged(object sender, EventArgs e) {
			PhoneControl.PrintMessagesFromCertainSender(comboBoxSender.Text);
		}
		private void textBox1_TextChanged(object sender, EventArgs e) {
			PhoneControl.PrintMessagesContainsCertainText(textBox1.Text);
		}
		private void datePickerFromDate_ValueChanged(object sender, EventArgs e) {
			PhoneControl.PrintMessagesBetweenCertainDates(datePickerFromDate.Value, datePickerToDate.Value);
		}
		private void datePickerToDate_ValueChanged(object sender, EventArgs e) {
			PhoneControl.PrintMessagesBetweenCertainDates(datePickerFromDate.Value, datePickerToDate.Value);
		}
	}
}