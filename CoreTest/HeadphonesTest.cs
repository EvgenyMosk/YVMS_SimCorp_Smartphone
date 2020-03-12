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

		[TestInitialize]
		public void SetUp() {
			headphones = new Headphones();
		}

		[TestMethod]
		public void ChangeVolumeTest_ZeroPlusFifty_ExpectFifty() {
			int delta = 50;
			int expectedVolumeLevel = delta;
			int actualVolumeLevel;

			headphones.ChangeVolume(delta);
			actualVolumeLevel = headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
	}
}