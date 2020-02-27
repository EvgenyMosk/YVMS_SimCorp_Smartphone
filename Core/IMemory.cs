using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public interface IMemory {
		int Capacity { get; set; }
		int UsedSpace { get; set; }
	}
}