using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class ChipsetFactory {
		public static Chipset CreateNewChipset() {
			CPU snapdragon400 = new CPU {
				Cores = 4,
				CriticalTemperature = 60,
				ThrottleTemperature = 50,
				Frequency = 1.2,
				Lithography = 28,
				Model = "A7",
				Manufacturer = "Cortex",
				YearOfProduction = 2015,
				Version = ""
			};

			GPU adreno305 = new GPU();

			Bluetooth bluetooth = new Bluetooth();

			WiFi wifi = new WiFi();

			throw new NotImplementedException();
		}
	}
}