using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Interfaces;

namespace Core.Writers {
	public class RichTextBoxWriter : IOutput {
		private RichTextBox richTextBox;
		public RichTextBoxWriter(RichTextBox richTextBox) {
			this.richTextBox = richTextBox;
		}

		public void Output(IMessage message) {
			if (message == null) {
				return;
			}
			richTextBox.AppendText(message.ToString());
			richTextBox.ScrollToCaret();
		}

		public string OutputAsString(object data) {
			throw new NotImplementedException();
		}
	}
}
