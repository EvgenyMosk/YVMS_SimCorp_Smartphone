using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public abstract class Memory {
		public String Manufacturer { get; set; }
		public String Model { get; set; }
		public Int32 Capacity { get; set; }
	}
}
