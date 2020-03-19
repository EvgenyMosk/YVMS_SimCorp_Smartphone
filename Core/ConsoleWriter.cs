using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class ConsoleWriter : IOutput {
		public void Output(object data) {
			Console.WriteLine(data);
		}

		public string OutputAsString(object data) {
			return data.ToString();
		}
	}
}