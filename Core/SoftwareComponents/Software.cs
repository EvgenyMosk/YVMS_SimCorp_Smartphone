using System;

namespace Core.SoftwareComponents {
	public abstract class Software : ICommonDescription {
		public int Size { get; set; }
		public string Model { get; }
		public string Manufacturer { get; }
		public int? YearOfProduction { get; }
		public string Version { get; set; }

		protected Software(string model, string manufacturer, int? yearOfProduction, string version, int size) {
			Model = model;
			Manufacturer = manufacturer;
			YearOfProduction = yearOfProduction;
			Version = version;
			Size = size;
		}

		public override string ToString() {
			return DescriptionFormatter.CreateDescription(this);
		}
	}
}