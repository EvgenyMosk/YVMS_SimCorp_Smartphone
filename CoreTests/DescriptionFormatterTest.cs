using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass()]
	public class DescriptionFormatterTest {
		[TestMethod]
		public void CreateDescription_ModelManufYearVer_ExpectFullDescription() {
			string model = "TheModelThatWasSet";
			string manufacturer = "SomeSortOfManufacturer";
			int yearOfProduction = 1916;
			string version = "0.1.2.3.4.5.6.7.8.9";
			ICommonDescription testSubject = new Microphone {
				Model = model,
				Manufacturer = manufacturer,
				YearOfProduction = yearOfProduction,
				Version = version
			};

			string actualDescription = DescriptionFormatter.CreateDescription(testSubject);
			bool isModelPresent = actualDescription.Contains(model);
			bool isManufacturerPresent = actualDescription.Contains(manufacturer);
			bool isYearPresent = actualDescription.Contains(yearOfProduction.ToString());
			bool isVersionPresent = actualDescription.Contains(version);

			Assert.IsTrue(isModelPresent);
			Assert.IsTrue(isManufacturerPresent);
			Assert.IsTrue(isYearPresent);
			Assert.IsTrue(isVersionPresent);
		}

		[TestMethod]
		public void CreateDescription_ModelYearVer_ExpectDescrWithoutManuf() {
			string model = "TheModelThatWasSet";
			string manufacturer = "SomeSortOfManufacturer";
			int yearOfProduction = 1916;
			string version = "0.1.2.3.4.5.6.7.8.9";
			ICommonDescription testSubject = new Microphone {
				Model = model,
				YearOfProduction = yearOfProduction,
				Version = version
			};

			string actualDescription = DescriptionFormatter.CreateDescription(testSubject);
			bool isModelPresent = actualDescription.Contains(model);
			bool isManufacturerPresent = actualDescription.Contains(manufacturer);
			bool isYearPresent = actualDescription.Contains(yearOfProduction.ToString());
			bool isVersionPresent = actualDescription.Contains(version);

			Assert.IsTrue(isModelPresent);
			Assert.IsFalse(isManufacturerPresent);
			Assert.IsTrue(isYearPresent);
			Assert.IsTrue(isVersionPresent);
		}
		[TestMethod]
		public void CreateDescription_ManufYearVer_ExpectDescrWithoutModel() {
			string model = "TheModelThatWasSet";
			string manufacturer = "SomeSortOfManufacturer";
			int yearOfProduction = 1916;
			string version = "0.1.2.3.4.5.6.7.8.9";
			ICommonDescription testSubject = new Microphone {
				Manufacturer = manufacturer,
				YearOfProduction = yearOfProduction,
				Version = version
			};

			string actualDescription = DescriptionFormatter.CreateDescription(testSubject);
			bool isModelPresent = actualDescription.Contains(model);
			bool isManufacturerPresent = actualDescription.Contains(manufacturer);
			bool isYearPresent = actualDescription.Contains(yearOfProduction.ToString());
			bool isVersionPresent = actualDescription.Contains(version);

			Assert.IsFalse(isModelPresent);
			Assert.IsTrue(isManufacturerPresent);
			Assert.IsTrue(isYearPresent);
			Assert.IsTrue(isVersionPresent);
		}
		[TestMethod]
		public void CreateDescription_ModelManufVer_ExpectDescrWithoutYear() {
			string model = "TheModelThatWasSet";
			string manufacturer = "SomeSortOfManufacturer";
			int yearOfProduction = 1916;
			string version = "0.1.2.3.4.5.6.7.8.9";
			ICommonDescription testSubject = new Microphone {
				Model = model,
				Manufacturer = manufacturer,
				Version = version
			};

			string actualDescription = DescriptionFormatter.CreateDescription(testSubject);
			bool isModelPresent = actualDescription.Contains(model);
			bool isManufacturerPresent = actualDescription.Contains(manufacturer);
			bool isYearPresent = actualDescription.Contains(yearOfProduction.ToString());
			bool isVersionPresent = actualDescription.Contains(version);

			Assert.IsTrue(isModelPresent);
			Assert.IsTrue(isManufacturerPresent);
			Assert.IsFalse(isYearPresent);
			Assert.IsTrue(isVersionPresent);
		}
		[TestMethod]
		public void CreateDescription_ModelManufYear_ExpectDescrWithoutVer() {
			string model = "TheModelThatWasSet";
			string manufacturer = "SomeSortOfManufacturer";
			int yearOfProduction = 1916;
			string version = "0.1.2.3.4.5.6.7.8.9";
			ICommonDescription testSubject = new Microphone {
				Model = model,
				Manufacturer = manufacturer,
				YearOfProduction = yearOfProduction,
			};

			string actualDescription = DescriptionFormatter.CreateDescription(testSubject);
			bool isModelPresent = actualDescription.Contains(model);
			bool isManufacturerPresent = actualDescription.Contains(manufacturer);
			bool isYearPresent = actualDescription.Contains(yearOfProduction.ToString());
			bool isVersionPresent = actualDescription.Contains(version);

			Assert.IsTrue(isModelPresent);
			Assert.IsTrue(isManufacturerPresent);
			Assert.IsTrue(isYearPresent);
			Assert.IsFalse(isVersionPresent);
		}
		[TestMethod]
		public void CreateDescription_AllWhitespaces_ExpectNULLDescription() {
			string model = "";
			string manufacturer = "";
			int? yearOfProduction = null;
			string version = "";
			ICommonDescription testSubject = new Microphone {
				Model = model,
				Manufacturer = manufacturer,
				YearOfProduction = yearOfProduction,
				Version = version
			};
			string expectedDescription = "";

			string actualDescription = DescriptionFormatter.CreateDescription(testSubject);

			Assert.AreEqual(expectedDescription, actualDescription);//.IsNull(actualDescription);
		}
	}
}