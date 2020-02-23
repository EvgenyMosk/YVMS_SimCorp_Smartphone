using System;

namespace Core {
	public class WiFi : WirelessConnectionModule {
		public WiFiStandard WiFiStandard { get; set; }

		public override void ConnectToDevice() {
			throw new NotImplementedException();
		}
	}
}