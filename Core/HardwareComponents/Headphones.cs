using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HardwareComponents {
	public class Headphones : IAudioOutputDevice {
		protected int vAudioVolumeLevelUpperThreshold;
		protected const int vAudioVolumeLevelLowerThreshold = 0;

		public Headphones(string model, string manufacturer, int? yearOfProduction, string version, IOutput output, int upperVolumeLevel = 100) {
			Model = model;
			Manufacturer = manufacturer;
			YearOfProduction = yearOfProduction;
			Version = version;
			Output = output;
			vAudioVolumeLevelUpperThreshold = upperVolumeLevel;
		}
		public IOutput Output { get; set; }
		public int AudioVolumeLevelCurrent { get; set; } = 0;
		public string AudioFile { get; set; }
		public string Model { get; }
		public string Manufacturer { get; }
		public int? YearOfProduction { get; }
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
		public string PlayFileAndReturnString(string audioFile) {
			AudioFile = audioFile;
			if (Output != null) {
				return Output.OutputAsString(audioFile);
			} else {
				return string.Empty;
			}
		}

		public void StopPlayingAudio() {
			AudioFile = null;
		}

		public override string ToString() {
			string description;
			description = TextProcessor.CreateDescription(this);
			return description;
		}
	}
}