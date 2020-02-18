using Core.Enums;
using System;

namespace Core {
	public class Bluetooth : WirelessConnectionModule {
		public BluetoothStandard BluetoothStandard { get; set; }

		public override void ConnectToDevice() {
			throw new NotImplementedException();
		}
	}
}
