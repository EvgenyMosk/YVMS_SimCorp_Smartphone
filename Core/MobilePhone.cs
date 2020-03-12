using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

using OS = Core.OperatingSystem;

namespace Core {
	public class MobilePhone : IMobilePhone {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		#region Software components
		public Recovery Recovery { get; set; }
		public Bootloader Bootloader { get; set; }
		public OS OperatingSystem { get; set; }
		public PhoneBootState PhoneBootState { get; set; }
		#endregion
		#region Hardware Components
		public IChipset Chipset { get; set; }
		public List<SimCard> SimCards { get; set; }
		//public NotificationLight NotificationLight { get; set; }
		public IDisplay Screen { get; set; } //===
		public Button PowerButton { get; set; } // ===
		public NetworkModule NetworkModule { get; set; }
		public IAudioInputDevice AudioInputDevice { get; set; }
		public IAudioOutputDevice<object> AudioOutputDevice { get; set; }
		public IPowerSource Battery { get; set; }
		public RAM RAM { get; set; }
		public Storage InternalStorage { get; set; }
		//public SdCard ExternalStorage { get; set; } // ===
		public Case Case { get; set; }
		//public FaceScanner FaceScanner { get; set; } // ===
		//public FingerprintScanner FingerprintScanner { get; set; } // ===
		//public RetinaScanner RetinaScanner { get; set; } // ===
		//public ProximitySensor ProximitySensor { get; set; }
		//public LightSensor LightSensor { get; set; }
		//public List<CameraModule> CameraModules { get; set; }
		//public WiFi WiFi { get; set; }
		//public Bluetooth Bluetooth { get; set; }
		#endregion
		/// TODO: Refactor to reflect how many seconds the user holds the button and to support turning screen of/off
		public virtual void PressPowerButton(int secondsButtonBeingHold = 1) {
			if (secondsButtonBeingHold <= 0) {
				throw new ArgumentException("Button cannot be hold for ZERO or NEGATIVE number of seconds");
			} else if (secondsButtonBeingHold >= 2) {
				BootPhone();
			}
		}

		protected void BootPhone() {
			if (IsHardwareComponentsOK()) {
				SelectSoftwareState();
			}
		}
		public virtual bool IsHardwareComponentsOK() {
			if (Chipset == null
				|| !IsRAM_OK()
				|| !IsInternalStorageOK()) {
				//|| !IsExternalStorageOK()) {
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
				&& InternalStorage.Capacity <= 0) {
				return false;
			}
			return true;
		}
		//protected bool IsExternalStorageOK() {
		//	if (ExternalStorage == null
		//		&& ExternalStorage.Capacity <= 0) {
		//		return false;
		//	}
		//	return true;
		//}
		//public bool IsSoftwareComponentsOK() {
		//	if (Recovery == null
		//		&& Bootloader == null
		//		&& OperatingSystem == null) {
		//		return false;
		//	}
		//	return true;
		//}
		protected virtual void SelectSoftwareState() {
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

		public void AudioOutputDevicePlayAudioFile(string audioFile) {
			if (AudioOutputDevice == null) {
				return;
			}
			AudioOutputDevice.PlayFile(audioFile);
		}

		public void AudioOutputDeviceChangeVolume(int delta) {
			if (AudioOutputDevice == null) {
				return;
			}
			AudioOutputDevice.ChangeVolume(delta);
		}
		public virtual string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}
