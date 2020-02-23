using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class CameraModule : ICommonDescription {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public CameraDirectionType CameraType { get; set; }

		public void CreatePhoto() {

		}
		public void StartRecordingVideo() {

		}
		public void StopRecordingVideo() {

		}

		public string GetDescription() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}
	}
}
