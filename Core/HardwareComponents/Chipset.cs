using System;

namespace Core {
	public class Chipset : ICommonDescription, IChipset {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public CPU CPU { get; set; }
		public GPU GPU { get; set; }

		public Chipset() : this(null, null) { }
		public Chipset(
			CPU cpu,
			GPU gpu,
			string model = "CHIPSET_MODEL",
			string manufacturer = "CHIPSET_MANUFACTURER",
			int? yearOfProduction = null,
			string version = "VERSION_PREALPHA") {
			if (cpu == null) {
				cpu = new CPU();
			}
			if (gpu == null) {
				gpu = new GPU();
			}

			CPU = cpu;
			GPU = gpu;
			Model = model;
			Manufacturer = manufacturer;
			YearOfProduction = yearOfProduction;
			Version = version;
		}

		public override string ToString() {
			return DescriptionFormatter.CreateDescription(this);
		}
	}
}