using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public struct DescriptionContainer : ICommonDescription {
		public string Model { get; }
		public string Manufacturer { get; }
		public int? YearOfProduction { get; }
		public string Version { get; set; }
		public DescriptionContainer(string model, string manufacturer, int? yearOfProduction, string version) {
			Model = model;
			Manufacturer = manufacturer;
			YearOfProduction = yearOfProduction;
			Version = version;
		}
	}
}
