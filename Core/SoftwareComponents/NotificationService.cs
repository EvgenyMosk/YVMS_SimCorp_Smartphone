﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.SoftwareComponents {
	internal class NotificationService {
		public MessagesStorage MessagesStorage { get; protected set; }
		public NotificationService(MessagesStorage messagesStorage) {
			MessagesStorage = messagesStorage;
		}

		public void ReceiveMessage(string sender, string messageBody) {
			IMessage message = new NotificationMessage(sender, messageBody, DateTime.Now);
			MessagesStorage.Add(message);
		}
	}
}