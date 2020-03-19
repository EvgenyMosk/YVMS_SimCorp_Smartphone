using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public class NetworkModule : IWirelessConnectionModule {
		public IList<IWirelessConnectionModule> connectedDevices { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public OperationResult ConnectToDevice(IWirelessConnectionModule targetDevice) {
			throw new NotImplementedException();
		}

		public OperationResult DisconectDevice(IWirelessConnectionModule targetDevice) {
			throw new NotImplementedException();
		}

		public IEnumerable<IWirelessConnectionModule> SearchForDevicesNearby() {
			throw new NotImplementedException();
		}

		public override string ToString() {
			return DescriptionFormatter.CreateDescription(this);
		}
	}
}
