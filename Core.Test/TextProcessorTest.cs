using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Core.Test {
	[TestClass]
	public class TextProcessorTest {
		public class FakeObject : ICommonDescription {
			public string Model { get; set; }
			public string Manufacturer { get; set; }
			public int? YearOfProduction { get; set; }
			public string Version { get; set; }
		}
		#region CreateDescription tests
		[TestMethod]
		public void CreateDescription_ModelManufYearVer_ExpectFullDescription() {
			string model = "TheModelThatWasSet";
			string manufacturer = "SomeSortOfManufacturer";
			int yearOfProduction = 1916;
			string version = "0.1.2.3.4.5.6.7.8.9";
			ICommonDescription testObject = new FakeObject {
				Model = model,
				Manufacturer = manufacturer,
				YearOfProduction = yearOfProduction,
				Version = version
			};

			string actualDescription = TextProcessor.CreateDescription(testObject);
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
			ICommonDescription testObject = new FakeObject {
				Model = model,
				YearOfProduction = yearOfProduction,
				Version = version
			};

			string actualDescription = TextProcessor.CreateDescription(testObject);
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
			ICommonDescription testObject = new FakeObject {
				Manufacturer = manufacturer,
				YearOfProduction = yearOfProduction,
				Version = version
			};

			string actualDescription = TextProcessor.CreateDescription(testObject);
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
			ICommonDescription testObject = new FakeObject {
				Model = model,
				Manufacturer = manufacturer,
				Version = version
			};

			string actualDescription = TextProcessor.CreateDescription(testObject);
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
			ICommonDescription testObject = new FakeObject {
				Model = model,
				Manufacturer = manufacturer,
				YearOfProduction = yearOfProduction,
			};

			string actualDescription = TextProcessor.CreateDescription(testObject);
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
		public void CreateDescription_AllWhitespaces_ExpectBlankDescription() {
			string model = "";
			string manufacturer = "";
			int? yearOfProduction = null;
			string version = "";
			ICommonDescription testObject = new FakeObject {
				Model = model,
				Manufacturer = manufacturer,
				YearOfProduction = yearOfProduction,
				Version = version
			};
			string expectedDescription = "";

			string actualDescription = TextProcessor.CreateDescription(testObject);

			Assert.AreEqual(expectedDescription, actualDescription);
		}
		#endregion End of CreateDescription
		#region FormatByDefault, FormatWithDateAtStart, FormatWithDateAtEnd, FormatWithUppercase, FormatWithLowercase tests
		[TestMethod]
		public void FormatByDefault_NullString_ExpectBlank() {
			string text = null;
			string expectedResult = string.Empty;
			string actualResult;

			actualResult = TextProcessor.FormatByDefault(text);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatByDefault_NotNullString_ExpectSameString() {
			string text = "Test text.";
			string expectedResult = text;
			string actualResult;

			actualResult = TextProcessor.FormatByDefault(text);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatWithDateAtStart_NullString_ExpectEmptyString() {
			string text = null;
			string expectedResult = string.Empty;
			string actualResult;

			actualResult = TextProcessor.FormatWithDateAtStart(text);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatWithDateAtStart_NotNullString_ExpectStringWithDateAtStart() {
			string text = "Test text.";
			string expectedResult = text;
			string actualResult;
			string currentDateTime = DateTime.Now.ToShortTimeString();

			actualResult = TextProcessor.FormatWithDateAtStart(text);

			expectedResult = "[" + currentDateTime + "] " + expectedResult;
			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatWithDateAtEnd_NullString_ExpectEmptyString() {
			string text = null;
			string expectedResult = string.Empty;
			string actualResult;

			actualResult = TextProcessor.FormatWithDateAtEnd(text);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatWithDateAtEnd_NotNullString_ExpectStringWithDateAtEnd() {
			string text = "Test text.";
			string expectedResult = text;
			string actualResult;
			string currentDateTime = DateTime.Now.ToShortTimeString();

			actualResult = TextProcessor.FormatWithDateAtEnd(text);

			expectedResult = expectedResult + " [" + currentDateTime + "]";
			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatWithUppercase_NullString_ExpectEmptyString() {
			string text = null;
			string expectedResult = string.Empty;
			string actualResult;

			actualResult = TextProcessor.FormatWithUppercase(text);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatWithUppercase_NotNullString_ExpectStringWithAllLettersInUppercase() {
			string text = "Test text.";
			string expectedResult = "TEST TEXT.";
			string actualResult;

			actualResult = TextProcessor.FormatWithUppercase(text);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatWithLowercase_NullString_ExpectEmptyString() {
			string text = null;
			string expectedResult = string.Empty;
			string actualResult;

			actualResult = TextProcessor.FormatWithLowercase(text);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void FormatWithLowercase_NotNullString_ExpectStringWithAllLettersInLowercase() {
			string text = "Test text.";
			string expectedResult = "test text.";
			string actualResult;

			actualResult = TextProcessor.FormatWithLowercase(text);

			Assert.AreEqual(expectedResult, actualResult);
		}
		#endregion End of Format.. tests
	}
}