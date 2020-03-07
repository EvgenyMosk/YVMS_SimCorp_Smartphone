using System;

namespace Core {
	public class Chipset : ICommonDescription, IChipset {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public CPU CPU { get; set; }
		public GPU GPU { get; set; }
		public WiFi WiFi { get; set; }
		public Bluetooth Bluetooth { get; set; }

		public Chipset() : this(null, null, null, null) { }
		public Chipset(
			CPU cpu,
			GPU gpu,
			WiFi wifi,
			Bluetooth bluetooth,
			string model = "CHIPSET_MODEL",
			string manufacturer = "CHIPSET_MANUFACTURER",
			int? yearOfProduction = null,
			string version = "VERSION_PREALPHA") {
			if (bluetooth == null) {
				bluetooth = new Bluetooth();
			}
			if (cpu == null) {
				cpu = new CPU();
			}
			if (gpu == null) {
				gpu = new GPU();
			}
			if (wifi == null) {
				wifi = new WiFi();
			}

			Bluetooth = bluetooth;
			CPU = cpu;
			GPU = gpu;
			WiFi = wifi;
			Model = model;
			Manufacturer = manufacturer;
			YearOfProduction = yearOfProduction;
			Version = version;

		}

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}

	}
}
