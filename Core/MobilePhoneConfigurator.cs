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
			//List<SimCard> simCards;
			IDisplay display;
			Button powerButton;
			NetworkModule networkModule;
			//IAudioInputDevice audioInputDevice;
			//IAudioOutputDevice audioOutputDevice;
			Battery battery; //IPowerSource
			RAM ram;
			Storage internalStorage;
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
					//wiFi = new WiFi();
					//bluetooth = new Bluetooth();

					mobilePhone.Chipset = chipset;
					mobilePhone.Screen = display;
					mobilePhone.PowerButton = powerButton;
					mobilePhone.Battery = battery;
					mobilePhone.NetworkModule = networkModule;
					mobilePhone.RAM = ram;
					mobilePhone.InternalStorage = internalStorage;
					break;
				default:
					throw new NotImplementedException();
			}
			return mobilePhone;
		}
		private static IMobilePhone AssemblePartsTogether(IMobilePhone mobilePhone, IChipset chipset, RAM ram) {
			return new MobilePhone();
		}
	}
}