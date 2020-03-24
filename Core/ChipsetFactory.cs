using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public class ChipsetFactory {
		public static IChipset CreateChipset(PresetsChipsets presetChipset) {
			int cpu_cores = 4;
			int cpu_criticalTemperature = 60;
			int cpu_throttleTemperature = 50;
			double cpu_fequencyMax = 1.2;
			int cpu_lithography = 28;
			string cpu_model = "A7";
			string cpu_manufacturer = "Cortex";
			int cpu_yearOfProduction = 2015;
			string cpu_version = "v.1.0";



			CPU snapdragon400 = new CPU(cpu_model,
				cpu_manufacturer, cpu_fequencyMax,
				cpu_throttleTemperature, cpu_criticalTemperature,
				cpu_yearOfProduction, cpu_version,
				cpu_cores, cpu_lithography);

			string model = "Snapdragon 400";
			string manufacturer = "Qualcomm";
			int yearOfProduction = 2015;
			string version = "1.1";

			IChipset chipset;

			switch (presetChipset) {
				case PresetsChipsets.Snapdragon400:
					chipset = new Chipset(snapdragon400, model, manufacturer, yearOfProduction, version);
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