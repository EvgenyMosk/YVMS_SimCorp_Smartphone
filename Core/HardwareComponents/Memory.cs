using System;
using System.Collections.Generic;

namespace Core {
	public class Memory : ICommonDescription, IMemory {
		public string Manufacturer { get; set; }
		public string Model { get; set; }
		public int Capacity { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }
		public int UsedSpace { get; set; }

		public Memory(string manufacturer, string model, int capacity, int? yearOfProduction, string version) {
			Manufacturer = manufacturer;
			Model = model;
			Capacity = capacity;
			YearOfProduction = yearOfProduction;
			Version = version;
		}

		public Memory(string model, string manufacturer, int capacity, int usedSpace, int? yearOfProduction, string version) {
			Model = model;
			Manufacturer = manufacturer;
			Capacity = capacity;
			UsedSpace = usedSpace;
			YearOfProduction = yearOfProduction;
			Version = version;
		}

		public override string ToString() {
			return DescriptionFormatter.CreateDescription(this);
		}
	}
}
