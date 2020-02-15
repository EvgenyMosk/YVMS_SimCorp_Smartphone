using System;

namespace Core
{
	public abstract class Memory : ICommonDescription
	{
		public String Manufacturer { get; set; }
		public String Model { get; set; }
		public Int32 Capacity { get; set; }
		public Int32 YearOfProduction { get; set; }
		public String Version { get; set; }

		public String GetDescription()
		{
			throw new NotImplementedException();
		}
	}
}
