using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public static class MobilePhoneConfigurator {
		public static IMobilePhone CreateMobilePhone(PresetsPhones presetPhone) {
			IMobilePhone mobilePhone = new MobilePhone();

			IChipset chipset;

			IMemory internalStorage;

			switch (presetPhone) {
				case PresetsPhones.MicrosoftLumia640XL:
					/// TODO: Move to separate methods
					chipset = ChipsetFactory.CreateChipset(PresetsChipsets.Snapdragon400);
					internalStorage = new Memory("Micron", "LPDDR3", 8192, 2015, "v.1.0");

					mobilePhone.Chipset = chipset;
					mobilePhone.InternalStorage = internalStorage;

					mobilePhone.Model = "Lumia 640 XL";
					mobilePhone.Manufacturer = "Microsoft";
					mobilePhone.YearOfProduction = 2015;

					InstallEssentialSoftware(mobilePhone);
					mobilePhone.OperatingSystem.Model = "Windows 10 Mobile";
					mobilePhone.OperatingSystem.Manufacturer = "Microsoft";
					mobilePhone.OperatingSystem.Version = "10.493";
					break;
				default:
					throw new NotImplementedException();
			}
			return mobilePhone;
		}
		private static void InstallEssentialSoftware(IMobilePhone mobilePhone) {
			if (mobilePhone == null) {
				throw new ArgumentNullException("Cannot install Software when mobilePhone is null!");
			}
			InstallOperatingSystem(mobilePhone);
		}
		public static void InstallOperatingSystem(IMobilePhone mobilePhone) {
			if (mobilePhone == null) {
				throw new ArgumentNullException("Cannot install OS when mobilePhone is null!");
			}
			mobilePhone.OperatingSystem = new OperatingSystem();
		}
	}
}