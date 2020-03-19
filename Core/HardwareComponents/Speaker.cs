using System;

namespace Core {
	public class Speaker : IAudioOutputDevice<string> {
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

		public override string ToString() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}
