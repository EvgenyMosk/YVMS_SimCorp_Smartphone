using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;

namespace PhonePlayerBusinessLogic {
    public class PhoneControl {
        public IMobilePhone mobilePhone { get; set; }
        public PhoneControl(IMobilePhone mobilePhone, IAudioOutputDevice audioOutputDevice, IOutput audioDeviceOutput) {
            if (mobilePhone == null) {
                throw new ArgumentNullException(nameof(mobilePhone));
            }
            this.mobilePhone = mobilePhone;

            this.mobilePhone.AudioOutputDevice = audioOutputDevice;

            if (mobilePhone.AudioOutputDevice != null) {
                this.mobilePhone.AudioOutputDevice.Output = audioDeviceOutput;
            }
        }
        public virtual void PlayAudio(string audioFile) {
            if (mobilePhone.AudioOutputDevice == null || string.IsNullOrWhiteSpace(audioFile)) {
                return;
            }
            mobilePhone.AudioOutputDevice.PlayFile(audioFile);
        }
        public virtual string PlayAudioAndReturnString(string audioFile) {
            if (mobilePhone.AudioOutputDevice == null || string.IsNullOrWhiteSpace(audioFile)) {
                return string.Empty;
            }
            return mobilePhone.AudioOutputDevice.PlayFileAndReturnString(audioFile);
        }
        public virtual void StopPlayingAudio() {
            if (mobilePhone.AudioOutputDevice == null) {
                return;
            }
            mobilePhone.AudioOutputDevice.StopPlayingAudio();
        }
        public virtual void EnableNotifications(IOutput notificationsOutput) {
            mobilePhone.EnableNotifications(notificationsOutput);
        }
        public virtual void DisableNotifications() {
            mobilePhone.DisableNotifications();
        }
    }
}