using System;
using System.Collections.Generic;

using Core.Enums;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	public class FakeMobilePhone : IMobilePhone {
		public PhoneBootState PhoneBootState { get; set; }
		public Recovery Recovery { get; set; }
		public Bootloader Bootloader { get; set; }
		public OperatingSystem OperatingSystem { get; set; }
		public IChipset Chipset { get; set; }
		public List<SimCard> SimCards { get; set; }
		public IDisplay Screen { get; set; }
		public Button PowerButton { get; set; }
		public NetworkModule NetworkModule { get; set; }
		public IAudioInputDevice AudioInputDevice { get; set; }
		public IAudioOutputDevice<object> AudioOutputDevice { get; set; }
		public IPowerSource Battery { get; set; }
		public RAM RAM { get; set; }
		public Storage InternalStorage { get; set; }
		public Case Case { get; set; }
		public string Model { get; set; }
		public string Manufacturer { get; set; }
		public int? YearOfProduction { get; set; }
		public string Version { get; set; }

		public string GetDescription() {
			throw new NotImplementedException();
		}
	}
	[TestClass]
	public class MobilePhoneConfiguratorTest {
		private IMobilePhone GetFakePhone() {
			return new FakeMobilePhone();
		}
		[TestMethod]
		public void CreateMobilePhone_PresetMicrosoftLumia() {
			string expectedMobilePhoneModel = "Lumia 640 XL";
			string expectedMobilePhoneManufacturer = "Microsoft";
			int expectedMobilePhoneYearOfProduction = 2015;
			string actualMobilePhoneModel;
			string actualMobilePhoneManufacturer;
			int? actualMobilePhoneYearOfProduction;
			PresetsPhones presetToUse = PresetsPhones.MicrosoftLumia640XL;

			IMobilePhone testPhone = MobilePhoneConfigurator.CreateMobilePhone(presetToUse);
			actualMobilePhoneModel = testPhone.Model;
			actualMobilePhoneManufacturer = testPhone.Manufacturer;
			actualMobilePhoneYearOfProduction = testPhone.YearOfProduction;

			Assert.IsNotNull(testPhone);
			Assert.AreEqual(expectedMobilePhoneModel.ToLower().Trim(), actualMobilePhoneModel.ToLower().Trim());
			Assert.AreEqual(expectedMobilePhoneManufacturer.ToLower().Trim(), actualMobilePhoneManufacturer.ToLower().Trim());
			Assert.AreEqual(expectedMobilePhoneYearOfProduction, actualMobilePhoneYearOfProduction);
		}
		[TestMethod]
		public void InstallRecovery_NullMobilePhone_ExpectArgumentNullException() {
			IMobilePhone mobilePhone = null;

			Assert.ThrowsException<ArgumentNullException>(() => MobilePhoneConfigurator.InstallRecovery(mobilePhone));
		}
		//[TestMethod]
		//public void InstallRecovery_NotNullMobilePhone_ExpectNotNullRecovery() {
		//	IMobilePhone mobilePhone = GetFakePhone();

		//	Assert.IsNotNull(mobilePhone.Recovery);
		//}
		[TestMethod]
		public void InstallBootloader_NullMobilePhone_ExpectArgumentNullException() {
			IMobilePhone mobilePhone = null;

			Assert.ThrowsException<ArgumentNullException>(() => MobilePhoneConfigurator.InstallBootloader(mobilePhone));
		}
		//[TestMethod]
		//public void InstallBootloader_NotNullMobilePhone_ExpectNotNullBootloader() {
		//	IMobilePhone mobilePhone = GetFakePhone();

		//	Assert.IsNotNull(mobilePhone.Bootloader);
		//}
		[TestMethod]
		public void InstallOperatingSystem_NullMobilePhone_ExpectArgumentNullException() {
			IMobilePhone mobilePhone = null;

			Assert.ThrowsException<ArgumentNullException>(() => MobilePhoneConfigurator.InstallOperatingSystem(mobilePhone));
		}
		//[TestMethod]
		//public void InstallOperatingSystem_NotNullMobilePhone_ExpectNotNullOperatingSystem() {
		//	IMobilePhone mobilePhone = GetFakePhone();

		//	Assert.IsNotNull(mobilePhone.OperatingSystem);
		//}
	}
}
