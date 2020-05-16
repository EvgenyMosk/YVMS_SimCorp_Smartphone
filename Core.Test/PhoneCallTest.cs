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
	public class PhoneCallTest {
		private class FakeContact : IContact {
			public FakeContact(string name, IList<PhoneNumber> phoneNumbers) {
				Name = name;
				PhoneNumbers = phoneNumbers;
			}
			public string Name { get; set; }
			public IList<PhoneNumber> PhoneNumbers { get; set; }
			public int CompareTo(IContact other) {
				throw new NotImplementedException();
			}
		}

		private IContact _fakeContact1;
		private IContact _fakeContact2;

		[TestInitialize]
		public void SetUp() {
			string name1 = "Contact 1";
			List<PhoneNumber> phoneNumbers1 = new List<PhoneNumber> {
				new PhoneNumber(380, 99, 1234567),
				new PhoneNumber(380, 98, 3456789)
			};
			_fakeContact1 = new FakeContact(name1, phoneNumbers1);

			string name2 = "Contact 2";
			List<PhoneNumber> phoneNumbers2 = new List<PhoneNumber> {
				new PhoneNumber(380, 98, 7654321),
				new PhoneNumber(380, 99, 9876543)
			};
			_fakeContact2 = new FakeContact(name2, phoneNumbers2);
		}

		[TestMethod]
		public void CompareTo_SortList_ListIsNotSorted_ExpectElementsWasNotSwapped() {
			//Arrange
			PhoneNumber phoneNumber_call1 = _fakeContact1.PhoneNumbers[0];
			DateTime callDate_call1 = new DateTime(2010, 06, 08);
			PhoneCall call1 = new PhoneCall(_fakeContact1, phoneNumber_call1, PhoneCallType.IncomingSuccessfull, callDate_call1);

			PhoneNumber phoneNumber_call2 = _fakeContact2.PhoneNumbers[0];
			DateTime callDate_call2 = new DateTime(2010, 06, 06);
			PhoneCall call2 = new PhoneCall(_fakeContact2, phoneNumber_call2, PhoneCallType.OutgoingSuccessfull, callDate_call2);

			List<PhoneCall> phoneCallsForTest = new List<PhoneCall> {
				call1,
				call2
			};

			PhoneCall expectedCall_firstInList = phoneCallsForTest[0];
			PhoneCall expectedCall_secondInList = phoneCallsForTest[1];
			PhoneCall actualCall_firstInList;
			PhoneCall actualCall_secondInList;

			// Act
			phoneCallsForTest.Sort();

			actualCall_firstInList = phoneCallsForTest[0];
			actualCall_secondInList = phoneCallsForTest[1];

			// Assert
			Assert.AreEqual(expectedCall_firstInList, actualCall_firstInList);
			Assert.AreEqual(expectedCall_secondInList, actualCall_secondInList);
		}

		[TestMethod]
		public void CompareTo_SortList_ListIsAlreadySorted_ExpectElementsWasSwapped() {
			//Arrange
			PhoneNumber phoneNumber_call1 = _fakeContact1.PhoneNumbers[0];
			DateTime callDate_call1 = new DateTime(2010, 06, 06);
			PhoneCall call1 = new PhoneCall(_fakeContact1, phoneNumber_call1, PhoneCallType.IncomingSuccessfull, callDate_call1);

			PhoneNumber phoneNumber_call2 = _fakeContact2.PhoneNumbers[0];
			DateTime callDate_call2 = new DateTime(2010, 06, 08);
			PhoneCall call2 = new PhoneCall(_fakeContact2, phoneNumber_call2, PhoneCallType.OutgoingSuccessfull, callDate_call2);

			List<PhoneCall> phoneCallsForTest = new List<PhoneCall> {
				call1,
				call2
			};

			PhoneCall expectedCall_firstInList = phoneCallsForTest[1];
			PhoneCall expectedCall_secondInList = phoneCallsForTest[0];
			PhoneCall actualCall_firstInList;
			PhoneCall actualCall_secondInList;

			// Act
			phoneCallsForTest.Sort();

			actualCall_firstInList = phoneCallsForTest[0];
			actualCall_secondInList = phoneCallsForTest[1];

			// Assert
			Assert.AreEqual(expectedCall_firstInList, actualCall_firstInList);
			Assert.AreEqual(expectedCall_secondInList, actualCall_secondInList);
		}

		[TestMethod]
		public void CompareTo_SecondElementIsNotAPhoneCall_ExpectExceptionThrown() {
			//Arrange
			PhoneNumber phoneNumber_call1 = _fakeContact1.PhoneNumbers[0];
			DateTime callDate_call1 = new DateTime(2010, 06, 06);
			PhoneCall call1 = new PhoneCall(_fakeContact1, phoneNumber_call1, PhoneCallType.IncomingSuccessfull, callDate_call1);

			object call2 = new FakeContact("name", new List<PhoneNumber>());

			bool exceptionThrown = false;

			// Act
			try {
				call1.CompareTo(call2);
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			// Assert
			Assert.IsTrue(exceptionThrown);
		}
	}
}
