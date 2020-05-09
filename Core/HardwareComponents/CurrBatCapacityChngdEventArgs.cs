using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HardwareComponents {
	public class CurrBatCapacityChngdEventArgs : EventArgs {
		public int CurrentBatteryCapacity { get; set; }
		public CurrBatCapacityChngdEventArgs(int currentBatteryCapacity) {
			CurrentBatteryCapacity = currentBatteryCapacity;
		}
	}
}