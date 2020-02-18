using System;

namespace Core {
	public class Chipset : ICommonDescription {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public Bluetooth Bluetooth { get; set; }
		public CPU CPU { get; set; }
		public GPU GPU { get; set; }
		public WiFi WiFi { get; set; }

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}

	}
}
