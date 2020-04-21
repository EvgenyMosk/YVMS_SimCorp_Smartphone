using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class NotificationEventArgs : EventArgs {
		private readonly IMessage notificationMessage;
		public string Sender { get { return notificationMessage.Sender; } }
		public string Body { get { return notificationMessage.Body; } }
		public DateTime ReceivedTime { get { return notificationMessage.ReceivedTime; } }

		public NotificationEventArgs(string sender, string messageBody)
			: this(sender, messageBody, DateTime.Now) { }
		public NotificationEventArgs(string sender, string messageBody, DateTime receivedTime) {
			notificationMessage = new NotificationMessage(sender, messageBody, receivedTime);
		}
		public NotificationEventArgs(IMessage message) {
			notificationMessage = message;
		}
		public IMessage GetMessage() {
			return notificationMessage;
		}
	}
}