using System;

namespace Core {
	public abstract class ProcessingUnit : ICommonDescription {
		public string Model { get; set; }
		public double Frequency { get; set; }
		public int ThrottleTemperature { get; set; }
		public int CriticalTemperature { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}
