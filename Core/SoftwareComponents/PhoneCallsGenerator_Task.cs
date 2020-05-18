using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;
using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class PhoneCallsGenerator_Task : MessagesGenerator_Task {
		protected readonly IList<IContact> _defaultContacts;
		public PhoneCallsGenerator_Task(IMobilePhone mobilePhone, int messagesGenerationInterval) : base(mobilePhone, messagesGenerationInterval) {
			_defaultContacts = TextProcessor.GetDefaultContactsList();
		}

		protected override void GenerateNewMessage() {
			int contact_generatedIndex = TextProcessor.GetRandomNumber(_defaultContacts.Count);
			IContact contact = _defaultContacts[contact_generatedIndex];

			int phoneNum_generatedIndex = TextProcessor.GetRandomNumber(contact.PhoneNumbers.Count);
			PhoneNumber phoneNumber = contact.PhoneNumbers[phoneNum_generatedIndex];

			PhoneCallType callType = TextProcessor.GetRandomCallType();

			DateTime callTime = DateTime.Now;//TextProcessor.GetRandomDateTime();

			ICall call = new PhoneCall(contact, phoneNumber, callType, callTime);

			SendCallToSmartphone(call);
		}

		protected virtual void SendCallToSmartphone(ICall call) {
			_mobilePhone.ReceiveCall(call);
		}
	}
}