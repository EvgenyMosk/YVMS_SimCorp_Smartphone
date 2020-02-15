using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class Battery : ICommonDescription {
		public String Model { get; set; }
		public String Manufacturer { get; set; }
		public Int32 YearOfProduction { get; set; }
		public String Version { get; set; }

		public String GetDescription() {
			throw new NotImplementedException();
		}
	}
}