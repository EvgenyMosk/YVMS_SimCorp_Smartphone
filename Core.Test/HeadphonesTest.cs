using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass]
	public class HeadphonesTest {
		public Headphones headphones { get; set; }

		public class FakeOutput : IOutput {
			public void Output(object data) {
				Console.WriteLine(data.ToString());
			}

			public string OutputAsString(object data) {
				return data.ToString();
			}
		}

		[TestInitialize]
		public void SetUp() {
			headphones = new Headphones(new FakeOutput());
		}

		[TestMethod]
		public void ChangeVolume_ZeroPlusFifty_ExpectFifty() {
			int delta = 50;
			int expectedVolumeLevel = delta;
			int actualVolumeLevel;

			headphones.ChangeVolume(delta);
			actualVolumeLevel = headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void ChangeVolume_FiftyPlusFifty_ExpectOneHundred() {
			int delta = 50;
			int expectedVolumeLevel = 100;
			int actualVolumeLevel;
			headphones.AudioVolumeLevelCurrent = 50;

			headphones.ChangeVolume(delta);
			actualVolumeLevel = headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void ChangeVolume_FiftyMinusFifty_ExpectZero() {
			int delta = -50;
			int expectedVolumeLevel = 0;
			int actualVolumeLevel;
			headphones.AudioVolumeLevelCurrent = 50;

			headphones.ChangeVolume(delta);
			actualVolumeLevel = headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void ChangeVolume_FiftyPlusFiftyOne_ExpectOneHundred() {
			int delta = 51;
			int expectedVolumeLevel = 100;
			int actualVolumeLevel;
			headphones.AudioVolumeLevelCurrent = 50;

			headphones.ChangeVolume(delta);
			actualVolumeLevel = headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void ChangeVolume_FifrtyMinusFiftyOne_ExpectZero() {
			int delta = -51;
			int expectedVolumeLevel = 0;
			int actualVolumeLevel;
			headphones.AudioVolumeLevelCurrent = 50;

			headphones.ChangeVolume(delta);
			actualVolumeLevel = headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void PlayFile_StrinngWithSomeSymbols_ExpectOutputToConsole() {

			//using (var sw = new StringWriter()) {
			//	Console.SetOut(sw);
			//	HelloWorldCore.Program.Main();

			//	var result = sw.ToString().Trim();
			//	Assert.AreEqual(Expected, result);
			//}
		}
	}
}