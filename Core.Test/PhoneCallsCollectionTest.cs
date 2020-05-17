using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;
using Core.Interfaces;
using Core.SoftwareComponents;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass]
	public class PhoneCallsCollectionTest {
		private List<PhoneNumber> phoneNumbers1;
		private List<PhoneNumber> phoneNumbers2;

		private Contact contact1;
		private Contact contact2;

		private PhoneCall _call1;
		private PhoneCall _call2;

		private PhoneCallsCollection _proneCallsCollectionUnderTest;

		[TestInitialize]
		public void Setup() {
			phoneNumbers1 = new List<PhoneNumber> {
				new PhoneNumber(380, 99, 1234567),
				new PhoneNumber(380, 98, 3456789)
			};
			contact1 = new Contact("Contact 1", phoneNumbers1);
			_call1 = new PhoneCall(contact1, phoneNumbers1[0], PhoneCallType.OutgoingUnsuccessfull, new DateTime(2020, 02, 20));

			phoneNumbers2 = new List<PhoneNumber> {
				new PhoneNumber(380, 99, 7654321),
				new PhoneNumber(380, 63, 8723456)
			};
			contact2 = new Contact("Contact 2", phoneNumbers2);
			_call2 = new PhoneCall(contact2, phoneNumbers2[1], PhoneCallType.OutgoingSuccessfull, new DateTime(2020, 02, 22));

			List<ICall> calls = new List<ICall> {
				_call1,
				_call2
			};
			_proneCallsCollectionUnderTest = new PhoneCallsCollection(calls);
		}
		[TestMethod]
		public void Add_TwoMessagesInListAddingOneMore_ExpectAllMessagesAreSortedInDescendingOrder() {
			List<PhoneNumber> phoneNumbers3 = new List<PhoneNumber> {
				new PhoneNumber(380, 99, 1234567),
				new PhoneNumber(380, 98, 3456789)
			};
			Contact contact3 = new Contact("Contact 3", phoneNumbers3);
			PhoneCall call3 = new PhoneCall(contact3, phoneNumbers3[0], PhoneCallType.OutgoingUnsuccessfull, new DateTime(2020, 02, 21));

			PhoneCall expectedPhoneCall_num1 = _call2;
			PhoneCall expectedPhoneCall_num2 = call3;
			PhoneCall expectedPhoneCall_num3 = _call1;
			PhoneCall actualPhoneCall_num1;
			PhoneCall actualPhoneCall_num2;
			PhoneCall actualPhoneCall_num3;

			_proneCallsCollectionUnderTest.Add(call3);

			actualPhoneCall_num1 = (PhoneCall)_proneCallsCollectionUnderTest[0];
			actualPhoneCall_num2 = (PhoneCall)_proneCallsCollectionUnderTest[1];
			actualPhoneCall_num3 = (PhoneCall)_proneCallsCollectionUnderTest[2];

			Assert.AreEqual(expectedPhoneCall_num1, actualPhoneCall_num1);
			Assert.AreEqual(expectedPhoneCall_num2, actualPhoneCall_num2);
			Assert.AreEqual(expectedPhoneCall_num3, actualPhoneCall_num3);
		}
	}
}
