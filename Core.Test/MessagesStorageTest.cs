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
				return Sender == other.Sender && Body == other.Body && ReceivedTime == other.ReceivedTime;
			}
		}
		#endregion
		private MessagesStorage messagesStorageUnderTest1;
		private MessagesStorage messagesStorageUnderTest2;
		private MessagesStorage messagesStorageUnderTest3;
		[TestInitialize]
		public void SetUp() {
			List<IMessage> messages1 = new List<IMessage> {
				new FakeMessage("Sender #1","Body #1", new DateTime(2001,01,01)),
				new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
				new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
				new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
				new FakeMessage("Sender #3","Body #5", new DateTime(2005,05,05)),
			};
			List<IMessage> messages2 = new List<IMessage> {
				new FakeMessage("Sender #3","Body #3", new DateTime(2003,03,03)),
				new FakeMessage("Sender #4","Body #4", new DateTime(2004,04,04)),
				new FakeMessage("Sender #4","Body #5", new DateTime(2005,05,05)),
				new FakeMessage("Sender #5","Body #6", new DateTime(2006,06,06)),
				new FakeMessage("Sender #5","Body #7", new DateTime(2007,07,07)),
			};
			List<IMessage> messages3 = new List<IMessage> {
				new FakeMessage("Sender #6","Body #5", new DateTime(2005,05,05)),
				new FakeMessage("Sender #6","Body #6", new DateTime(2006,06,06)),
				new FakeMessage("Sender #7","Body #7", new DateTime(2007,07,07)),
				new FakeMessage("Sender #7","Body #8", new DateTime(2008,08,08)),
				new FakeMessage("Sender #8","Body #9", new DateTime(2009,09,09)),
			};

			messagesStorageUnderTest1 = new MessagesStorage(messages1);
			messagesStorageUnderTest2 = new MessagesStorage(messages2);
			messagesStorageUnderTest3 = new MessagesStorage(messages3);
		}

		[TestMethod()]
		public void GetMessages_ExpectFiveMessagesFromStorageNumberOne() {
			int expectedCount = 5;
			int actualCount;

			actualCount = messagesStorageUnderTest1.GetMessages().Count;

			Assert.AreEqual(expectedCount, actualCount);
		}
		[TestMethod()]
		public void GetMessagesSenders_ExpectThreeSEnders() {
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
		public void GetMessagesFromCertainSender_ExpectTwoMessages() {
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
		public void GetMessagesContainsCertainText_TextThatPresentInAllFiveMessage_ExpectOneMessage() {
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
		//[TestMethod()]
		//public void GetMessagesBetweenDates_1stDateEarlierThanAllMsgs2ndLaterThanAllMsgs_ExpectAllFiveMessages() {
		//	List<IMessage> expectedMessages = new List<IMessage> {
		//		new FakeMessage("Sender #1","Body #1", new DateTime(2001,01,01)),
		//		new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
		//		new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
		//		new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
		//		new FakeMessage("Sender #3","Body #5", new DateTime(2005,05,05)),
		//	};
		//	List<IMessage> actualMessages = new List<IMessage>();
		//	string targetText = "Body";

		//	actualMessages = messagesStorageUnderTest1.GetMessagesContainsCertainText(targetText).ToList();

		//	Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
		//	foreach (IMessage message in expectedMessages) {
		//		Assert.IsTrue(actualMessages.Contains(message));
		//	}
		//}
		//[TestMethod()]
		//public void GetMessagesBetweenDates_1stDateEarlierThanAllMsgs2ndLaterThanAllMsgs_ExpectAllFiveMessages() {
		//	List<IMessage> expectedMessages = new List<IMessage> {
		//		new FakeMessage("Sender #1","Body #1", new DateTime(2001,01,01)),
		//		new FakeMessage("Sender #1","Body #2", new DateTime(2002,02,02)),
		//		new FakeMessage("Sender #2","Body #3", new DateTime(2003,03,03)),
		//		new FakeMessage("Sender #2","Body #4", new DateTime(2004,04,04)),
		//		new FakeMessage("Sender #3","Body #5", new DateTime(2005,05,05)),
		//	};
		//	List<IMessage> actualMessages = new List<IMessage>();
		//	string targetText = "Body";

		//	actualMessages = messagesStorageUnderTest1.GetMessagesContainsCertainText(targetText).ToList();

		//	Assert.AreEqual(expectedMessages.Count, actualMessages.Count);
		//	foreach (IMessage message in expectedMessages) {
		//		Assert.IsTrue(actualMessages.Contains(message));
		//	}
		//}
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
	}
}