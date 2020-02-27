using System;
using System.Collections.Generic;

namespace Core {
	public abstract class Memory : ICommonDescription, IMemory {
		public string Manufacturer { get; set; }
		public string Model { get; set; }
		public int Capacity { get; set; }
		public int AllocatedMemoryAmount { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }
		public int UsedSpace { get; set; }

		public Memory() : this("Manufacturer", "Model", 1024, 2000, "v.1.0") {
		}

		protected Memory(string manufacturer, string model, int capacity, int? yearOfProduction, string version) {
			Manufacturer = manufacturer;
			Model = model;
			Capacity = capacity;
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
