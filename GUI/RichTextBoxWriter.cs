using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;

namespace GUI {
	public class RichTextBoxWriter : IOutput {
		private RichTextBox RichTextBox { get; set; }
		public RichTextBoxWriter(RichTextBox richTextBox) {
			RichTextBox = richTextBox;
		}

		public void Output(object data) {
			RichTextBox.AppendText(data.ToString());
			RichTextBox.ScrollToCaret();
		}

		public string OutputAsString(object data) {
			throw new NotImplementedException();
		}
	}
}
