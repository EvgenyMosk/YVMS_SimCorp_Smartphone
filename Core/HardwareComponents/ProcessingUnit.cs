using System;

namespace Core {
	public abstract class ProcessingUnit : ICommonDescription {
		public string Model { get; }
		public double FrequencyMax { get; protected set; }
		public double FrequencyCurrent { get; protected set; }
		public int ThrottleTemperature { get; protected set; }
		public int CriticalTemperature { get; protected set; }
		public string Manufacturer { get; }
		public int? YearOfProduction { get; }
		public string Version { get; set; }
		protected ProcessingUnit(string model, string manufacturer, double frequencyMax, int throttleTemperature, int criticalTemperature, int? yearOfProduction, string version) {
			Model = model;
			Manufacturer = manufacturer;
			FrequencyMax = frequencyMax;
			FrequencyCurrent = 0;
			ThrottleTemperature = throttleTemperature;
			CriticalTemperature = criticalTemperature;
			YearOfProduction = yearOfProduction;
			Version = version;
		}
		public override string ToString() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}
