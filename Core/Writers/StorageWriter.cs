using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.Writers {
	public class StorageWriter : IOutput {
		private IList<IMessage> _messagesStorage;
		public StorageWriter(IList<IMessage> messagesStorage) {
			_messagesStorage = messagesStorage;
		}
		public void Output(IMessage message) {
			_messagesStorage.Add(message);
		}
		public string OutputAsString(object data) {
			throw new NotImplementedException();
		}
	}
}