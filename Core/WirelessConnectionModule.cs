using System;

namespace Core {
	public abstract class WirelessConnectionModule : IPowerableComponent, ICommonDescription {
		protected System.Boolean _isTurnedOn;

		public String Model { get; set; }
		public String Manufacturer { get; set; }
		public Int32 YearOfProduction { get; set; }
		public String Version { get; set; }

		public String GetDescription() {
			throw new NotImplementedException();
		}

		public void TurnOff() {
		}

		public void TurnOn() {
		}
	}
}
