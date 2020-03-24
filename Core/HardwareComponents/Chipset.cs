using System;

namespace Core {
	public class Chipset : ICommonDescription, IChipset {
		public string Model { get; }
		public string Manufacturer { get; }
		public int? YearOfProduction { get; }
		public string Version { get; set; }

		public CPU CPU { get; }
		public Chipset(
			CPU cpu,
			string model = "CHIPSET_MODEL",
			string manufacturer = "CHIPSET_MANUFACTURER",
			int? yearOfProduction = null,
			string version = "VERSION_PREALPHA") {
			if (cpu == null) {
				throw new ArgumentNullException(nameof(cpu));
			}

			CPU = cpu;
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