using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class MessagesGenerator_Task : IMessagesGenerator {
		private IMobilePhone _mobilePhone;
		private CancellationTokenSource _cancellationTokenSource;
		public int MessagesGenerationInterval { get; }
		public MessagesGenerator_Task(IMobilePhone mobilePhone, int messagesGenerationInterval) {
			if (mobilePhone == null) {
				throw new ArgumentNullException(nameof(mobilePhone));
			}
			if (messagesGenerationInterval <= 0) {
				throw new ArgumentException("Interval for Generating new messages cann be less of equal than zero!", nameof(messagesGenerationInterval));
			}

			_mobilePhone = mobilePhone;
			MessagesGenerationInterval = messagesGenerationInterval;
			_cancellationTokenSource = new CancellationTokenSource();
		}
		public void StartGeneratingNewMessages() {
			Task.Run(() => {
				while (!_cancellationTokenSource.IsCancellationRequested) {
					Thread.Sleep(MessagesGenerationInterval);
					GenerateNewMessage();
				}
			}, _cancellationTokenSource.Token);
		}
		public void StopGeneratingNewMessages() {
			_cancellationTokenSource.Cancel();
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
