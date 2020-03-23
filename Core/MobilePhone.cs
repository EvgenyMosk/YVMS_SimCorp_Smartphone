using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

using OS = Core.OperatingSystem;

namespace Core {
	public class MobilePhone : IMobilePhone {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; protected set; }

		#region Software components
		public OS OperatingSystem { get; set; }
		public PhoneBootState PhoneBootState { get; set; }
		#endregion
		#region Hardware Components
		public IChipset Chipset { get; set; }
		public IAudioOutputDevice AudioOutputDevice { get; set; }
		public IMemory InternalStorage { get; set; }
		#endregion
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
				|| !IsInternalStorageOK()) {
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
		protected virtual void SelectSoftwareState() {
			if (OperatingSystem != null) {
				PhoneBootState = PhoneBootState.System;
			} else {
				PhoneBootState = PhoneBootState.Off;
			}
		}

		public void AudioOutputPlayAudioFile(string audioFile) {
			if (AudioOutputDevice == null) {
				return;
			}
			AudioOutputDevice.PlayFile(audioFile);
		}
		public void AudioOutputStopPlayingAudioFile() {
			if (AudioOutputDevice == null) {
				return;
			}
			AudioOutputDevice.StopPlayingAudio();
		}
		public void AudioOutputChangeVolume(int delta) {
			if (AudioOutputDevice == null) {
				return;
			}
			AudioOutputDevice.ChangeVolume(delta);
		}

		public override string ToString() {
			StringBuilder mobilePhoneDescription = new StringBuilder();

			mobilePhoneDescription.AppendLine(Manufacturer + " " + Model + " (" + YearOfProduction + ")");

			// Loop through Properties of a MobilePhone
			foreach (PropertyInfo property in GetType().GetProperties()) {
				LoopThroughPropertyInterfaces_Helper(mobilePhoneDescription, property);
			}

			return mobilePhoneDescription.ToString();
		}
		private void LoopThroughPropertyInterfaces_Helper(StringBuilder mobilePhoneDescription, PropertyInfo property) {
			Type propertyType = property.PropertyType;

			// Loop through Interfaces that Property implements
			foreach (Type interfaceThatPropImpl in propertyType.GetInterfaces()) {
				// If there is ICommonDescription among them - Get it's values:
				// Model, Manufacturer, YearOfProduction, Version
				if (interfaceThatPropImpl.Name.Equals(nameof(ICommonDescription))) {
					AppendDescription_Helper(mobilePhoneDescription, property);
				}
			}
		}
		private void AppendDescription_Helper(StringBuilder mobilePhoneDescription, PropertyInfo property) {
			string propertyValue = property.GetValue(this, null)?.ToString();

			if (!string.IsNullOrWhiteSpace(propertyValue)) {
				mobilePhoneDescription.AppendLine("  >> " + property.Name + " <<");
				mobilePhoneDescription.AppendLine(propertyValue);
			}
		}
	}
}