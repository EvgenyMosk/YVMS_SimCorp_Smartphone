using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SoftwareComponents {
	public class NotificationService {
		public event EventHandler<NotificationEventArgs> MessageReceived;
		public void ReceiveMessage(string message) {
			OnMessageReceived(message);
		}
		protected virtual void OnMessageReceived(string message) {
			MessageReceived?.Invoke(this, new NotificationEventArgs(message));
		}
	}
}