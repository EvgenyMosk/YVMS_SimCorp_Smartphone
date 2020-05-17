using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class NewPhoneCallEventArgs : EventArgs {
		public ICall PhoneCall { get; set; }
		public NewPhoneCallEventArgs(ICall phoneCall) {
			PhoneCall = phoneCall;
		}
	}
}
