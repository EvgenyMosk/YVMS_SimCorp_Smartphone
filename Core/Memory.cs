using System;

namespace Core {
	public abstract class Memory : ICommonDescription {
		public string Manufacturer { get; set; }
		public string Model { get; set; }
		public int Capacity { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}
