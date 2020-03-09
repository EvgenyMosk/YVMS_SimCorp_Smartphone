using System.Collections.Generic;

using Core.Enums;

namespace Core {
	public interface IMobilePhone : ICommonDescription {
		// Software
		PhoneBootState PhoneBootState { get; set; }
		Recovery Recovery { get; set; }
		Bootloader Bootloader { get; set; }
		OperatingSystem OperatingSystem { get; set; }

		// Hardware
		IChipset Chipset { get; set; }
		List<SimCard> SimCards { get; set; }
		//NotificationLight NotificationLight { get; set; }
		IDisplay Screen { get; set; } //===
		Button PowerButton { get; set; } // ===
		NetworkModule NetworkModule { get; set; }
		IAudioInputDevice InternalAudioInputDevice { get; set; }
		IAudioOutputDevice InternalAudioOutputDevice { get; set; }
		IPowerSource Battery { get; set; }
		RAM RAM { get; set; }
		Storage InternalStorage { get; set; }
		//SdCard ExternalStorage { get; set; } // ===
		Case Case { get; set; }
		//FaceScanner FaceScanner { get; set; } // ===
		//FingerprintScanner FingerprintScanner { get; set; } // ===
		//RetinaScanner RetinaScanner { get; set; } // ===
		//ProximitySensor ProximitySensor { get; set; }
		//LightSensor LightSensor { get; set; }
		//List<CameraModule> CameraModules { get; set; }
		//WiFi WiFi { get; set; }
		//Bluetooth Bluetooth { get; set; }
	}
}