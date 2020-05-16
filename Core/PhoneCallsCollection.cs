using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core {
	public class PhoneCallsCollection : IList<ICall> {
		private List<ICall> _callsList;

		public PhoneCallsCollection(List<ICall> callsList) {
			if (callsList != null) {
				_callsList = callsList;
			} else {
				_callsList = new List<ICall>();
			}
		}

		#region IList implementation
		public ICall this[int index] {
			get {
				return _callsList[index];
			}
			set {
				_callsList[index] = value;
			}
		}

		public int Count { get { return _callsList.Count; } }
		public bool IsReadOnly { get { return false; } }

		public void Add(ICall item) {
			_callsList.Add(item);
			_callsList.Sort();
		}

		public void Clear() {
			_callsList.Clear();
		}

		public bool Contains(ICall item) {
			return _callsList.Contains(item);
		}

		public void CopyTo(ICall[] array, int arrayIndex) {
			_callsList.CopyTo(array, arrayIndex);
		}

		public IEnumerator<ICall> GetEnumerator() {
			return _callsList.GetEnumerator();
		}

		public int IndexOf(ICall item) {
			return _callsList.IndexOf(item);
		}

		public void Insert(int index, ICall item) {
			_callsList.Insert(index, item);
		}

		public bool Remove(ICall item) {
			return _callsList.Remove(item);
		}

		public void RemoveAt(int index) {
			_callsList.RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
		#endregion
	}
}
