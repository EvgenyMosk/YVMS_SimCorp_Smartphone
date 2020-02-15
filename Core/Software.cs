using System;

namespace Core
{
	public abstract class Software : ICommonDescription
	{
		public Int32 SpaceRequired { get; set; }
		public String Model { get; set; }
		public String Manufacturer { get; set; }
		public Int32 YearOfProduction { get; set; }
		public String Version { get; set; }

		public String GetDescription()
		{
			throw new NotImplementedException();
		}
	}
}
