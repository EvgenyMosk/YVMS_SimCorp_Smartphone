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
using Core.HardwareComponents;
using Core.Interfaces;
using Core.SoftwareComponents;

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class NotificationsPanel : Form {
		private readonly PhoneControl _phoneControl;
		private IMessagesGenerator _messagesGenerator;

		#region GetSomething methods
		// https://stackoverflow.com/questions/3117957/return-value-from-control-invokemethodinvoker-delegate-i-need
		public string GetSelectedSender() {
			if (InvokeRequired) {
				return (string)Invoke((Func<string>)delegate {
					return comboBoxSender.Text;
				});
			} else {
				return comboBoxSender.Text;
			}
		}
		public string GetTextForFiltering() {
			return textBoxMsgContainsText.Text;
		}
		public DateTime GetFromDate() {
			return datePickerFromDate.Value;
		}
		public DateTime GetToDate() {
			return datePickerToDate.Value;
		}
		#endregion

		private void SetProgressBarValue(int value) {
			if (InvokeRequired && !progressBarBatteryPercentage.IsDisposed) {
				Invoke(new MethodInvoker(() => SetProgressBarValue(value)));
			} else if (progressBarBatteryPercentage != null) {
				progressBarBatteryPercentage.Value = value;
			}
		}

		#region Filtering
		private void EnableDisableGroupBoxes(bool switchOn) {
			if (groupBoxFilters == null) { return; }
			if (switchOn) { groupBoxFilters.Enabled = true; } else {
				groupBoxFilters.Enabled = false;
			}

			if (groupBoxLogicalOperators == null) { return; }
			if (switchOn) { groupBoxLogicalOperators.Enabled = true; } else {
				groupBoxLogicalOperators.Enabled = false;
			}
		}

		private void FilterMessagesWithLogicalOperators() {
			if (!checkBoxApplyFilters.Checked) {
				return;
			}

			IEnumerable<IMessage> filteredMessages;
			IEnumerable<IMessage> msgsFilteredBySender = new List<IMessage>();
			IEnumerable<IMessage> msgsFilteredByText = new List<IMessage>();
			IEnumerable<IMessage> msgsFilteredByDate = new List<IMessage>();

			if (checkBoxUseSender.Checked) {
				string sender = GetSelectedSender();
				msgsFilteredBySender = _phoneControl.MobilePhone.MessagesStorage.GetMessagesFromCertainSender(sender);
			}
			if (checkBoxMsgContainsText.Checked) {
				string text = GetTextForFiltering();
				msgsFilteredByText = _phoneControl.MobilePhone.MessagesStorage.GetMessagesContainsCertainText(text);
			}
			if (checkBoxMsgSentBetweenDates.Checked) {
				DateTime fromDate = GetFromDate();
				DateTime toDate = GetToDate();

				if (fromDate > toDate) { // Swap dates if their order is not correct
					DateTime tmp = toDate;
					toDate = fromDate;
					fromDate = tmp;
				}

				msgsFilteredByDate = _phoneControl.MobilePhone.MessagesStorage.GetMessagesBetweenDates(fromDate, toDate);
			}

			if (radioButtonAndOperator.Checked) {
				filteredMessages = MessagesStorage.ApplyAND(msgsFilteredBySender, msgsFilteredByText, msgsFilteredByDate);
			} else if (radioButtonOrOperator.Checked) {
				filteredMessages = MessagesStorage.ApplyOR(msgsFilteredBySender, msgsFilteredByText, msgsFilteredByDate);
			} else {
				throw new NotSupportedException("Either OR or AND operator must be used!");
			}

			PrintMessagesToListView(filteredMessages);
		}

		#endregion
		#region Output to ListView
		public void ClearListView() {
			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => ClearListView()));
			} else {
				listViewNotifications.Items.Clear();
			}
		}

		private void PrintMessagesToListView(IEnumerable<IMessage> messages) {
			if (messages == null) {
				return;
			}

			foreach (IMessage message in messages.ToList()) {
				PrintMessageToListView(message);
			}
		}
		private void PrintMessageToListView(IMessage message) {
			if (listViewNotifications == null || message == null) {
				return;
			}

			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => PrintMessageToListView(message)));
			} else {
				string messageDatereceived = ComposeMessageDate();
				ListViewItem viewItem = new ListViewItem(new[] { message.Sender, message.Body, messageDatereceived });
				listViewNotifications.Items.Add(viewItem);
			}

			string ComposeMessageDate() {
				return message.ReceivedTime.ToShortDateString() + " " + message.ReceivedTime.ToShortTimeString();
			}
		}

		public void PrintAllMessages() {
			if (listViewNotifications == null) {
				return;
			}
			ClearListView();
			IList<IMessage> messages = _phoneControl.MobilePhone.MessagesStorage.GetMessages();
			PrintMessagesToListView(messages);
		}
		private void RefreshMessageList() {
			ClearListView();

			if (checkBoxApplyFilters.Checked) {
				FilterMessagesWithLogicalOperators();
			} else {
				PrintAllMessages();
			}
		}
		#endregion
		#region Update-related events
		public virtual void EnableUpdatingSendersList() {
			if (comboBoxSender == null) {
				throw new NullReferenceException(nameof(comboBoxSender));
			}
			_phoneControl.MobilePhone.MessagesStorage.SendersListChanged += UpdateSendersList;
		}
		private void DisableUpdatingSendersList() {
			_phoneControl.MobilePhone.MessagesStorage.SendersListChanged -= UpdateSendersList;
		}
		private void UpdateSendersList(object sender, SendersListChangedArgs senders) {
			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => UpdateSendersList(sender, senders)));
			} else {
				string currentlySelectedSender = comboBoxSender.Text;

				List<string> newSendersList = _phoneControl.MobilePhone.MessagesStorage.GetMessagesSenders().ToList();

				comboBoxSender.Items.Clear();
				AddSendersToComboBox(newSendersList);

				if (newSendersList.Contains(currentlySelectedSender)) {
					comboBoxSender.SelectedItem = currentlySelectedSender;
				}

				void AddSendersToComboBox(IList<string> sendersList) {
					foreach (string newSender in sendersList) {
						comboBoxSender.Items.Add(newSender);
					}
				}
			}
		}
		private void EnableNotificationsOfNewMessages() {
			if (listViewNotifications == null) {
				throw new NullReferenceException(nameof(listViewNotifications));
			}
			ClearListView();
			_phoneControl.MobilePhone.MessagesStorage.MessageReceived += ShowNotificationOfNewMessages;
		}
		public virtual void DisableNotificationsOfNewMessages() {
			_phoneControl.MobilePhone.MessagesStorage.MessageReceived -= ShowNotificationOfNewMessages;
		}
		private void ShowNotificationOfNewMessages(object sender, NotificationEventArgs e) {
			if (listViewNotifications == null || e == null) {
				return;
			}

			RefreshMessageList();
		}
		private void EnablePhoneBatteryUpdateOnProgBar() {
			_phoneControl.MobilePhone.Battery.CurrentCapacityChanged += DisplayBatteryPercentage;
		}
		private void DisablePhoneBatteryUpdateOnProgBar() {
			_phoneControl.MobilePhone.Battery.CurrentCapacityChanged -= DisplayBatteryPercentage;
		}
		private void DisplayBatteryPercentage(object sender, CurrBatCapacityChngdEventArgs e) {
			if (progressBarBatteryPercentage.IsDisposed) {
				return;
			}

			int currentBatteryChargePercentage = e.CurrentBatteryCapacity;

			if (currentBatteryChargePercentage >= 0 && currentBatteryChargePercentage <= 100) {
				SetProgressBarValue(currentBatteryChargePercentage);
			}
		}
		#endregion
	}
}