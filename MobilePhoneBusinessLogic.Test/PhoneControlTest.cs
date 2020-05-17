using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Core;
using Core.Enums;
using Core.HardwareComponents;
using Core.Interfaces;
using Core.SoftwareComponents;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhonePlayerBusinessLogic.Test {
	[TestClass]
	public class PhoneControlTest {
		public PhoneControl PhoneControlUnderTest { get; set; }

		private class FakeMobilePhone : IMobilePhone {
			public PhoneBootState PhoneBootState { get; set; }
			public Core.SoftwareComponents.OperatingSystem OperatingSystem { get; set; }
			public IChipset Chipset { get; set; }
			public IAudioOutputDevice AudioOutputDevice { get; set; }
			public IMemory InternalStorage { get; set; }
			public string Model { get; set; }
			public string Manufacturer { get; set; }
			public int? YearOfProduction { get; set; }
			public string Version { get; set; }
			public IOutput Output { get; set; }
			public IOutput NotificationsOutput { get; set; }
			public MessagesStorage MessagesStorage { get; set; }
			public IBattery Battery { get; set; }
			public PhoneCallsCollection PhoneCallsStorage { get; set; }

			public void DisableNotifications() {
				throw new NotImplementedException();
			}
			public void EnableNotifications() {
				throw new NotImplementedException();
			}
			public void NotifyAboutReceivedMessage(object sender, NotificationEventArgs e) {
				throw new NotImplementedException();
			}

			public void ReceiveCall(ICall call) {
				throw new NotImplementedException();
			}

			public void ReceiveCall(IContact contact, PhoneNumber phoneNumber, PhoneCallType callType, DateTime callTime) {
				throw new NotImplementedException();
			}

			public void ReceiveMessage(string senderName, string messageBody) {
				throw new NotImplementedException();
			}
		}
		private class FakeHeadphones : IAudioOutputDevice {
			public IOutput Output { get; set; }
			public int AudioVolumeLevelCurrent { get; set; }
			public string AudioFile { get; set; }
			public string Model { get; set; }
			public string Manufacturer { get; set; }
			public int? YearOfProduction { get; set; }
			public string Version { get; set; }
			public void ChangeVolume(int delta) {
				Console.WriteLine("IAudioOutputDevice_ChangeVolume");
			}
			public void PlayFile(string audioFile) {
				Console.WriteLine("IAudioOutputDevice_PlayFile");
			}
			public string PlayFileAndReturnString(string audioFile) {
				return "IAudioOutputDevice_PlayFileAndReturnString";
			}
			public void StopPlayingAudio() {
				Console.WriteLine("IAudioOutputDevice_StopPlayingAudio");
			}
		}

		[TestInitialize]
		public void SetUp() {
			IMobilePhone mobilePhone = new FakeMobilePhone {
				Battery = new Battery(1000, 1000)
			};
			IAudioOutputDevice audioOutputDevice = new FakeHeadphones();
			PhoneControlUnderTest = new PhoneControl(mobilePhone, audioOutputDevice, null);
		}

		#region AudioDevice-related tests
		[TestMethod]
		public void PlayAudio_AudioDeviceNotNull_NotNullString_ExpectAudioDevicePlayCalled() {
			string audioFile = "audioFile";
			string expectedResult = "IAudioOutputDevice_PlayFile";
			string actualResult;

			using (StringWriter stringWriter = new StringWriter()) {
				Console.SetOut(stringWriter);

				PhoneControlUnderTest.PlayAudio(audioFile);
				actualResult = stringWriter.ToString().Trim();
			}

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudio_AudioDeviceNull_NotNullString_ExpectAudioDevicePlayNotCalled() {
			string audioFile = "audioFile";
			string expectedResult = string.Empty;
			string actualResult;

			using (StringWriter stringWriter = new StringWriter()) {
				Console.SetOut(stringWriter);

				PhoneControlUnderTest.MobilePhone.AudioOutputDevice = null;
				PhoneControlUnderTest.PlayAudio(audioFile);
				actualResult = stringWriter.ToString().Trim();
			}

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudio_AudioDeviceNotNull_NullString_ExpectAudioDevicePlayNotCalled() {
			string audioFile = string.Empty;
			string expectedResult = string.Empty;
			string actualResult;

			using (StringWriter stringWriter = new StringWriter()) {
				Console.SetOut(stringWriter);

				PhoneControlUnderTest.PlayAudio(audioFile);
				actualResult = stringWriter.ToString().Trim();
			}

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudio_AudioDeviceNull_NullString_ExpectAudioDevicePlayNotCalled() {
			string audioFile = string.Empty;
			string expectedResult = string.Empty;
			string actualResult;

			using (StringWriter stringWriter = new StringWriter()) {
				Console.SetOut(stringWriter);

				PhoneControlUnderTest.MobilePhone.AudioOutputDevice = null;
				PhoneControlUnderTest.PlayAudio(audioFile);
				actualResult = stringWriter.ToString().Trim();
			}

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudioAndReturnString_AudioDeviceNotNull_NotNullString_ExpectAudioDevicePlayFileAndReturnStringCalled() {
			string audioFile = "audioFile";
			string expectedResult = "IAudioOutputDevice_PlayFileAndReturnString";
			string actualResult;

			actualResult = PhoneControlUnderTest.PlayAudioAndReturnString(audioFile);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudioAndReturnString_AudioDeviceNull_NotNullString_ExpectAudioDevicePlayFileAndReturnStringNotCalled() {
			string audioFile = "audioFile";
			string expectedResult = string.Empty;
			string actualResult;

			PhoneControlUnderTest.MobilePhone.AudioOutputDevice = null;
			actualResult = PhoneControlUnderTest.PlayAudioAndReturnString(audioFile);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudioAndReturnString_AudioDeviceNotNull_NullString_ExpectAudioDevicePlayFileAndReturnStringNotCalled() {
			string audioFile = string.Empty;
			string expectedResult = string.Empty;
			string actualResult;

			actualResult = PhoneControlUnderTest.PlayAudioAndReturnString(audioFile);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudioAndReturnString_AudioDeviceNull_NullString_ExpectAudioDevicePlayFileAndReturnStringNotCalled() {
			string audioFile = string.Empty;
			string expectedResult = string.Empty;
			string actualResult;

			PhoneControlUnderTest.MobilePhone.AudioOutputDevice = null;
			actualResult = PhoneControlUnderTest.PlayAudioAndReturnString(audioFile);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void StopPlayingAudio_AudioDeviceNotNull_ExpectAudioDeviceStopPlayingAudioCalled() {
			string expectedResult = "IAudioOutputDevice_StopPlayingAudio";
			string actualResult;

			using (StringWriter stringWriter = new StringWriter()) {
				Console.SetOut(stringWriter);

				PhoneControlUnderTest.StopPlayingAudio();
				actualResult = stringWriter.ToString().Trim();
			}

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void StopPlayingAudio_AudioDeviceNull_ExpectAudioDeviceStopPlayingAudioNotCalled() {
			string expectedResult = string.Empty;
			string actualResult;

			using (StringWriter stringWriter = new StringWriter()) {
				Console.SetOut(stringWriter);

				PhoneControlUnderTest.MobilePhone.AudioOutputDevice = null;
				PhoneControlUnderTest.StopPlayingAudio();
				actualResult = stringWriter.ToString().Trim();
			}

			Assert.AreEqual(expectedResult, actualResult);
		}
		#endregion
		#region Battery-related tests
		[TestMethod]
		public void SetBatteryRates_ChargeRateZero_ExpectArgumentExxception() {
			int chargeRate = 0;
			int dischargeRate = -100;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetBatteryRates(chargeRate, dischargeRate);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown);
		}
		[TestMethod]
		public void SetBatteryRates_DischargeLevelZero_ExpectArgumentException() {
			int chargeRate = 100;
			int dischargeRate = 0;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetBatteryRates(chargeRate, dischargeRate);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown);
		}
		[TestMethod]
		public void SetBatteryRates_BothRatesNegative_ExpectNoExceptions() {
			int chargeRate = -100;
			int dischargeRate = -100;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetBatteryRates(chargeRate, dischargeRate);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsFalse(exceptionThrown);
		}
		[TestMethod]
		public void SetBatteryRates_BothRatesPositive_ExpectNoExceptions() {
			int chargeRate = 100;
			int dischargeRate = 100;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetBatteryRates(chargeRate, dischargeRate);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsFalse(exceptionThrown);
		}
		[TestMethod]
		public void SetBatteryRates_ChargeNegativeDischargePositive_ExpectNoExceptions() {
			int chargeRate = -100;
			int dischargeRate = 100;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetBatteryRates(chargeRate, dischargeRate);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsFalse(exceptionThrown);
		}
		[TestMethod]
		public void SetBatteryRates_ChargePositiveDischargeNegative_ExpectNoExceptions() {
			int chargeRate = 100;
			int dischargeRate = -100;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetBatteryRates(chargeRate, dischargeRate);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsFalse(exceptionThrown);
		}
		[TestMethod]
		public void SetChargingDischargingInterval_IntervalIsZero_ExpectArgumentException() {
			int interval = 0;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetChargingDischargingInterval(interval);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown);
		}
		[TestMethod]
		public void SetChargingDischargingInterval_IntervalIsLessThanZero_ExpectArgumentException() {
			int interval = -10;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetChargingDischargingInterval(interval);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown);
		}
		[TestMethod]
		public void SetChargingDischargingInterval_IntervalIsPositive_ExpectNoException() {
			int interval = 100;
			bool exceptionThrown = false;

			try {
				PhoneControlUnderTest.SetChargingDischargingInterval(interval);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsFalse(exceptionThrown);
		}

		[TestMethod]
		public void UnplugPhoneFromPowerSource_WaitAWhile_ExpectHalfOfTheBatteryLeft() {
			// Arrange
			int actualChargePctAtStart;
			int actualChargePctAfterUnplugging;
			int actualChargePctAfterResetAndWaiting;
			int expectedChargePctAtStart = 100;
			int expectedChargePctAfterUnplugging = 60;
			int expectedChargePctAfterResetAndWaiting = 50;

			// Act
			PhoneControlUnderTest.ResetCharging();
			actualChargePctAtStart = PhoneControlUnderTest.MobilePhone.Battery.CurrentChargePercentage;
			PhoneControlUnderTest.SetChargingDischargingInterval(10);
			PhoneControlUnderTest.SetBatteryRates(200, 100);
			PhoneControlUnderTest.UnplugPhoneFromPowerSource();

			Thread.Sleep(45);

			PhoneControlUnderTest.ResetCharging();
			actualChargePctAfterUnplugging = PhoneControlUnderTest.MobilePhone.Battery.CurrentChargePercentage;

			Thread.Sleep(200);

			actualChargePctAfterResetAndWaiting = PhoneControlUnderTest.MobilePhone.Battery.CurrentChargePercentage;

			// Assert
			Assert.AreEqual(expectedChargePctAtStart, actualChargePctAtStart);
			Assert.AreEqual(expectedChargePctAfterUnplugging, actualChargePctAfterUnplugging);
			Assert.AreEqual(expectedChargePctAfterResetAndWaiting, actualChargePctAfterResetAndWaiting);
		}
		[TestMethod]
		public void PlugPhoneToPowerSource_WaitAWhile_ExpectFullBattery() {
			// Arrange
			int actualChargePctAtStart;
			int actualChargePctAfterUnplugging;
			int actualChargePctAfterResetAndWaiting;
			int expectedChargePctAtStart = 50;
			int expectedChargePctAfterUnplugging = 100;
			int expectedChargePctAfterResetAndWaiting = 100;

			// Act
			PhoneControlUnderTest.MobilePhone.Battery.ChangeCurrentCapacity(-500); // Set Battery to 50%
			PhoneControlUnderTest.ResetCharging();
			actualChargePctAtStart = PhoneControlUnderTest.MobilePhone.Battery.CurrentChargePercentage;
			PhoneControlUnderTest.SetChargingDischargingInterval(10);
			PhoneControlUnderTest.SetBatteryRates(200, 100);
			PhoneControlUnderTest.PlugPhoneToPowerSource();

			Thread.Sleep(55);

			PhoneControlUnderTest.ResetCharging();
			actualChargePctAfterUnplugging = PhoneControlUnderTest.MobilePhone.Battery.CurrentChargePercentage;

			Thread.Sleep(200);

			actualChargePctAfterResetAndWaiting = PhoneControlUnderTest.MobilePhone.Battery.CurrentChargePercentage;

			// Assert
			Assert.AreEqual(expectedChargePctAtStart, actualChargePctAtStart);
			Assert.AreEqual(expectedChargePctAfterUnplugging, actualChargePctAfterUnplugging);
			Assert.AreEqual(expectedChargePctAfterResetAndWaiting, actualChargePctAfterResetAndWaiting);
		}
		#endregion
	}
}