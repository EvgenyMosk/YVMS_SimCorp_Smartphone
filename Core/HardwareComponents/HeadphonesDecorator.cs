using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HardwareComponents {
	public abstract class HeadphonesDecorator : IAudioOutputDevice {
		protected readonly IAudioOutputDevice _audioOutputDevice;
		public IOutput Output { get; set; }
		public int AudioVolumeLevelCurrent { get; set; }
		public string AudioFile { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public HeadphonesDecorator(IAudioOutputDevice audioOutputDevice) {
			_audioOutputDevice = audioOutputDevice;
		}
		public void ChangeVolume(int delta) {
			_audioOutputDevice.ChangeVolume(delta);
		}
		public void PlayFile(string audioFile) {
			_audioOutputDevice.PlayFile(audioFile);
		}
		public string PlayFileAndReturnString(string audioFile) {
			return _audioOutputDevice.PlayFileAndReturnString(audioFile);
		}
		public void StopPlayingAudio() {
			_audioOutputDevice.StopPlayingAudio();
		}
	}
}
