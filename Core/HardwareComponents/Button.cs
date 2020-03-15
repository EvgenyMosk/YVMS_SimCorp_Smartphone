using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class Button : ICommonDescription {
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public override string ToString() {
			return DescriptionFormatter.CreateDescription(this);
		}

		public void SendButtonCode() {
			throw new System.NotImplementedException();
		}
	}
}
