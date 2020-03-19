using System;

using Core.Enums;

namespace Core {
	public class Screen : IPowerable, ICommonDescription, IDisplay {
		protected bool _isTurnedOn;
		public int HorizontalResolution { get; set; }
		public int VerticalResolution { get; set; }
		public int SizeInches { get; set; }

		public DisplayType DisplayType { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public override string ToString() {
			string description;
			description = DescriptionFormatter.CreateDescription(this);
			return description;
		}

		public void TurnOff() {
			throw new NotImplementedException();
		}

		public void TurnOn() {
			throw new NotImplementedException();
		}
	}
}
