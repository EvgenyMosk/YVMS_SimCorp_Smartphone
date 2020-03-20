using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass()]
	public class ConsoleWriterTest {
		public ConsoleWriter ConsoleWriter { get; set; }
		[TestInitialize]
		public void SetUp() {
			ConsoleWriter = new ConsoleWriter();
		}
		[TestMethod]
		public void Output_DataIsNull_ExpectNoOutputToConsole() {
			object data = null;
			string expectedOutput = string.Empty;
			string actualOutput;

			using (StringWriter sw = new StringWriter()) {
				Console.SetOut(sw);

				ConsoleWriter.Output(data);
				actualOutput = sw.ToString().Trim();
			}

			Assert.AreEqual(expectedOutput, actualOutput);
		}
		[TestMethod]
		public void Output_DataIsNotNull_ExpectDataOutputToConsole() {
			string data = "SimCorp";
			string expectedOutput = data;
			string actualOutput;

			using (StringWriter sw = new StringWriter()) {
				Console.SetOut(sw);

				ConsoleWriter.Output(data);
				actualOutput = sw.ToString().Trim();
			}

			Assert.AreEqual(expectedOutput, actualOutput);
		}
		[TestMethod]
		public void OutputAsString_DataIsNull_ExpectNoOutputToConsole() {
			object data = null;
			string expectedResult = string.Empty;
			string actualResult;

			actualResult = ConsoleWriter.OutputAsString(data);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod]
		public void OutputAsString_DataIsNotNull_ExpectDataOutputToConsole() {
			string data = "SimCorp";
			string expectedResult = data;
			string actualResult;

			actualResult = ConsoleWriter.OutputAsString(data);

			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}