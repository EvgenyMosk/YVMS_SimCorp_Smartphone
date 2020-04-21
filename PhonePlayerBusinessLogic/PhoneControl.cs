using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Interfaces;
using Core.SoftwareComponents;

namespace PhonePlayerBusinessLogic {
	public class PhoneControl {
		public IMobilePhone MobilePhone { get; set; }
		protected ListView _listView;
		public bool FiltersActive { get; set; }
		public PhoneControl(IMobilePhone mobilePhone, IAudioOutputDevice audioOutputDevice, IOutput audioDeviceOutput) {
			if (mobilePhone == null) {
				throw new ArgumentNullException(nameof(mobilePhone));
			}
			MobilePhone = mobilePhone;

			MobilePhone.AudioOutputDevice = audioOutputDevice;

			if (mobilePhone.AudioOutputDevice != null) {
				MobilePhone.AudioOutputDevice.Output = audioDeviceOutput;
			}
		}
		public virtual void PlayAudio(string audioFile) {
			if (MobilePhone.AudioOutputDevice == null || string.IsNullOrWhiteSpace(audioFile)) {
				return;
			}
			MobilePhone.AudioOutputDevice.PlayFile(audioFile);
		}
		public virtual string PlayAudioAndReturnString(string audioFile) {
			if (MobilePhone.AudioOutputDevice == null || string.IsNullOrWhiteSpace(audioFile)) {
				return string.Empty;
			}
			return MobilePhone.AudioOutputDevice.PlayFileAndReturnString(audioFile);
		}
		public virtual void StopPlayingAudio() {
			if (MobilePhone.AudioOutputDevice == null) {
				return;
			}
			MobilePhone.AudioOutputDevice.StopPlayingAudio();
		}
		public virtual void EnableNotifications(ListView listView) {
			_listView = listView;
			ClearListView();
			MobilePhone.MessagesStorage.MessageReceived += ShowNotification;
		}
		public virtual void DisableNotifications() {
			MobilePhone.MessagesStorage.MessageReceived -= ShowNotification;
		}
		public void ShowNotification(object sender, NotificationEventArgs e) {
			if (_listView == null || e == null) {
				return;
			}

			PrintMessageToListView(e.GetMessage());
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
			if (_listView == null || message == null) {
				return;
			}

			string messageDatereceived = message.ReceivedTime.ToShortDateString() + " " + message.ReceivedTime.ToShortTimeString();
			ListViewItem viewItem = new ListViewItem(new[] { message.Sender, message.Body, messageDatereceived });
			_listView.Items.Add(viewItem);
		}

		public void ClearListView() {
			if (_listView == null) {
				return;
			}
			_listView.Items.Clear();
		}

		public IEnumerable<string> GetMessagesSenders(string sender) {
			IEnumerable<string> senders = MobilePhone.MessagesStorage.GetMessagesSenders();

			return senders;
		}
		#region Print to ListView using GET methods from MessagesStorage
		public void PrintAllMessages() {
			if (_listView == null) {
				return;
			}
			ClearListView();
			IList<IMessage> messages = MobilePhone.MessagesStorage.GetMessages();
			PrintMessagesToListView(messages);
		}
		public void PrintMessagesFromCertainSender(string sender) {
			if (_listView == null) {
				return;
			}
			ClearListView();
			IEnumerable<IMessage> messages = MobilePhone.MessagesStorage.GetMessagesFromCertainSender(sender);
			PrintMessagesToListView(messages);
		}
		public void PrintMessagesContainsCertainText(string text) {
			if (_listView == null) {
				return;
			}
			ClearListView();
			IEnumerable<IMessage> messages = MobilePhone.MessagesStorage.GetMessagesContainsCertainText(text);
			PrintMessagesToListView(messages);
		}
		public void PrintMessagesBetweenCertainDates(DateTime fromDate, DateTime toDate) {
			if (_listView == null) {
				return;
			}
			ClearListView();
			IEnumerable<IMessage> messages = MobilePhone.MessagesStorage.GetMessagesBetweenDates(fromDate, toDate);
			PrintMessagesToListView(messages);
		}
		#endregion
	}
}