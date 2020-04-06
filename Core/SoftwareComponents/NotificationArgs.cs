using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SoftwareComponents {
	public class NotificationEventArgs : EventArgs {
		//public DateTime Date { get; set; }
		public string Message { get; set; }
		public NotificationEventArgs(string message) {
			//Date = DateTime.Now;
			Message = message;
		}
	}
}