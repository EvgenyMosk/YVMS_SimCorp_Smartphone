using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public static class TextProcessor {
		private static readonly string[] _messagesTexts = { "Payment successful! See details at: https://privatbank.ua/payments/mypayments",
			"Your order arrived at destination country!",
			"Update available!",
			"You missed 3 calls from +3809987654321",
			"Money transfer successful!",
			"New video from Metallica Official Channel, watch now: you.tu/jsdka",
			".NET Core 3.3.3.81 available for download!",
			"Login to your account from new device."};
		private static readonly string[] _messagesSenders = { "SimCorp Ltd.",
			"Microsoft Corporation",
			"System Notification Service" };
		private static readonly Random _random = new Random();
		private delegate string MessageFormatDelegate(string text);
		private static MessageFormatDelegate _formatter = FormatByDefault;

		public static string GetRandomSender() {
			int senderIndex = _random.Next(_messagesSenders.Length);
			return _messagesSenders[senderIndex];
		}
		public static string GetRandomMessage() {
			int messageIndex = _random.Next(_messagesTexts.Length);
			return _messagesTexts[messageIndex];
		}

		public static string GetFormattedText(string text) {
			return _formatter(text);
		}
		public static string GetFormattedText(string text, int indexSelected) {
			SelectFormatter(indexSelected);
			return GetFormattedText(text);
		}

		public static void SelectFormatter(int indexSelected) {
			switch (indexSelected) {
				case 0:
					_formatter = FormatByDefault;
					break;
				case 1:
					_formatter = FormatWithDateAtStart;
					break;
				case 2:
					_formatter = FormatWithDateAtEnd;
					break;
				case 3:
					_formatter = FormatWithUppercase;
					break;
				case 4:
					_formatter = FormatWithLowercase;
					break;
				default:
					throw new ArgumentException("Given value is not supported!", nameof(indexSelected));
			}
		}
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
		public static void GenerateRandomDescription() {
			Random random = new Random();
			GenerateRandomDescription(random);
		}
		public static DescriptionContainer GenerateRandomDescription(Random random) {
			DescriptionContainer description;

			int lengthForString = GenerateLength_Helper(random, 1, 20);
			string model = GenerateRandomString(lengthForString, random);

			lengthForString = GenerateLength_Helper(random, 1, 20);
			string manufacturer = GenerateRandomString(lengthForString, random);

			int yearOfProduction = random.Next(DateTime.Now.Year - 20, DateTime.Now.Year);

			lengthForString = GenerateLength_Helper(random, 1, 20);
			string version = GenerateRandomString(lengthForString, random);

			description = new DescriptionContainer(model, manufacturer, yearOfProduction, version);
			return description;
		}
		private static int GenerateLength_Helper(Random random, int min, int max) {
			return random.Next(min, max);
		}

		public static string GenerateRandomString(int length, Random random) {
			if (length <= 0 || random == null) {
				return "";
			}

			const string chars = " ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz ,.() 0123456789 ";

			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
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

		public static string FormatByDefault(string text) {
			if (string.IsNullOrEmpty(text)) {
				return string.Empty;
			}
			return text;
		}
		public static string FormatWithDateAtStart(string text) {
			if (string.IsNullOrEmpty(text)) {
				return string.Empty;
			}
			return $"[{DateTime.Now.ToShortTimeString()}] {text}";
		}
		public static string FormatWithDateAtEnd(string text) {
			if (string.IsNullOrEmpty(text)) {
				return string.Empty;
			}
			return $"{text} [{DateTime.Now.ToShortTimeString()}]";
		}
		public static string FormatWithUppercase(string text) {
			if (string.IsNullOrEmpty(text)) {
				return string.Empty;
			}
			return text.ToUpper();
		}
		public static string FormatWithLowercase(string text) {
			if (string.IsNullOrEmpty(text)) {
				return string.Empty;
			}
			return text.ToLower();
		}
	}
}
