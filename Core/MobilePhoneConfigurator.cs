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

			IDisplay display;
			Button powerButton;
			NetworkModule networkModule;

			Battery battery; //IPowerSource
			RAM ram;
			Storage internalStorage;
			//List<SimCard> simCards;
			//IAudioInputDevice audioInputDevice;
			//IAudioOutputDevice audioOutputDevice;
			//SdCard sdCard;
			//ProximitySensor proximitySensor;
			//LightSensor lightSensor;
			//List<CameraModule> cameras;
			//WiFi wiFi;
			//Bluetooth bluetooth;

			switch (presetPhone) {
				case PresetsPhones.MicrosoftLumia640XL:
					/// TODO: Move to separate methods
					chipset = ChipsetFactory.CreateChipset(PresetsChipsets.Snapdragon400);
					display = new Screen();
					powerButton = new Button();
					battery = new Battery();
					networkModule = new NetworkModule();
					ram = new RAM();
					internalStorage = new Storage();

					mobilePhone.Chipset = chipset;
					mobilePhone.Screen = display;
					mobilePhone.PowerButton = powerButton;
					mobilePhone.Battery = battery;
					mobilePhone.NetworkModule = networkModule;
					mobilePhone.RAM = ram;
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
		/// TODO: Create a method that will take mobilePhone and add a custom object to it
		//private static IMobilePhone AssemblePartsTogether(IMobilePhone mobilePhone, IChipset chipset, RAM ram) {
		//	return new MobilePhone();
		//}
		private static void InstallEssentialSoftware(IMobilePhone mobilePhone) {
			if (mobilePhone == null) {
				throw new ArgumentNullException("Cannot install Software when mobilePhone is null!");
			}
			InstallRecovery(mobilePhone);
			InstallBootloader(mobilePhone);
			InstallOperatingSystem(mobilePhone);
		}
		public static void InstallRecovery(IMobilePhone mobilePhone) {
			if (mobilePhone == null) {
				throw new ArgumentNullException("Cannot install Recovery when mobilePhone is null!");
			}
			mobilePhone.Recovery = new Recovery();
		}
		public static void InstallBootloader(IMobilePhone mobilePhone) {
			if (mobilePhone == null) {
				throw new ArgumentNullException("Cannot install Bootloader when mobilePhone is null!");
			}
			mobilePhone.Bootloader = new Bootloader();
		}
		public static void InstallOperatingSystem(IMobilePhone mobilePhone) {
			if (mobilePhone == null) {
				throw new ArgumentNullException("Cannot install OS when mobilePhone is null!");
			}
			mobilePhone.OperatingSystem = new OperatingSystem();
		}
	}
}