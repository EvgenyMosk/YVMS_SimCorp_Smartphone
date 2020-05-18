using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;
using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class PhoneCall : ICall {
		public IContact Contact { get; }
		public PhoneNumber PhoneNumber { get; }
		public PhoneCallType CallType { get; }
		public DateTime CallTime { get; }

		public PhoneCall(IContact contact, PhoneNumber phoneNumber, PhoneCallType callType, DateTime callTime) {
			Contact = contact;
			PhoneNumber = phoneNumber;
			CallType = callType;
			CallTime = callTime;
		}

		public int CompareTo(object other) {
			PhoneCall otherCall = other as PhoneCall;

			if (otherCall != null) {
				return CallTime.CompareTo(otherCall.CallTime) * -1; // Calls should be sorted in Descending order
			} else {
				throw new ArgumentException($"Comparison must done between {GetType()} objects!", nameof(other));
			}
		}

		public override bool Equals(object obj) {
			return obj is PhoneCall call &&
				   EqualityComparer<IContact>.Default.Equals(Contact, call.Contact) &&
				   EqualityComparer<PhoneNumber>.Default.Equals(PhoneNumber, call.PhoneNumber) &&
				   CallType == call.CallType;
		}

		public override int GetHashCode() {
			int hashCode = 1428611746;
			hashCode = hashCode * -1521134295 + EqualityComparer<IContact>.Default.GetHashCode(Contact);
			hashCode = hashCode * -1521134295 + EqualityComparer<PhoneNumber>.Default.GetHashCode(PhoneNumber);
			hashCode = hashCode * -1521134295 + CallType.GetHashCode();
			hashCode = hashCode * -1521134295 + CallTime.GetHashCode();
			return hashCode;
		}
	}
}