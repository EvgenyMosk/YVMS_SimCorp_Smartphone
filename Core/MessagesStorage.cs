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
        protected void OnMessageReceived(IMessage message) {
            MessageReceived?.Invoke(this, new NotificationEventArgs(message));
        }
        protected void OnMessageRemoved(IMessage message) {
            MessageRemoved?.Invoke(this, new NotificationEventArgs(message));
        }
        protected void OnMessageListCleared() {
            MessageListCleared?.Invoke(this, new EventArgs());
        }

        public MessagesStorage(IList<IMessage> messages) {
            if (messages != null) {
                _messagesStorage = messages;
            } else {
                _messagesStorage = new List<IMessage>();
            }
            AddDefaultMessages();
        }

        private void AddDefaultMessages() {
            int month = 1;
            int year = 1950;
            for (int day = 5; day < 28; day += 3) {
                NotificationMessage message = new NotificationMessage("Microsoft Corporation", "Default Message", new DateTime(year, month, day));
                _messagesStorage.Add(message);
                month++;
                year += 7;
            }
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
            IEnumerable<IMessage> messages = _messagesStorage.Where(msgs => msgs.ReceivedTime >= fromDate && msgs.ReceivedTime <= toDate);
            return messages;
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
            _messagesStorage.Add(item);
            OnMessageReceived(item);
        }

        public void Clear() {
            _messagesStorage.Clear();
            OnMessageListCleared();
        }

        public bool Contains(IMessage item) {
            return _messagesStorage.Contains(item);
        }

        public void CopyTo(IMessage[] array, int arrayIndex) {
            _messagesStorage.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IMessage> GetEnumerator() {
            return _messagesStorage.GetEnumerator();
        }

        public int IndexOf(IMessage item) {
            return _messagesStorage.IndexOf(item);
        }

        public void Insert(int index, IMessage item) {
            _messagesStorage.Insert(index, item);
            OnMessageReceived(item);
        }

        public bool Remove(IMessage item) {
            bool messageRemoved = _messagesStorage.Remove(item);
            OnMessageRemoved(item);
            return messageRemoved;
        }

        public void RemoveAt(int index) {
            IMessage message = _messagesStorage[index];
            OnMessageRemoved(message);
            _messagesStorage.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        #endregion
    }
}