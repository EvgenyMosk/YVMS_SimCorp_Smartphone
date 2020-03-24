using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public static class MobilePhoneConfigurator {
		public static IMobilePhone CreateMobilePhone(PresetsPhones presetPhone) {
			IMobilePhone mobilePhone;
			IChipset chipset;
			IMemory internalStorage;

			switch (presetPhone) {
				case PresetsPhones.MicrosoftLumia640XL:
					/// TODO: Move to separate methods
					chipset = ChipsetFactory.CreateChipset(PresetsChipsets.Snapdragon400);

					// Create information about memory
					string model = "eMMC";
					string manufacturer = "Micron";
					int yearOfProduction = 2015;
					string version = "v.1.0";
					int capacity = 8192;

					internalStorage = new Memory(model, manufacturer, yearOfProduction, version, capacity);

					// Create information about phone itself
					model = "Lumia 640 XL";
					manufacturer = "Microsoft";
					yearOfProduction = 2015;
					version = "v.1.2";

					mobilePhone = new MobilePhone(model, manufacturer, chipset, yearOfProduction, version);

					// Create information about OS
					model = "Windows 10 Mobile";
					manufacturer = "Microsoft";
					yearOfProduction = 2015;
					version = "10.493";
					int size = 1456;

					InstallOperatingSystem(mobilePhone, model, manufacturer, yearOfProduction, version, size);

					break;
				default:
					throw new NotImplementedException();
			}
			return mobilePhone;
		}
		public static void InstallOperatingSystem(IMobilePhone mobilePhone, string model, string manufacturer, int? yearOfProduction, string version, int size) {
			if (mobilePhone == null) {
				throw new ArgumentNullException("Cannot install OS when mobilePhone is null!");
			}
			mobilePhone.OperatingSystem = new OperatingSystem(model, manufacturer, yearOfProduction, version, size);
		}
	}
}