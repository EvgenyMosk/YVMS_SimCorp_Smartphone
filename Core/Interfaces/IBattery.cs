using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.HardwareComponents;

namespace Core.Interfaces {
	public interface IBattery : ICommonDescription {
		event EventHandler<CurrBatCapacityChngdEventArgs> CurrentCapacityChanged;
		int MaximumCapacity { get; }
		int CurrentChargePercentage { get; }
		void ChangeCurrentCapacity(int delta);
	}
}