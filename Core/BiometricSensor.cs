using System;

namespace Core {
	public abstract class BiometricSensor : IPowerableComponent, ICommonDescription {
		protected Boolean _isTurnedOn;

		public String Model { get; set; }
		public String Manufacturer { get; set; }
		public Int32 YearOfProduction { get; set; }
		public String Version { get; set; }

		public String GetDescription() {
			throw new System.NotImplementedException();
		}

		public void TurnOff() {
			throw new System.NotImplementedException();
		}

		public void TurnOn() {
			throw new System.NotImplementedException();
		}
	}
}
