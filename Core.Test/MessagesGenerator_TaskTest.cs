using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Core.Enums;
using Core.Interfaces;
using Core.SoftwareComponents;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass]
	public class MessagesGenerator_TaskTest {
		public class FakeMessage : IMessage {
			public string Sender { get; set; }
			public string Body { get; set; }
			public DateTime ReceivedTime { get; set; }
			public FakeMessage(string sender, string body) {
				Sender = sender;
				Body = body;
				ReceivedTime = new DateTime(2000, 01, 01);
			}
			public bool Equals(IMessage other) {
				throw new NotImplementedException();
			}
		}
		public class FakeMobilePhone : IMobilePhone {
			public PhoneBootState PhoneBootState { get; set; }
			public SoftwareComponents.OperatingSystem OperatingSystem { get; set; }
			public IOutput NotificationsOutput { get; set; }
			public MessagesStorage MessagesStorage { get; set; }
			public IChipset Chipset { get; set; }
			public IAudioOutputDevice AudioOutputDevice { get; set; }
			public IMemory InternalStorage { get; set; }
			public IBattery Battery { get; set; }
			public string Model { get; }
			public string Manufacturer { get; }
			public int? YearOfProduction { get; }
			public string Version { get; set; }

			public void ReceiveMessage(string senderName, string messageBody) {
				FakeMessage message = new FakeMessage(senderName, messageBody);
				MessagesStorage.Add(message);
			}
		}

		public FakeMobilePhone fakeMobilePhone;
		public MessagesGenerator_Task messagesGenerator_Task;
		public int messagesGenerationInterval;

		[TestInitialize]
		public void SetUp() {
			fakeMobilePhone = new FakeMobilePhone {
				MessagesStorage = new MessagesStorage(new List<IMessage>())
			};
			messagesGenerationInterval = 50;
			messagesGenerator_Task = new MessagesGenerator_Task(fakeMobilePhone, messagesGenerationInterval);
		}

		[TestMethod]
		public void StartGeneratingNewMessages_StopGeneratingNewMessages_ExpectFiveMessages() {
			int expectedMsgCountStart = 0;
			int expectedMsgCountEnd = 5;
			int actualMsgCountStart;
			int actualMsgCountEnd;

			actualMsgCountStart = fakeMobilePhone.MessagesStorage.Count;

			messagesGenerator_Task.StartGeneratingNewMessages();
			int waitWhileMsgBeingGenerated = messagesGenerationInterval * 5 + 10;
			Thread.Sleep(waitWhileMsgBeingGenerated);
			messagesGenerator_Task.StopGeneratingNewMessages();

			actualMsgCountEnd = fakeMobilePhone.MessagesStorage.Count;

			Assert.AreEqual(expectedMsgCountStart, actualMsgCountStart);
			Assert.AreEqual(expectedMsgCountEnd, actualMsgCountEnd);
		}
		[TestMethod]
		public void StartGeneratingNewMessages_StopGeneratingNewMessages_ExpectOneMessageAndNoMoreMessagesAreGeneratedAfter() {
			int expectedMsgCountStart = 0;
			int expectedMsgCountEnd = 1;
			int actualMsgCountStart;
			int actualMsgCountEnd;

			actualMsgCountStart = fakeMobilePhone.MessagesStorage.Count;

			messagesGenerator_Task.StartGeneratingNewMessages();
			Thread.Sleep(15);
			messagesGenerator_Task.StopGeneratingNewMessages();
			Thread.Sleep(1000);

			actualMsgCountEnd = fakeMobilePhone.MessagesStorage.Count;

			Assert.AreEqual(expectedMsgCountStart, actualMsgCountStart);
			Assert.AreEqual(expectedMsgCountEnd, actualMsgCountEnd);
		}
	}
}