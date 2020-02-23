using Core;
using Core.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YVMS_SC.Core {
	public class MobilePhone : ICommonDescription {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public PhoneBootState PhoneBootState { get; set; }


		//	Software components
		public Recovery Recovery { get; set; }
		public Bootloader Bootloader { get; set; }
		public OperatingSystem OperatingSystem { get; set; }

		//	Hardware components
		public Chipset Chipset { get; set; }
		public List<SimCard> SimCards { get; set; }
		public NotificationLight NotificationLight { get; set; }
		public Screen Screen { get; set; } //===
		public Button PowerButton { get; set; } // ===
		public NetworkModule NetworkModule { get; set; }
		public IAudioInputDevice InternalAudioInputDevice { get; set; }
		public IAudioOutputDevice InternalAudioOutputDevice { get; set; }
		public Battery Battery { get; set; }
		public RAM RAM { get; set; }
		public Storage InternalStorage { get; set; }
		public SdCard ExternalStorage { get; set; } // ===
		public Case Case { get; set; }
		public FaceScanner FaceScanner { get; set; } // ===
		public FingerprintScanner FingerprintScanner { get; set; } // ===
		public RetinaScanner RetinaScanner { get; set; } // ===
		public ProximitySensor ProximitySensor { get; set; }
		public LightSensor LightSensor { get; set; }
		public List<CameraModule> CameraModules { get; set; }
		public WiFi WiFi { get; set; }
		public Bluetooth Bluetooth { get; set; }


		public void PressPowerButton(int secondsButtonBeingHold) {

		}

		protected void BootPhone() {
			if (Chipset == null) {
				return;
			}
		}

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}
