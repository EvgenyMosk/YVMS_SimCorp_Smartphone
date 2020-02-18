using System;
using System.Drawing;

namespace Core
{
	public abstract class Light : IPowerableComponent, ICommonDescription
	{
		protected Boolean _isTurnedOn;
		public Double PhysicalModuleRadius { get; set; }
		public Color Color { get; set; }
		public Int32 LightPower { get; set; }
		public String Model { get; set; }
		public String Manufacturer { get; set; }
		public Int32 YearOfProduction { get; set; }
		public String Version { get; set; }

		public String GetDescription()
		{
			throw new System.NotImplementedException();
		}

		public void TurnOff()
		{
			throw new System.NotImplementedException();
		}

		public void TurnOn()
		{
			throw new System.NotImplementedException();
		}
	}
}
