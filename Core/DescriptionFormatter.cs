using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public static class DescriptionFormatter {
		/// <summary>
		/// Creates a unified description for all classes that implement's ICommonDescription
		/// </summary>
		/// <returns>Formatted description of a given object</returns>
		public static string CreateDescription(ICommonDescription target) {
			string description;

			string model = target.Model;
			string manufacturer = target.Manufacturer;
			int? yearOfProduction = target.YearOfProduction;
			string version = target.Version;

			description = CreateDescription(model, manufacturer, yearOfProduction, version);

			return description;
		}

		public static string CreateDescription(string model, string manufacturer, int? yearOfProduction, string version) {
			StringBuilder description = new StringBuilder();

			if (!string.IsNullOrWhiteSpace(model)) {
				description.AppendLine("Model: " + model);
			}

			if (!string.IsNullOrWhiteSpace(manufacturer)) {
				description.AppendLine("Manufactured by: " + manufacturer);
			}

			if (yearOfProduction != null) {
				description.AppendLine("Produced in: " + yearOfProduction);
			}

			if (!string.IsNullOrWhiteSpace(version)) {
				description.AppendLine("Version: " + version);
			}

			return description.ToString();
		}
		public static void GenerateRandomDescription(ICommonDescription targetForDescription) {
			Random random = new Random();
			GenerateRandomDescription(targetForDescription, random);
		}
		public static void GenerateRandomDescription(ICommonDescription targetForDescription, Random random) {
			int lengthForString = GenerateLength_Helper(random, 1, 20);
			targetForDescription.Model = GenerateRandomString(lengthForString, random);

			lengthForString = GenerateLength_Helper(random, 1, 20);
			targetForDescription.Manufacturer = GenerateRandomString(lengthForString, random);

			targetForDescription.YearOfProduction = random.Next(DateTime.Now.Year - 20, DateTime.Now.Year);

			lengthForString = GenerateLength_Helper(random, 1, 20);
			targetForDescription.Version = GenerateRandomString(lengthForString, random);
		}
		private static int GenerateLength_Helper(Random random, int min, int max) {
			return random.Next(min, max);
		}
		public static string GenerateRandomString(int length, Random random) {
			if (length <= 0 || random == null) {
				return "";
			}
			//https://www.educative.io/edpresso/how-to-generate-a-random-string-in-c-sharp
			StringBuilder word = new StringBuilder();
			char letter;

			for (int i = 0; i < length; i++) {
				double flt = random.NextDouble();
				int shift = Convert.ToInt32(Math.Floor(25 * flt));
				letter = Convert.ToChar(shift + 65);
				word.Append(letter);
			}

			return word.ToString();
		}
		public static string GenerateRandomVersion(int length, Random random) {
			if (length <= 0) {
				return "";
			}

			StringBuilder version = new StringBuilder();
			version.Append("v");
			int number = 0;

			for (int i = 0; i < length; i++) {
				number = random.Next(0, int.MaxValue);
				version.Append("." + Convert.ToString(number));
			}

			return version.ToString();
		}
	}
}
