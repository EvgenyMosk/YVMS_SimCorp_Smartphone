using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class Microphone : ICommonDescription, IAudioInputDevice {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}

		public void InputVolumeDecrease(int delta) {
			throw new NotImplementedException();
		}

		public void InputVolumeIncrease(int delta) {
			throw new NotImplementedException();
		}

		public void StartRecordingSound() {
			throw new NotImplementedException();
		}

		public void StopRecordingSound() {
			throw new NotImplementedException();
		}
	}
}
