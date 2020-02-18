using System;

namespace Core {
	public abstract class Sensor : IPowerable, ICommonDescription {
		protected bool _isTurnedOn;

		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}

		public void TurnOff() {
			throw new System.NotImplementedException();
		}

		public void TurnOn() {
			throw new System.NotImplementedException();
		}
	}
}
