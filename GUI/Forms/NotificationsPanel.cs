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
using Core.SoftwareComponents;

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class NotificationsPanel : Form {
		public NotificationsPanel(PhoneControl phoneControl, bool useThread) {
			ValidatePhoneControl();

			InitializeComponent();
			_phoneControl = phoneControl;

			if (_phoneControl.MobilePhone.MessagesStorage.Count == 0) {
				AddDefaultMessagesToStorage(_phoneControl.MobilePhone.MessagesStorage);
			}

			comboBoxFormattingStyle.SelectedIndex = 0;

			progressBarBatteryPercentage.Value = _phoneControl.MobilePhone.Battery.CurrentChargePercentage;

			EnableUpdates();

			PrintAllMessages();

			StartDischargingPhone();

			int messagesGenerationInterval = 5000;
			if (useThread) {
				_messagesGenerator = new MessagesGenerator_Thread(phoneControl.MobilePhone, messagesGenerationInterval);
			} else {
				_messagesGenerator = new MessagesGenerator_Task(phoneControl.MobilePhone, messagesGenerationInterval);
			}

			_messagesGenerator.StartGeneratingNewMessages();

			void ValidatePhoneControl() {
				if (phoneControl == null) {
					throw new ArgumentNullException(nameof(phoneControl));
				}
				if (phoneControl.MobilePhone == null) {
					throw new ArgumentNullException(nameof(phoneControl), "Mobile Phone in PhoneControl cannot be null!");
				}
				if (phoneControl.MobilePhone.MessagesStorage == null) {
					throw new ArgumentNullException(nameof(phoneControl), "Messages Storage in PhoneControl cannot be null!");
				}
				if (phoneControl.MobilePhone.Battery == null) {
					throw new ArgumentNullException(nameof(phoneControl), "Battery in PhoneControl cannot be null!");
				}
			}
			void EnableUpdates() {
				EnableUpdatingSendersList();
				EnableNotificationsOfNewMessages();
				EnablePhoneBatteryUpdateOnProgBar();
			}
			void StartDischargingPhone() {
				_phoneControl.ResetCharging();
				_phoneControl.UnplugPhoneFromPowerSource();
			}
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

		#region Form events
		private void NotificationsPanel_FormClosing(object sender, FormClosingEventArgs e) {
			DisableNotificationsOfNewMessages();
			DisableUpdatingSendersList();
			DisablePhoneBatteryUpdateOnProgBar();

			_messagesGenerator.StopGeneratingNewMessages();
			_phoneControl.Dispose();
		}

		private void buttonChargePhone_Click(object sender, EventArgs e) {
			if (buttonChargePhone.Text.ToLower() == "charge phone") {
				buttonChargePhone.Text = "Stop charging";
				_phoneControl.PlugPhoneToPowerSource();
			} else {
				buttonChargePhone.Text = "Charge phone";
				_phoneControl.UnplugPhoneFromPowerSource();
			}
		}

		private void comboBoxFormattingStyle_SelectedIndexChanged(object sender, EventArgs e) {
			TextProcessor.SelectFormatter(comboBoxFormattingStyle.SelectedIndex);
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