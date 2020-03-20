using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class ConsoleWriter : IOutput {
		public void Output(object data) {
			if (data != null) {
				Console.WriteLine(data.ToString());
			}
		}

		public string OutputAsString(object data) {
			if (data == null) {
				return string.Empty;
			}
			return data.ToString();
		}
	}
}