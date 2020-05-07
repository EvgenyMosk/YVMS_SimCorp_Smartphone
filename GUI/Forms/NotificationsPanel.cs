using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Interfaces;
using Core.SoftwareComponents;
using Core.Writers;

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class NotificationsPanel : Form {
		public NotificationsPanel(PhoneControl phoneControl) {
			if (phoneControl == null) {
				throw new ArgumentNullException(nameof(phoneControl));
			}
			InitializeComponent();
			_random = new Random();
			_phoneControl = phoneControl;
			_formatter = TextProcessor.FormatByDefault;
			AddDefaultMessagesToStorage(_phoneControl.MobilePhone.MessagesStorage);
			comboBoxFormattingStyle.SelectedIndex = 0;

			EnableUpdatingSendersList();
			EnableNotificationsOfNewMessages();

			////_messageGeneratingThread = Task.Factory.StartNew(GenerateNewMessagesInBackground);
			//_messageGeneratingThread = new Thread(GenerateNewMessagesInBackground);
			//_messageGeneratingThread.Start();
			SwitchOnOffTimers(true); // Turn on timers

			PrintAllMessages();
		}
		private void AddDefaultMessagesToStorage(MessagesStorage messagesStorage) {
			int month = 1;
			int year = 1950;
			for (int day = 5; day < 28; day += 3) {
				NotificationMessage message = new NotificationMessage("Microsoft Corporation", "Default Message", new DateTime(year, month, day));
				messagesStorage.Add(message);
				month++;
				year += 7;
			}
		}
		private void SwitchOnOffTimers(bool turnOn) {
			if (turnOn) {
				timerNotifications.Enabled = true;
			} else {
				timerNotifications.Enabled = false;
			}
		}

		private void SelectFormatter(int indexSelected) {
			switch (indexSelected) {
				case 0:
					_formatter = TextProcessor.FormatByDefault;
					break;
				case 1:
					_formatter = TextProcessor.FormatWithDateAtStart;
					break;
				case 2:
					_formatter = TextProcessor.FormatWithDateAtEnd;
					break;
				case 3:
					_formatter = TextProcessor.FormatWithUppercase;
					break;
				case 4:
					_formatter = TextProcessor.FormatWithLowercase;
					break;
				default:
					throw new ArgumentException("Given value is not supported!", nameof(indexSelected));
			}
		}

		private void timerNotifications_Tick(object sender, EventArgs e) {
			string senderName = GetRandomSender();
			string messageBody = GetRandomMessage();
			messageBody = _formatter(messageBody);

			SendMessageToSmartphone(senderName, messageBody);
		}
		#region Form events
		private void NotificationsPanel_FormClosed(object sender, FormClosedEventArgs e) {
			//_messageGeneratingThread.Abort();
			SwitchOnOffTimers(false); // Turn off timers
			DisableNotificationsOfNewMessages();
			DisableUpdatingSendersList();
		}

		private void comboBoxFormattingStyle_SelectedIndexChanged(object sender, EventArgs e) {
			SelectFormatter(comboBoxFormattingStyle.SelectedIndex);
		}
		private void buttonRefresh_Click(object sender, EventArgs e) {
			RefreshMessageList();
		}
		private void checkBoxApplyFilters_CheckedChanged(object sender, EventArgs e) {
			if (checkBoxApplyFilters.Checked == true) {
				EnableDisableGroupBoxes(true);
			} else {
				EnableDisableGroupBoxes(false);
			}
			RefreshMessageList();
		}
		private void comboBoxSender_SelectedIndexChanged(object sender, EventArgs e) {
			RefreshMessageList();
		}
		private void textBox1_TextChanged(object sender, EventArgs e) {
			RefreshMessageList();
		}
		private void datePickerFromDate_ValueChanged(object sender, EventArgs e) {
			RefreshMessageList();
		}
		private void datePickerToDate_ValueChanged(object sender, EventArgs e) {
			RefreshMessageList();
		}

		private void checkBoxMsgSentBetweenDates_CheckedChanged(object sender, EventArgs e) {
			if (checkBoxMsgSentBetweenDates.Checked == true) {
				datePickerFromDate.Enabled = true;
				datePickerToDate.Enabled = true;
			} else {
				datePickerFromDate.Enabled = false;
				datePickerToDate.Enabled = false;
			}
		}
		private void checkBoxMsgContainsText_CheckedChanged(object sender, EventArgs e) {
			if (checkBoxMsgContainsText.Checked == true) {
				textBoxMsgContainsText.Enabled = true;
			} else {
				textBoxMsgContainsText.Enabled = false;
			}
		}
		private void checkBoxUseSender_CheckedChanged(object sender, EventArgs e) {
			if (checkBoxUseSender.Checked == true) {
				comboBoxSender.Enabled = true;
			} else {
				comboBoxSender.Enabled = false;
			}
		}
		private void radioButtonAndOperator_CheckedChanged(object sender, EventArgs e) {
			RefreshMessageList();
		}
		private void radioButtonOrOperator_CheckedChanged(object sender, EventArgs e) {
			RefreshMessageList();
		}
		#endregion
	}
}