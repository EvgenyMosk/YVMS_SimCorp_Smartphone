using System;

namespace Core
{
	public class Chipset : ICommonDescription
	{
		public String Model { get; set; }
		public String Manufacturer { get; set; }
		public Int32 YearOfProduction { get; set; }
		public String Version { get; set; }

		public String GetDescription()
		{
			throw new NotImplementedException();
		}

		protected class ProcessingUnit : ICommonDescription
		{
			public String Model { get; set; }
			public Int32 CoreClock { get; set; }
			public Int32 ThrottleTemperature { get; set; }
			public Int32 CriticalTemperature { get; set; }
			public String Manufacturer { get; set; }
			public Int32 YearOfProduction { get; set; }
			public String Version { get; set; }

			public String GetDescription()
			{
				throw new NotImplementedException();
			}
		}
		protected class CPU : ProcessingUnit
		{

		}
		protected class GPU : ProcessingUnit
		{

		}
		protected abstract class WirelessConnectionModule : PowerableComponent, ICommonDescription
		{
			protected System.Boolean _isTurnedOn;

			public String Model { get; set; }
			public String Manufacturer { get; set; }
			public Int32 YearOfProduction { get; set; }
			public String Version { get; set; }

			public String GetDescription()
			{
				throw new NotImplementedException();
			}

			public void TurnOff()
			{
			}

			public void TurnOn()
			{
			}
		}
		protected class WiFi : WirelessConnectionModule
		{

		}
		protected class Bluetooth : WirelessConnectionModule
		{

		}
		protected class NFC : WirelessConnectionModule
		{

		}
	}
}
