using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;
using Core.HardwareComponents;
using Core.SoftwareComponents;

using OS = Core.SoftwareComponents.OperatingSystem;

namespace Core {
	public class MobilePhone : IMobilePhone {
		public string Model { get; }
		public string Manufacturer { get; }
		public int? YearOfProduction { get; }
		public string Version { get; set; }

		#region Software components
		public OS OperatingSystem { get; set; }
		public PhoneBootState PhoneBootState { get; set; }
		public NotificationService NotificationService { get; set; }
		public IOutput NotificationsOutput { get; set; }
		#endregion
		#region Hardware Components
		public IChipset Chipset { get; set; }
		public IAudioOutputDevice AudioOutputDevice { get; set; }
		public IMemory InternalStorage { get; set; }
		#endregion
		public MobilePhone(string model, string manufacturer, IChipset chipset, int? yearOfProduction, string version, IOutput output) {
			Model = model;
			Manufacturer = manufacturer;
			Chipset = chipset;
			YearOfProduction = yearOfProduction;
			Version = version;
			NotificationsOutput = output;
		}
		public void EnableNotifications(IOutput notificationsOutput) {
			if (notificationsOutput == null) {
				throw new ArgumentNullException(nameof(notificationsOutput));
			}
			if (NotificationService == null) {
				NotificationService = new NotificationService();
			}
			NotificationsOutput = notificationsOutput;

			NotificationService.MessageReceived += NotifyAboutReceivedMessage;
		}
		public void DisableNotifications() {
			NotificationService.MessageReceived -= NotifyAboutReceivedMessage;
			NotificationsOutput = null;
		}
		public void NotifyAboutReceivedMessage(object sender, NotificationEventArgs e) {
			if (NotificationsOutput == null) {
				return;
			}

			string data = $"{e}" + Environment.NewLine;

			NotificationsOutput.Output(data);
		}

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

		public static IMobilePhone CreateMobilePhone(PresetsPhones presetPhone) {
			IMobilePhone mobilePhone;
			IChipset chipset;
			IMemory internalStorage;

			switch (presetPhone) {
				case PresetsPhones.MicrosoftLumia640XL:
					/// TODO: Move to separate methods
					chipset = Core.HardwareComponents.Chipset.CreateChipset(PresetsChipsets.Snapdragon400);

					// Create information about memory
					string model = "eMMC";
					string manufacturer = "Micron";
					int yearOfProduction = 2015;
					string version = "v.1.0";
					int capacity = 8192;

					internalStorage = new Memory(model, manufacturer, yearOfProduction, version, capacity);

					// Create information about phone itself
					model = "Lumia 640 XL";
					manufacturer = "Microsoft";
					yearOfProduction = 2015;
					version = "v.1.2";

					mobilePhone = new MobilePhone(model, manufacturer, chipset, yearOfProduction, version, null);

					// Create information about OS
					model = "Windows 10 Mobile";
					manufacturer = "Microsoft";
					yearOfProduction = 2015;
					version = "10.493";
					int size = 1456;

					InstallOperatingSystem(mobilePhone, model, manufacturer, yearOfProduction, version, size);

					break;
				default:
					throw new NotImplementedException();
			}
			return mobilePhone;
		}
		public static void InstallOperatingSystem(IMobilePhone mobilePhone, string model, string manufacturer, int? yearOfProduction, string version, int size) {
			if (mobilePhone == null) {
				throw new ArgumentNullException(nameof(mobilePhone));
			}
			mobilePhone.OperatingSystem = new Core.SoftwareComponents.OperatingSystem(model, manufacturer, yearOfProduction, version, size);
		}


	}
}