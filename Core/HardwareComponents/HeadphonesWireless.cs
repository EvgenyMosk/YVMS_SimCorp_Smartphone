using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core.HardwareComponents {
	public class HeadphonesWireless : HeadphonesDecorator, IWirelessConnectionModule {
		public IList<IWirelessConnectionModule> connectedDevices { get; set; }
		public HeadphonesWireless(IAudioOutputDevice audioOutputDevice) : base(audioOutputDevice) {
			connectedDevices = new List<IWirelessConnectionModule>();
		}

		public OperationResult ConnectToDevice(IWirelessConnectionModule targetDevice) {
			if (targetDevice == null) {
				throw new ArgumentNullException(nameof(targetDevice));
			}
			connectedDevices.Add(targetDevice);
			return OperationResult.Success;
		}

		public OperationResult DisconectDevice(IWirelessConnectionModule targetDevice) {
			if (connectedDevices.Contains(targetDevice)) {
				connectedDevices.Remove(targetDevice);
				return OperationResult.Success;
			} else {
				return OperationResult.DeviceNotExist;
			}
		}

		public IEnumerable<IWirelessConnectionModule> SearchForDevicesNearby() {
			throw new NotImplementedException();
		}
		public override string ToString() {
			string description;
			description = TextProcessor.CreateDescription(this);
			return description;
		}
	}
}