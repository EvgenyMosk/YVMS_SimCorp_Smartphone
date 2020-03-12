using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class Headphones : IAudioOutputDevice<string> {
		protected int vAudioVolumeLevelUpperThreshold = 100;
		protected static int vAudioVolumeLevelLowerThreshold = 0;
		public IOutput Output { get; set; }
		public int AudioVolumeLevelCurrent { get; set; } = 0;
		public string AudioFile { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public void ChangeVolume(int delta) {
			int newVolumeLevel = AudioVolumeLevelCurrent + delta;

			if (newVolumeLevel > vAudioVolumeLevelUpperThreshold) {
				AudioVolumeLevelCurrent = vAudioVolumeLevelUpperThreshold;
			} else if (newVolumeLevel < vAudioVolumeLevelLowerThreshold) {
				AudioVolumeLevelCurrent = vAudioVolumeLevelLowerThreshold;
			} else {
				AudioVolumeLevelCurrent = newVolumeLevel;
			}
		}

		public void PlayFile(string audioFile) {
			AudioFile = audioFile;
			if (Output != null) {
				Output.Output(AudioFile);
			}
		}

		public void StopPlayingAudio() {
			AudioFile = null;
		}

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}