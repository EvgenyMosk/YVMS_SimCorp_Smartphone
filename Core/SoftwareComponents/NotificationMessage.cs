using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class NotificationMessage : IMessage {
		public string Sender { get; set; }
		public string Body { get; set; }
		public DateTime ReceivedTime { get; set; }
		public NotificationMessage() {
		}

		public NotificationMessage(string sender, string body, DateTime receivedTime) {
			Sender = sender;
			Body = body;
			ReceivedTime = receivedTime;
		}
	}
}