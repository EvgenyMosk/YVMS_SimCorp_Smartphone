using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public class ChipsetFactory {
		public static IChipset CreateChipset(PresetsChipsets presetChipset) {
			CPU snapdragon400 = new CPU {
				Cores = 4,
				CriticalTemperature = 60,
				ThrottleTemperature = 50,
				FrequencyMax = 1.2,
				FrequencyCurrent = 0.0,
				Lithography = 28,
				Model = "A7",
				Manufacturer = "Cortex",
				YearOfProduction = 2015,
				Version = ""
			};
			GPU adreno305 = new GPU();
			WiFi wifi = new WiFi();
			Bluetooth bluetooth = new Bluetooth();

			string model = "Snapdragon 400";
			string manufacturer = "Qualcomm";
			int yearOfProduction = 2015;
			string version = "1.1";

			IChipset chipset;

			switch (presetChipset) {
				case PresetsChipsets.Snapdragon400:
					chipset = new Chipset(snapdragon400, adreno305, wifi, bluetooth, model, manufacturer, yearOfProduction, version);
					break;
				default:
					throw new NotImplementedException();
			}

			return chipset;
		}
		public static IChipset CreateChipset() {
			return new Chipset();
		}
	}
}