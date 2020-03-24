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

		public Memory(string model, string manufacturer, int? yearOfProduction, string version, int capacity) {
			Model = model;
			Manufacturer = manufacturer;
			YearOfProduction = yearOfProduction;
			Version = version;
			Capacity = capacity;
			UsedSpace = 0;
		}

		public override string ToString() {
			return DescriptionFormatter.CreateDescription(this);
		}
	}
}
