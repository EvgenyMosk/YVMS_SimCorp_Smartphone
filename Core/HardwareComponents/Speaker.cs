using System;

namespace Core {
	public class Speaker : ICommonDescription, IAudioOutputDevice<string> {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }
		public IOutput Output { get; set; }
		public int AudioVolumeLevelCurrent { get; set; }
		public string AudioFile { get; set; }

		public void ChangeVolume(int delta) {
			throw new NotImplementedException();
		}

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}

		public void PauseOrResumePlayingAudio() {
			throw new NotImplementedException();
		}

		public void PlayFile(string audioFile) {
			throw new NotImplementedException();
		}

		public void PlaySound() {
			throw new NotImplementedException();
		}

		public void StartPlayingSound() {
			throw new NotImplementedException();
		}

		public void StopPlayingAudio() {
			throw new NotImplementedException();
		}

		public void StopPlayingSound() {
			throw new NotImplementedException();
		}

		public void VolumeDecrease(int value) {
			throw new NotImplementedException();
		}

		public void VolumeIncrease(int value) {
			throw new NotImplementedException();
		}
	}
}
