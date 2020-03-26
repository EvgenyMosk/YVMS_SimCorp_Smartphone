using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Enums;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PhonePlayerBusinessLogic;

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
			IMobilePhone mobilePhone = new FakeMobilePhone();
			IAudioOutputDevice audioOutputDevice = new FakeHeadphones();
			PhoneControlUnderTest = new PhoneControl(mobilePhone, audioOutputDevice, null);
		}

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
			//string audioFile = "audioFile";
			//string expectedResult = "IAudioOutputDevice_PlayFile";
			//string actualResult;

			//using (StringWriter stringWriter = new StringWriter()) {
			//	Console.SetOut(stringWriter);

			//	PhoneControlUnderTest.PlayAudio(audioFile);
			//	actualResult = stringWriter.ToString().Trim();
			//}

			//Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudio_AudioDeviceNotNull_NullString_ExpectAudioDevicePlayNotCalled() {
			//string audioFile = "audioFile";
			//string expectedResult = "IAudioOutputDevice_PlayFile";
			//string actualResult;

			//using (StringWriter stringWriter = new StringWriter()) {
			//	Console.SetOut(stringWriter);

			//	PhoneControlUnderTest.PlayAudio(audioFile);
			//	actualResult = stringWriter.ToString().Trim();
			//}

			//Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudio_AudioDeviceNull_NullString_ExpectAudioDevicePlayNotCalled() {
			//string audioFile = "audioFile";
			//string expectedResult = "IAudioOutputDevice_PlayFile";
			//string actualResult;

			//using (StringWriter stringWriter = new StringWriter()) {
			//	Console.SetOut(stringWriter);

			//	PhoneControlUnderTest.PlayAudio(audioFile);
			//	actualResult = stringWriter.ToString().Trim();
			//}

			//Assert.AreEqual(expectedResult, actualResult);
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
			//string audioFile = "audioFile";
			//string expectedResult = "IAudioOutputDevice_PlayFileAndReturnString";
			//string actualResult;

			//actualResult = PhoneControlUnderTest.PlayAudioAndReturnString(audioFile);

			//Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudioAndReturnString_AudioDeviceNotNull_NullString_ExpectAudioDevicePlayFileAndReturnStringNotCalled() {
			string audioFile = "audioFile";
			//string expectedResult = "IAudioOutputDevice_PlayFileAndReturnString";
			//string actualResult;

			//actualResult = PhoneControlUnderTest.PlayAudioAndReturnString(audioFile);

			//Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void PlayAudioAndReturnString_AudioDeviceNull_NullString_ExpectAudioDevicePlayFileAndReturnStringNotCalled() {
			string audioFile = "audioFile";
			//string expectedResult = "IAudioOutputDevice_PlayFileAndReturnString";
			//string actualResult;

			//actualResult = PhoneControlUnderTest.PlayAudioAndReturnString(audioFile);

			//Assert.AreEqual(expectedResult, actualResult);
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
			//string expectedResult = "IAudioOutputDevice_StopPlayingAudio";
			//string actualResult;

			//using (StringWriter stringWriter = new StringWriter()) {
			//	Console.SetOut(stringWriter);

			//	PhoneControlUnderTest.StopPlayingAudio();
			//	actualResult = stringWriter.ToString().Trim();
			//}

			//Assert.AreEqual(expectedResult, actualResult);
		}
	}
}