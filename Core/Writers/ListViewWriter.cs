using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Interfaces;

namespace Core.Writers {
	public class ListViewWriter : IOutput {
		private ListView listView;
		public ListViewWriter(ListView listView) {
			this.listView = listView;
		}
		public void Output(IMessage message) {
			if (message != null) {
				string messageDatereceived = message.ReceivedTime.ToShortDateString() + " " + message.ReceivedTime.ToShortTimeString();
				ListViewItem viewItem = new ListViewItem(new[] { message.Sender, message.Body, messageDatereceived });
				listView.Items.Add(viewItem);
			}
		}

		public string OutputAsString(object data) {
			throw new NotImplementedException();
		}
	}
}