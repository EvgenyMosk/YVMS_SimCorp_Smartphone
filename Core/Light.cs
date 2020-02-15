using System.Drawing;

namespace Core
{
	public abstract class Light : PowerableComponent
	{
		protected bool _isTurnedOn;
		public double PhysicalModuleRadius { get; set; }
		public Color Color { get; set; }
		public int LightPower { get; set; }

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
