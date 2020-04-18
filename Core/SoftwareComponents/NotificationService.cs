using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class NotificationService {
		public event EventHandler<NotificationEventArgs> MessageReceived;

		public void ReceiveMessage(string message) {
			OnMessageReceived(message);
		}
		public void ReceiveMessage(string sender, string messageBody) {
			OnMessageReceived(sender, messageBody);
		}

		protected virtual void OnMessageReceived(string message) {
			MessageReceived?.Invoke(this, new NotificationEventArgs("system.notificationService", message));
		}
		protected virtual void OnMessageReceived(string sender, string messageBody) {
			IMessage message = new NotificationMessage(sender, messageBody, DateTime.Now);
			MessageReceived?.Invoke(this, new NotificationEventArgs(message));
		}
	}
}