using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass()]
	public class MessagesStorageTests {
		#region Fake message
		private class FakeMessage : IMessage {
			public string Sender { get; set; }
			public string Body { get; set; }
			public DateTime ReceivedTime { get; set; }
			public FakeMessage(string sender, string body, DateTime receivedTime) {
				Sender = sender;
				Body = body;
				ReceivedTime = receivedTime;
			}
			public bool Equals(IMessage other) {
				if (other is null) {
					return false;
				}
				return Sender == other.Sender
					&& Body == other.Body
					&& ReceivedTime == other.ReceivedTime;
			}
		}
		#endregion
		private MessagesStorage messagesStorageUnderTest1;
		[TestInitialize]
		public void SetUp() {
			List<IMessage> messages1 = new List<IMessage> {
				new FakeMessage("Sender #1","Body #1", new DateTime(2001,01,01)),
				new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
				new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
				new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
				new FakeMessage("Sender #3","Body #5", new DateTime(2005,05,05))
			};
			messagesStorageUnderTest1 = new MessagesStorage(messages1);
		}

		[TestMethod()]
		public void GetMessages_ExpectFiveMessagesFromStorageNumberOne() {
			int expectedCount = 5;
			int actualCount;

			actualCount = messagesStorageUnderTest1.GetMessages().Count;

			Assert.AreEqual(expectedCount, actualCount);
		}
		[TestMethod()]
		public void GetMessagesSenders_ExpectThreeSenders() {
			List<string> expectedSenders = new List<string> {
				"Sender #1","Sender #2","Sender #3"
			};
			List<string> actualSenders = new List<string>();

			actualSenders = messagesStorageUnderTest1.GetMessagesSenders().ToList();

			Assert.AreEqual(actualSenders.Count, expectedSenders.Count);
			foreach (string sender in expectedSenders) {
				Assert.IsTrue(actualSenders.Contains(sender));
			}
		}
		[TestMethod()]
		public void GetMessagesFromCertainSender_SenderThatIsNotPresentInMessages_ExpectNoMessages() {
			List<IMessage> expectedMessages = new List<IMessage>();
			List<IMessage> actualMessages = new List<IMessage>();
			string targetSender = "Sender #123";

			actualMessages = messagesStorageUnderTest1.GetMessagesFromCertainSender(targetSender).ToList();

			Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
		}
		[TestMethod()]
		public void GetMessagesFromCertainSender_SenderThatIsPresentTwoTimesInMessages_ExpectTwoMessages() {
			List<IMessage> expectedMessages = new List<IMessage> {
				new FakeMessage("Sender #2", "Body #3", new DateTime(2003, 03, 03)),
				new FakeMessage("Sender #2", "Body #4", new DateTime(2004, 04, 04))
			};
			List<IMessage> actualMessages = new List<IMessage>();
			string targetSender = "Sender #2";

			actualMessages = messagesStorageUnderTest1.GetMessagesFromCertainSender(targetSender).ToList();

			Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
			foreach (IMessage message in expectedMessages) {
				Assert.IsTrue(actualMessages.Contains(message));
			}
		}
		[TestMethod()]
		public void GetMessagesContainsCertainText_TextNotPresentInMsgsBody_ExpectNoMessage() {
			List<IMessage> expectedMessages = new List<IMessage>();
			List<IMessage> actualMessages = new List<IMessage>();
			string targetText = "Target text";

			actualMessages = messagesStorageUnderTest1.GetMessagesContainsCertainText(targetText).ToList();

			Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
		}
		[TestMethod()]
		public void GetMessagesContainsCertainText_TextThatPresentInOneMessage_ExpectOneMessage() {
			List<IMessage> expectedMessages = new List<IMessage> {
				new FakeMessage("Sender #2", "Body #4", new DateTime(2004, 04, 04))
			};
			List<IMessage> actualMessages = new List<IMessage>();
			string targetText = "4";

			actualMessages = messagesStorageUnderTest1.GetMessagesContainsCertainText(targetText).ToList();

			Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
			Assert.IsTrue(actualMessages.Contains(expectedMessages.First()));
		}
		[TestMethod()]
		public void GetMessagesContainsCertainText_TextThatPresentInAllFiveMessage_ExpectAllFiveMessage() {
			List<IMessage> expectedMessages = new List<IMessage> {
				new FakeMessage("Sender #1","Body #1", new DateTime(2001,01,01)),
				new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
				new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
				new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
				new FakeMessage("Sender #3","Body #5", new DateTime(2005,05,05)),
			};
			List<IMessage> actualMessages = new List<IMessage>();
			string targetText = "Body";

			actualMessages = messagesStorageUnderTest1.GetMessagesContainsCertainText(targetText).ToList();

			Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
			foreach (IMessage message in expectedMessages) {
				Assert.IsTrue(actualMessages.Contains(message));
			}
		}
		[TestMethod()]
		public void GetMessagesBetweenDates_BothDatesAreEarlierThanAllDates_ExpectNoMessages() {
			List<IMessage> expectedMessages = new List<IMessage>();
			List<IMessage> actualMessages = new List<IMessage>();
			DateTime targetFromDate = new DateTime(1900, 01, 01);
			DateTime targetToDate = new DateTime(1999, 01, 01);

			actualMessages = messagesStorageUnderTest1.GetMessagesBetweenDates(targetFromDate, targetToDate).ToList();

			Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
		}
		[TestMethod()]
		public void GetMessagesBetweenDates_DatesToGet3Messages_ExpectAllFiveMessages() {
			List<IMessage> expectedMessages = new List<IMessage> {
				new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
				new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
				new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
			};
			List<IMessage> actualMessages = new List<IMessage>();
			DateTime targetFromDate = new DateTime(2002, 02, 02);
			DateTime targetToDate = new DateTime(2004, 04, 04);

			actualMessages = messagesStorageUnderTest1.GetMessagesBetweenDates(targetFromDate, targetToDate).ToList();

			Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
			foreach (IMessage message in expectedMessages) {
				Assert.IsTrue(actualMessages.Contains(message));
			}
		}
		[TestMethod()]
		public void GetMessagesBetweenDates_1stDateEarlierThanAllMsgs2ndLaterThanAllMsgs_ExpectAllFiveMessages() {
			List<IMessage> expectedMessages = new List<IMessage> {
				new FakeMessage("Sender #1","Body #1", new DateTime(2001,01,01)),
				new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
				new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
				new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
				new FakeMessage("Sender #3","Body #5", new DateTime(2005,05,05)),
			};
			List<IMessage> actualMessages = new List<IMessage>();
			DateTime targetFromDate = new DateTime(1900, 01, 01);
			DateTime targetToDate = new DateTime(2100, 01, 01);

			actualMessages = messagesStorageUnderTest1.GetMessagesBetweenDates(targetFromDate, targetToDate).ToList();

			Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
			foreach (IMessage message in expectedMessages) {
				Assert.IsTrue(actualMessages.Contains(message));
			}
		}
		[TestMethod()]
		public void GetMessagesBetweenDates_1stDateLaterThan2ndDate_ExpectArgumentException() {
			List<IMessage> expectedMessages = new List<IMessage>();
			List<IMessage> actualMessages = new List<IMessage>();
			DateTime targetFromDate = new DateTime(2100, 01, 01);
			DateTime targetToDate = new DateTime(1900, 01, 01);

			bool exceptionThrown = false;

			try {
				actualMessages = messagesStorageUnderTest1.GetMessagesBetweenDates(targetFromDate, targetToDate).ToList();
			} catch (ArgumentException) {
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown);
		}
		[TestMethod()]
		public void ApplyAND_AllListsContainsDifferentMessages_ExpectNoMessages() {
			List<IMessage> messagesPool = new List<IMessage> {
				new FakeMessage("Sender #1","Body #1", new DateTime(2001,01,01)),
				new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
				new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
				new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
				new FakeMessage("Sender #3","Body #5", new DateTime(2005,05,05)),
				new FakeMessage("Sender #3","Body #6", new DateTime(2006,06,06)),
				new FakeMessage("Sender #4","Body #7", new DateTime(2007,07,07))
			};
			IEnumerable<IMessage> messagesFilteredBySender = new List<IMessage> {
				messagesPool[0],
				messagesPool[1],
			};
			IEnumerable<IMessage> messagesFilteredByText = new List<IMessage>{
				messagesPool[2],
				messagesPool[3],
				messagesPool[4],
			};
			IEnumerable<IMessage> messagesFilteredByDate = new List<IMessage> {
				messagesPool[5],
				messagesPool[6],
			};
			IEnumerable<IMessage> expectedMessages = new List<IMessage>();
			IEnumerable<IMessage> actualMessages = new List<IMessage>();

			actualMessages = MessagesStorage.ApplyAND(messagesFilteredBySender, messagesFilteredByText, messagesFilteredByDate).ToList();

			Assert.AreEqual(expectedMessages.Count(), actualMessages.Count());
		}
		[TestMethod()]
		public void ApplyAND_AllListsContainsSomeMessages_ExpectThreeMessagesPresentInAllLists() {
			List<IMessage> messagesPool = new List<IMessage> {
				new FakeMessage("Sender #1","Body #1", new DateTime(2001,01,01)),
				new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
				new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
				new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
				new FakeMessage("Sender #3","Body #5", new DateTime(2005,05,05)),
				new FakeMessage("Sender #3","Body #6", new DateTime(2006,06,06)),
				new FakeMessage("Sender #4","Body #7", new DateTime(2007,07,07))
			};
			IEnumerable<IMessage> messagesFilteredBySender = new List<IMessage> {
				messagesPool[0],
				messagesPool[1],
				messagesPool[2],
				messagesPool[3],
				messagesPool[4],
			};
			IEnumerable<IMessage> messagesFilteredByText = new List<IMessage>{
				messagesPool[1],
				messagesPool[2],
				messagesPool[3],
				messagesPool[4],
				messagesPool[5],
			};
			IEnumerable<IMessage> messagesFilteredByDate = new List<IMessage> {
				messagesPool[2],
				messagesPool[3],
				messagesPool[4],
				messagesPool[5],
				messagesPool[6],
			};
			IEnumerable<IMessage> expectedMessages = new List<IMessage> {
				messagesPool[2],
				messagesPool[3],
				messagesPool[4],
			};
			IEnumerable<IMessage> actualMessages = new List<IMessage>();

			actualMessages = MessagesStorage.ApplyAND(messagesFilteredBySender, messagesFilteredByText, messagesFilteredByDate).ToList();

			Assert.AreEqual(expectedMessages.Count(), actualMessages.Count());
		}
	}
}