using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Interfaces;
using Core.SoftwareComponents;

namespace PhonePlayerBusinessLogic {
	public class PhoneControl {
		public IMobilePhone MobilePhone { get; set; }

		public PhoneControl(IMobilePhone mobilePhone, IAudioOutputDevice audioOutputDevice, IOutput audioDeviceOutput) {
			if (mobilePhone == null) {
				throw new ArgumentNullException(nameof(mobilePhone));
			}
			MobilePhone = mobilePhone;

			MobilePhone.AudioOutputDevice = audioOutputDevice;

			if (mobilePhone.AudioOutputDevice != null) {
				MobilePhone.AudioOutputDevice.Output = audioDeviceOutput;
			}
		}
		public virtual void PlayAudio(string audioFile) {
			if (MobilePhone.AudioOutputDevice == null || string.IsNullOrWhiteSpace(audioFile)) {
				return;
			}
			MobilePhone.AudioOutputDevice.PlayFile(audioFile);
		}
		public virtual string PlayAudioAndReturnString(string audioFile) {
			if (MobilePhone.AudioOutputDevice == null || string.IsNullOrWhiteSpace(audioFile)) {
				return string.Empty;
			}
			return MobilePhone.AudioOutputDevice.PlayFileAndReturnString(audioFile);
		}
		public virtual void StopPlayingAudio() {
			if (MobilePhone.AudioOutputDevice == null) {
				return;
			}
			MobilePhone.AudioOutputDevice.StopPlayingAudio();
		}
	}
}