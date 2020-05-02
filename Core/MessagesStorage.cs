using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;
using Core.SoftwareComponents;

namespace Core {
	public class MessagesStorage : IList<IMessage> {
		private readonly IList<IMessage> _messagesStorage;
		public event EventHandler<NotificationEventArgs> MessageReceived;
		public event EventHandler<NotificationEventArgs> MessageRemoved;
		public event EventHandler<EventArgs> MessageListCleared;
		public event EventHandler<SendersListChangedArgs> SendersListChanged;
		protected void OnMessageReceived(IMessage message) {
			MessageReceived?.Invoke(this, new NotificationEventArgs(message));
		}
		protected void OnMessageRemoved(IMessage message) {
			MessageRemoved?.Invoke(this, new NotificationEventArgs(message));
		}
		protected void OnMessageListCleared() {
			MessageListCleared?.Invoke(this, new EventArgs());
		}
		protected void OnSendersListChanged(IEnumerable<string> senders) {
			SendersListChanged?.Invoke(this, new SendersListChangedArgs(senders));
		}

		public MessagesStorage(IList<IMessage> messages) {
			if (messages != null) {
				_messagesStorage = messages;
			} else {
				_messagesStorage = new List<IMessage>();
			}
		}

		private void RaiseSendersListChangedEvent() {
			IEnumerable<string> messagesSenders = GetMessagesSenders();
			OnSendersListChanged(messagesSenders);
		}
		private int GetNumberOfSenders() {
			return GetMessagesSenders().Count();
		}

		#region LINQ
		public IList<IMessage> GetMessages() {
			return _messagesStorage;
		}
		public IEnumerable<string> GetMessagesSenders() {
			IEnumerable<string> senders = (from msg in _messagesStorage select msg.Sender).Distinct();
			return senders;
		}
		public IEnumerable<IMessage> GetMessagesFromCertainSender(string sender) {
			IEnumerable<IMessage> messages = _messagesStorage.Where(msgs => msgs.Sender == sender);
			return messages;
		}
		public IEnumerable<IMessage> GetMessagesContainsCertainText(string text) {
			IEnumerable<IMessage> messages = _messagesStorage.Where(msgs => msgs.Body.Contains(text));
			return messages;
		}
		public IEnumerable<IMessage> GetMessagesBetweenDates(DateTime fromDate, DateTime toDate) {
			if (fromDate > toDate) {
				throw new ArgumentException($"{nameof(fromDate)} cannot be after {nameof(toDate)}!");
			}

			IEnumerable<IMessage> messages = _messagesStorage.Where(msgs => msgs.ReceivedTime >= fromDate && msgs.ReceivedTime <= toDate);
			return messages;
		}

		public IEnumerable<IMessage> ApplyAND(IEnumerable<IMessage> msgsFilteredBySender, IEnumerable<IMessage> msgsFilteredByText, IEnumerable<IMessage> msgsFilteredByDate) {
			IEnumerable<IMessage> messagesAfterAND = null;

			if (msgsFilteredBySender.Count() != 0) {
				messagesAfterAND = msgsFilteredBySender;
			} else if (msgsFilteredByText.Count() != 0) {
				messagesAfterAND = msgsFilteredByText;
			} else {
				messagesAfterAND = msgsFilteredByDate;
			}

			if (messagesAfterAND == null) {
				throw new NullReferenceException("Cannot apply filters to null!");
			}

			if (msgsFilteredBySender.Count() != 0) {
				messagesAfterAND = messagesAfterAND.Intersect(msgsFilteredBySender);
			}
			if (msgsFilteredByText.Count() != 0) {
				messagesAfterAND = messagesAfterAND.Intersect(msgsFilteredByText);
			}
			if (msgsFilteredByDate.Count() != 0) {
				messagesAfterAND = messagesAfterAND.Intersect(msgsFilteredByDate);
			}

			return messagesAfterAND;
		}
		public IEnumerable<IMessage> ApplyOR(IEnumerable<IMessage> msgsFilteredBySender, IEnumerable<IMessage> msgsFilteredByText, IEnumerable<IMessage> msgsFilteredByDate) {
			if (msgsFilteredBySender == null || msgsFilteredByText == null || msgsFilteredByDate == null) {
				throw new ArgumentNullException("None of the arguments can be null!");
			}
			IEnumerable<IMessage> messagesAfterOR = msgsFilteredBySender.Union(msgsFilteredByText).Union(msgsFilteredByDate).OrderBy(x => x.ReceivedTime);
			return messagesAfterOR;
		}
		#endregion
		#region IList implementation
		public IMessage this[int index] {
			get { return _messagesStorage[index]; }
			set { _messagesStorage[index] = value; }
		}

		public int Count { get { return _messagesStorage.Count; } }
		public bool IsReadOnly { get { return _messagesStorage.IsReadOnly; } }

		public void Add(IMessage item) {
			int numberOfSendersBefore = GetNumberOfSenders();

			_messagesStorage.Add(item);
			OnMessageReceived(item);

			int numberOfSendersAfter = GetNumberOfSenders();
			if (numberOfSendersBefore != numberOfSendersAfter) {
				RaiseSendersListChangedEvent();
			}
		}

		public void Clear() {
			int numberOfSendersBefore = GetNumberOfSenders();

			_messagesStorage.Clear();
			OnMessageListCleared();
			RaiseSendersListChangedEvent();

			int numberOfSendersAfter = GetNumberOfSenders();
			if (numberOfSendersBefore != numberOfSendersAfter) {
				RaiseSendersListChangedEvent();
			}
		}

		public bool Contains(IMessage item) {
			return _messagesStorage.Contains(item);
		}

		public void CopyTo(IMessage[] array, int arrayIndex) {
			int numberOfSendersBefore = GetNumberOfSenders();

			_messagesStorage.CopyTo(array, arrayIndex);

			int numberOfSendersAfter = GetNumberOfSenders();
			if (numberOfSendersBefore != numberOfSendersAfter) {
				RaiseSendersListChangedEvent();
			}
		}

		public IEnumerator<IMessage> GetEnumerator() {
			return _messagesStorage.GetEnumerator();
		}

		public int IndexOf(IMessage item) {
			return _messagesStorage.IndexOf(item);
		}

		public void Insert(int index, IMessage item) {
			int numberOfSendersBefore = GetNumberOfSenders();

			_messagesStorage.Insert(index, item);
			OnMessageReceived(item);

			int numberOfSendersAfter = GetNumberOfSenders();
			if (numberOfSendersBefore != numberOfSendersAfter) {
				RaiseSendersListChangedEvent();
			}
		}

		public bool Remove(IMessage item) {
			int numberOfSendersBefore = GetNumberOfSenders();

			bool messageRemoved = _messagesStorage.Remove(item);
			OnMessageRemoved(item);

			int numberOfSendersAfter = GetNumberOfSenders();
			if (numberOfSendersBefore != numberOfSendersAfter) {
				RaiseSendersListChangedEvent();
			}

			return messageRemoved;
		}

		public void RemoveAt(int index) {
			int numberOfSendersBefore = GetNumberOfSenders();

			IMessage message = _messagesStorage[index];
			OnMessageRemoved(message);
			_messagesStorage.RemoveAt(index);

			int numberOfSendersAfter = GetNumberOfSenders();
			if (numberOfSendersBefore != numberOfSendersAfter) {
				RaiseSendersListChangedEvent();
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
		#endregion
	}
}