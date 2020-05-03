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

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class NotificationsPanel : Form {
		private readonly PhoneControl _phoneControl;
		private readonly Random _random;
		private static readonly string[] _messagesTexts = { "Payment successful! See details at: https://privatbank.ua/payments/mypayments",
			"Your order arrived at destination country!",
			"Update available!",
			"You missed 3 calls from +3809987654321",
			"Money transfer successful!",
			"New video from Metallica Official Channel, watch now: you.tu/jsdka",
			".NET Core 3.3.3.81 available for download!",
			"Login to your account from new device."};
		private static readonly string[] _messagesSenders = { "SimCorp Ltd.",
			"Microsoft Corporation",
			"System Notification Service" };
		private delegate string MessageFormatDelegate(string text);
		private MessageFormatDelegate _formatter;

		public string GetSelectedSender() {
			return comboBoxSender.Text;
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

		private string GetRandomSender() {
			int senderIndex = _random.Next(_messagesSenders.Length);
			return _messagesSenders[senderIndex];
		}
		private string GetRandomMessage() {
			int messageIndex = _random.Next(_messagesTexts.Length);
			return _messagesTexts[messageIndex];
		}
		private void SendMessageToSmartphone(string senderName, string messageBody) {
			_phoneControl.MobilePhone.ReceiveMessage(senderName, messageBody);
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
			if (listViewNotifications == null) {
				return;
			}
			listViewNotifications.Items.Clear();
		}

		private void PrintMessagesToListView(IEnumerable<IMessage> messages) {
			if (messages == null) {
				return;
			}

			foreach (IMessage message in messages) {
				PrintMessageToListView(message);
			}
		}
		private void PrintMessageToListView(IMessage message) {
			if (listViewNotifications == null || message == null) {
				return;
			}

			string messageDatereceived = message.ReceivedTime.ToShortDateString() + " " + message.ReceivedTime.ToShortTimeString();
			ListViewItem viewItem = new ListViewItem(new[] { message.Sender, message.Body, messageDatereceived });
			listViewNotifications.Items.Add(viewItem);
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
		public virtual void DisableUpdatingSendersList() {
			_phoneControl.MobilePhone.MessagesStorage.SendersListChanged -= UpdateSendersList;
		}
		public virtual void UpdateSendersList(object sender, SendersListChangedArgs senders) {
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
		public virtual void EnableNotificationsOfNewMessages() {
			if (listViewNotifications == null) {
				throw new NullReferenceException(nameof(listViewNotifications));
			}
			ClearListView();
			_phoneControl.MobilePhone.MessagesStorage.MessageReceived += ShowNotificationOfNewMessages;
		}
		public virtual void DisableNotificationsOfNewMessages() {
			_phoneControl.MobilePhone.MessagesStorage.MessageReceived -= ShowNotificationOfNewMessages;
		}
		public void ShowNotificationOfNewMessages(object sender, NotificationEventArgs e) {
			if (listViewNotifications == null || e == null) {
				return;
			}

			RefreshMessageList();
		}
		#endregion
	}
}
