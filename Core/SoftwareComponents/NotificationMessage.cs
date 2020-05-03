﻿using System;
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
		public NotificationMessage() { }
		public NotificationMessage(string sender, string body) : this(sender, body, DateTime.Now) { }
		public NotificationMessage(string sender, string body, DateTime receivedTime) {
			Sender = sender;
			Body = body;
			ReceivedTime = receivedTime;
		}

		public bool Equals(IMessage other) {
			if (other is null) {
				return false;
			}
			return Sender == other.Sender
				&& Body == other.Body
				&& ReceivedTime == other.ReceivedTime;
		}
		public int CompareTo(IMessage other) {
			if (Equals(other)) {
				return 0;
			} else {
				return -1;
			}
		}
	}
}