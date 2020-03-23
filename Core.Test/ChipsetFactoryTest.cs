using System;
using System.Collections.Generic;
using System.Text;

using Core.Enums;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	/// <summary>
	/// Summary description for ChipsetFactoryTest
	/// </summary>
	[TestClass]
	public class ChipsetFactoryTest {
		[TestMethod]
		public void CreateNewChipset_AllDataSnap400_ExpectNewChipset() {
			PresetsChipsets chipsetToBeCreated = PresetsChipsets.Snapdragon400;
			string expectedModel = "Snapdragon 400";
			string expectedManufacturer = "Qualcomm";
			int expectedYearOfProduction = 2015;
			string expectedVersion = "1.1";
			double expectedCPUFrequencyCurrent = 0.0;
			IChipset actualChipset;

			actualChipset = ChipsetFactory.CreateChipset(chipsetToBeCreated);

			Assert.IsNotNull(actualChipset);
			Assert.IsNotNull(actualChipset.CPU);
			Assert.IsNotNull(actualChipset.GPU);
			Assert.AreEqual(expectedCPUFrequencyCurrent, actualChipset.CPU.FrequencyCurrent);
			Assert.AreEqual(expectedModel, actualChipset.Model);
			Assert.AreEqual(expectedManufacturer, actualChipset.Manufacturer);
			Assert.AreEqual(expectedYearOfProduction, actualChipset.YearOfProduction);
			Assert.AreEqual(expectedVersion, actualChipset.Version);
		}
	}
}