using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.HardwareComponents;
using Core.Interfaces;
using Core.SoftwareComponents;

namespace PhonePlayerBusinessLogic {
	public class PhoneControl : IDisposable {
		private int _dischargeRateMah;// = -20;
		private int _chargeRateMah;// = 100;
		public IMobilePhone MobilePhone { get; set; }
		private CancellationTokenSource _cancellationTokenChargePhone;
		private CancellationTokenSource _cancellationTokenDischargePhone;
		private bool disposed = false;
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

		public void SetBatteryRates(int chargeRate, int dischargeRate) {
			if (chargeRate == 0 || dischargeRate == 0) {
				throw new ArgumentException("Phone cannot be charged or discharged with zero rate!");
			}

			_chargeRateMah = Math.Abs(chargeRate);
			_dischargeRateMah = Math.Abs(dischargeRate) * -1; // Make sure it's always negative
		}
		public void ResetCharging() {
			_cancellationTokenChargePhone?.Cancel();
			_cancellationTokenChargePhone = new CancellationTokenSource();

			_cancellationTokenDischargePhone?.Cancel();
			_cancellationTokenDischargePhone = new CancellationTokenSource();
		}
		public void PlugPhoneToPowerSource() {
			if (_cancellationTokenDischargePhone != null) {
				_cancellationTokenDischargePhone.Cancel();
				_cancellationTokenDischargePhone = null;

				_cancellationTokenChargePhone = new CancellationTokenSource();
				ChargePhone(_cancellationTokenChargePhone.Token);
			} else {
				throw new Exception("This token cannot be null at this time!");
			}
		}
		public void UnplugPhoneFromPowerSource() {
			if (_cancellationTokenChargePhone != null) {
				_cancellationTokenChargePhone.Cancel();
				_cancellationTokenChargePhone = null;

				_cancellationTokenDischargePhone = new CancellationTokenSource();
				DischargePhone(_cancellationTokenDischargePhone.Token);
			} else {
				throw new Exception("This token cannot be null at this time!");
			}
		}

		private void DischargePhone(CancellationToken cancellationToken) {
			Task.Run(() => {
				while (MobilePhone.Battery.CurrentChargePercentage > 0
				&& !cancellationToken.IsCancellationRequested) {
					Thread.Sleep(1000);
					MobilePhone.Battery.ChangeCurrentCapacity(_dischargeRateMah);
				}
			}, cancellationToken);
		}
		private void ChargePhone(CancellationToken cancellationToken) {
			Task.Run(() => {
				while (!cancellationToken.IsCancellationRequested) {
					Thread.Sleep(1000);
					MobilePhone.Battery.ChangeCurrentCapacity(_chargeRateMah);
				}
			}, cancellationToken);
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing) {
			if (disposed) {
				return;
			}
			if (disposing) {
				_cancellationTokenChargePhone?.Cancel();
				_cancellationTokenDischargePhone?.Cancel();
			}
			disposed = true;
		}
	}
}