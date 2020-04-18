using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core {
	public class MessagesCollection : IEnumerable<IMessage> {
		private IList<IMessage> messagesCollection;

		public MessagesCollection(IList<IMessage> messages) {
			if (messages == null) {
				messagesCollection = new List<IMessage>();
			}
			messagesCollection = messages;
		}

		public void Add(IMessage message) {
			if (message != null) {
				messagesCollection.Add(message);
			}
		}

		public void AddRange(IEnumerable<IMessage> messages) {
			if (messages != null) {
				foreach (IMessage message in messages) {
					Add(message);
				}
			}
		}

		public IEnumerator<IMessage> GetEnumerator() {
			foreach (IMessage message in messagesCollection) {
				if (message == null) {
					break;
				}
				yield return message;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}