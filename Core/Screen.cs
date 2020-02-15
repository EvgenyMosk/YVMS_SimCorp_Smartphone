using Core.Enums;
using System;

namespace Core
{
	public class Screen : PowerableComponent, ICommonDescription
	{
		protected Boolean _isTurnedOn;
		public Int32 HorizontalResolution { get; set; }

		public Int32 VerticalResolution { get; set; }

		public DisplayType DisplayType { get; set; }
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
			throw new NotImplementedException();
		}

		public void TurnOn()
		{
			throw new NotImplementedException();
		}
	}
}
