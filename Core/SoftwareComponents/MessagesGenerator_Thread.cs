using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class MessagesGenerator_Thread : IMessagesGenerator {
		private IMobilePhone _mobilePhone;
		private Thread _messageGeneratingThread;
		private bool stopThread;
		public int MessagesGenerationInterval { get; }

		public MessagesGenerator_Thread(IMobilePhone mobilePhone, int messagesGenerationInterval) {
			if (mobilePhone == null) {
				throw new ArgumentNullException(nameof(mobilePhone));
			}
			if (messagesGenerationInterval <= 0) {
				throw new ArgumentException("Interval for Generating new messages cann be less of equal than zero!", nameof(messagesGenerationInterval));
			}

			stopThread = false;
			_mobilePhone = mobilePhone;
			MessagesGenerationInterval = messagesGenerationInterval;
			_messageGeneratingThread = new Thread(GenerateNewMessages_Worker);
		}

		public void StartGeneratingNewMessages() {
			_messageGeneratingThread.Start();
		}
		public void StopGeneratingNewMessages() {
			stopThread = true;
			_messageGeneratingThread.Abort();
		}

		private void GenerateNewMessages_Worker() {
			try {
				while (!stopThread) {
					GenerateNewMessage();
					Thread.Sleep(MessagesGenerationInterval);
				}
			} catch (ThreadAbortException) {
				Thread.ResetAbort();
			}
		}
		private void GenerateNewMessage() {
			string senderName = TextProcessor.GetRandomSender();
			string messageBody = TextProcessor.GetRandomMessage();
			messageBody = TextProcessor.GetFormattedText(messageBody);

			SendMessageToSmartphone(senderName, messageBody);
		}
		private void SendMessageToSmartphone(string senderName, string messageBody) {
			_mobilePhone.ReceiveMessage(senderName, messageBody);
		}

	}
}
