using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

using OS = Core.OperatingSystem;

namespace Core {
	public class MobilePhone : ICommonDescription, IMobilePhone {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public PhoneBootState PhoneBootState { get; set; }

		#region Software components
		public Recovery Recovery { get; set; }
		public Bootloader Bootloader { get; set; }
		public OS OperatingSystem { get; set; }
		#endregion
		#region Hardware Components
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
		#endregion
		public void PressPowerButton(int secondsButtonBeingHold = 1) {
			if (secondsButtonBeingHold <= 0) {
				throw new ArgumentException("Button cannot be hold for ZERO or NEGATIVE number of seconds");
			}

			BootPhone();
		}

		protected void BootPhone() {
			if (IsHardwareComponentsOK()) {
				SelectSoftwareState();
			}
		}
		public bool IsHardwareComponentsOK() {
			if (Chipset == null
				|| !IsRAM_OK()
				|| !IsInternalStorageOK()
				|| !IsExternalStorageOK()) {
				return false;
			}
			return true;
		}
		protected bool IsRAM_OK() {
			if (RAM == null
				|| RAM.Capacity <= 0) {
				return false;
			}
			return true;
		}
		protected bool IsInternalStorageOK() {
			if (InternalStorage == null
				&& ExternalStorage == null) {
				return false;
			}
			return true;
		}
		protected bool IsExternalStorageOK() {
			if (InternalStorage.Capacity <= 0
				&& ExternalStorage.Capacity <= 0) {
				return false;
			}
			return true;
		}
		//public bool IsSoftwareComponentsOK() {
		//	if (Recovery == null
		//		&& Bootloader == null
		//		&& OperatingSystem == null) {
		//		return false;
		//	}
		//	return true;
		//}
		protected void SelectSoftwareState() {
			if (Recovery != null) {
				PhoneBootState = PhoneBootState.Recovery;
				if (Bootloader != null) {
					PhoneBootState = PhoneBootState.Bootloader;
					if (OperatingSystem != null) {
						PhoneBootState = PhoneBootState.System;
					}
				}
			} else {
				PhoneBootState = PhoneBootState.Off;
			}
		}

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}
