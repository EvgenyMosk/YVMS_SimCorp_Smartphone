using Core.Enums;
using System;

namespace Core
{
	public class Screen : PowerableComponent
	{
		protected bool _isTurnedOn;
		public Int32 HorizontalResolution { get; set; }

		public Int32 VerticalResolution { get; set; }

		public DisplayType DisplayType { get; set; }

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
