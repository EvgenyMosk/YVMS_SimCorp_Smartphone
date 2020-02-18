using System;

namespace Core {
	public class ProcessingUnit : ICommonDescription {
		public String Model { get; set; }
		public Int32 CoreClock { get; set; }
		public Int32 ThrottleTemperature { get; set; }
		public Int32 CriticalTemperature { get; set; }
		public String Manufacturer { get; set; }
		public Int32 YearOfProduction { get; set; }
		public String Version { get; set; }

		public String GetDescription() {
			throw new NotImplementedException();
		}
	}
}
