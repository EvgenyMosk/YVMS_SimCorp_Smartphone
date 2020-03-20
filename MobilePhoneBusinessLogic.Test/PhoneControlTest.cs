using System;
using System.Collections.Generic;
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
		public IMobilePhone MobilePhone { get; set; }

		private class FakeMobilePhone : IMobilePhone {
			public PhoneBootState PhoneBootState { get; set; }
			public Recovery Recovery { get; set; }
			public Bootloader Bootloader { get; set; }
			public Core.OperatingSystem OperatingSystem { get; set; }
			public IChipset Chipset { get; set; }
			public List<SimCard> SimCards { get; set; }
			public IDisplay Screen { get; set; }
			public Button PowerButton { get; set; }
			public NetworkModule NetworkModule { get; set; }
			public IAudioInputDevice AudioInputDevice { get; set; }
			public IAudioOutputDevice AudioOutputDevice { get; set; }
			public IPowerSource Battery { get; set; }
			public RAM RAM { get; set; }
			public Storage InternalStorage { get; set; }
			public Case Case { get; set; }
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
				throw new NotImplementedException();
			}

			public void PlayFile(string audioFile) {
				throw new NotImplementedException();
			}

			public string PlayFileAndReturnString(string audioFile) {
				throw new NotImplementedException();
			}

			public void StopPlayingAudio() {
				throw new NotImplementedException();
			}
		}

		[TestInitialize]
		public void SetUp() {

		}

		[TestMethod]
		public void PlayAudioTest() {

		}

		[TestMethod]
		public void PlayAudioAndReturnStringTest() {

		}

		[TestMethod]
		public void StopPlayingAudioTest() {

		}
	}
}