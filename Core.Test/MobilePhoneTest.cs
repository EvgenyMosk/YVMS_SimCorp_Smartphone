using System;
using System.Collections.Generic;

using Core.Enums;

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
