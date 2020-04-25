using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SoftwareComponents {
	public class SendersListChangedArgs : EventArgs {
		public IEnumerable<string> Senders { get; set; }
		public SendersListChangedArgs(IEnumerable<string> senders) {
			Senders = senders;
		}
	}
}
