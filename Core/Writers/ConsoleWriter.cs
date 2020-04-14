using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.Writers {
	public class ConsoleWriter : IOutput {
		public void Output(IMessage message) {
			if (message == null ||
				(string.IsNullOrEmpty(message.Sender)
				&& string.IsNullOrEmpty(message.Body))) {
				return;
			}
			string output = message.Sender + Environment.NewLine +
				message.Body + Environment.NewLine +
				message.ReceivedTime.ToShortTimeString();
			Console.WriteLine(output);

		}

		public string OutputAsString(object data) {
			if (data == null) {
				return string.Empty;
			}
			return data.ToString();
		}
	}
}