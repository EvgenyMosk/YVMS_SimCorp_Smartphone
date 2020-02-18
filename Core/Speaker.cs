using System;

namespace Core {
	public class Speaker : ICommonDescription, IAudioOutputDevice {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}

		public void PlaySound() {
			throw new NotImplementedException();
		}

		public void StartPlayingSound() {
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
