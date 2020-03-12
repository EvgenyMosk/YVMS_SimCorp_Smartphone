using System;

namespace Core {
	public abstract class WirelessConnectionModule : IPowerable, ICommonDescription {
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
			_isTurnedOn = false;
		}

		public void TurnOn() {
			_isTurnedOn = true;
		}

		public abstract void ConnectToDevice();
	}
}
