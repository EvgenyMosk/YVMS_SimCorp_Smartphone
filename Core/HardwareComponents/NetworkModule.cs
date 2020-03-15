using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class NetworkModule : WirelessConnectionModule {
		public override void ConnectToDevice() {
			throw new NotImplementedException();
		}
		public override string ToString() {
			return DescriptionFormatter.CreateDescription(this);
		}
	}
}
