﻿using System;
using System.Collections.Generic;

using Core.Enums;
using Core.Interfaces;
using Core.SoftwareComponents;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	public class FakeMobilePhone : IMobilePhone {
		public PhoneBootState PhoneBootState { get; set; }
		public Core.SoftwareComponents.OperatingSystem OperatingSystem { get; set; }
		public IChipset Chipset { get; set; }
		public IAudioOutputDevice AudioOutputDevice { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }
		public IMemory InternalStorage { get; set; }
		public IOutput Output { get; set; }
		public IOutput NotificationsOutput { get; set; }
		public MessagesStorage MessagesStorage { get; set; }
		public IBattery Battery { get; set; }
		public PhoneCallsCollection PhoneCallsStorage { get; set; }

		public void DisableNotifications() {
			throw new NotImplementedException();
		}

		public void EnableNotifications() {
			throw new NotImplementedException();
		}

		public void EnableNotifications(IOutput notificationsOutput) {
			throw new NotImplementedException();
		}

		public void EnableNotifications(IOutput notificationsOutput, IList<IMessage> messagesStorage) {
			throw new NotImplementedException();
		}

		public void NotifyAboutReceivedMessage(object sender, NotificationEventArgs e) {
			throw new NotImplementedException();
		}

		public void ReceiveCall(ICall call) {
			throw new NotImplementedException();
		}

		public void ReceiveCall(IContact contact, PhoneNumber phoneNumber, PhoneCallType callType, DateTime callTime) {
			throw new NotImplementedException();
		}

		public void ReceiveMessage(string senderName, string messageBody) {
			throw new NotImplementedException();
		}
	}
	[TestClass]
	public class MobilePhoneTest {
		[TestMethod]
		public void CreateMobilePhone_PresetMicrosoftLumia() {
			string expectedMobilePhoneModel = "Lumia 640 XL";
			string expectedMobilePhoneManufacturer = "Microsoft";
			int expectedMobilePhoneYearOfProduction = 2015;
			string actualMobilePhoneModel;
			string actualMobilePhoneManufacturer;
			int? actualMobilePhoneYearOfProduction;
			PresetsPhones presetToUse = PresetsPhones.MicrosoftLumia640XL;

			IMobilePhone testPhone = MobilePhone.CreateMobilePhone(presetToUse);
			actualMobilePhoneModel = testPhone.Model;
			actualMobilePhoneManufacturer = testPhone.Manufacturer;
			actualMobilePhoneYearOfProduction = testPhone.YearOfProduction;

			Assert.IsNotNull(testPhone);
			Assert.AreEqual(expectedMobilePhoneModel.ToLower().Trim(), actualMobilePhoneModel.ToLower().Trim());
			Assert.AreEqual(expectedMobilePhoneManufacturer.ToLower().Trim(), actualMobilePhoneManufacturer.ToLower().Trim());
			Assert.AreEqual(expectedMobilePhoneYearOfProduction, actualMobilePhoneYearOfProduction);
		}
		[TestMethod]
		public void InstallOperatingSystem_NullMobilePhone_ExpectArgumentNullException() {
			IMobilePhone mobilePhone = null;

			Assert.ThrowsException<ArgumentNullException>(() => MobilePhone.InstallOperatingSystem(mobilePhone, null, null, null, null, 1));
		}
	}
}
