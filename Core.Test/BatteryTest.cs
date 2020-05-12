using System;

using Core.HardwareComponents;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass]
	public class BatteryTest {
		private Battery _batteryUnderTest;
		private const int _maximumCapacityInitial = 1000;
		private const int _currentCapacityInitial = 500;

		[TestInitialize]
		public void SetUp() {
			_batteryUnderTest = new Battery(_maximumCapacityInitial, _currentCapacityInitial);
		}
		[TestMethod]
		public void BatteryCtor_CurrentCapacityGreaterThanMaximum_ExpectArgumentException() {
			int maxCapacity = 100;
			int currentCapacity = 200;
			bool exceptionWasThrown = false;

			try {
				_batteryUnderTest = new Battery(maxCapacity, currentCapacity);
			} catch (ArgumentException) {
				exceptionWasThrown = true;
			}

			Assert.IsTrue(exceptionWasThrown);
		}
		[TestMethod]
		public void BatteryCtor_MaxCapacityLessThanZero_ExpectArgumentException() {
			int maxCapacity = -100;
			int currentCapacity = 200;
			bool exceptionWasThrown = false;

			try {
				_batteryUnderTest = new Battery(maxCapacity, currentCapacity);
			} catch (ArgumentException) {
				exceptionWasThrown = true;
			}

			Assert.IsTrue(exceptionWasThrown);
		}
		[TestMethod]
		public void BatteryCtor_CurrentCapacityThanZero_ExpectArgumentException() {
			int maxCapacity = 100;
			int currentCapacity = -50;
			bool exceptionWasThrown = false;

			try {
				_batteryUnderTest = new Battery(maxCapacity, currentCapacity);
			} catch (ArgumentException) {
				exceptionWasThrown = true;
			}

			Assert.IsTrue(exceptionWasThrown);
		}
		[TestMethod]
		public void ChangeCurrentCapacity_PositiveValidDelta_ExpectCurrentCapacityPctIncreased() {
			// 500 Mah / 1000 Mah => 50%
			// 500 Mah + 100 Mah = 600 Mah
			// 600 Mah / 1000 Mah => 60%
			int delta = 100;
			int expectedCapacityPercentageBeforeChanges = 50;
			int expectedCapacityPercentageAfterChanges = 60;
			int actualCapacityPercentageBeforeChanges;
			int actualCapacityPercentageAfterChanges;

			actualCapacityPercentageBeforeChanges = _batteryUnderTest.CurrentChargePercentage;
			_batteryUnderTest.ChangeCurrentCapacity(delta);
			actualCapacityPercentageAfterChanges = _batteryUnderTest.CurrentChargePercentage;

			Assert.AreEqual(expectedCapacityPercentageBeforeChanges, actualCapacityPercentageBeforeChanges);
			Assert.AreEqual(expectedCapacityPercentageAfterChanges, actualCapacityPercentageAfterChanges);
		}
		[TestMethod]
		public void ChangeCurrentCapacity_NegativeValidDelta_ExpectCurrentCapacityPctDecreased() {
			// 500 Mah / 1000 Mah => 50%
			// 500 Mah + (-100 Mah) = 600 Mah
			// 400 Mah / 1000 Mah => 40%
			int delta = -100;
			int expectedCapacityPercentageBeforeChanges = 50;
			int expectedCapacityPercentageAfterChanges = 40;
			int actualCapacityPercentageBeforeChanges;
			int actualCapacityPercentageAfterChanges;

			actualCapacityPercentageBeforeChanges = _batteryUnderTest.CurrentChargePercentage;
			_batteryUnderTest.ChangeCurrentCapacity(delta);
			actualCapacityPercentageAfterChanges = _batteryUnderTest.CurrentChargePercentage;

			Assert.AreEqual(expectedCapacityPercentageBeforeChanges, actualCapacityPercentageBeforeChanges);
			Assert.AreEqual(expectedCapacityPercentageAfterChanges, actualCapacityPercentageAfterChanges);
		}
		[TestMethod]
		public void ChangeCurrentCapacity_PositiveDeltaThatExceedMaximumCapacity_ExpectCurrentCapacityPctNotExceed100() {
			// 500 Mah / 1000 Mah => 50%
			// 500 Mah + 1000 Mah = 1500 Mah => Only 1000 max
			// 1000 Mah / 1000 Mah => 100%
			int delta = 1000;
			int expectedCapacityPercentageBeforeChanges = 50;
			int expectedCapacityPercentageAfterChanges = 100;
			int actualCapacityPercentageBeforeChanges;
			int actualCapacityPercentageAfterChanges;

			actualCapacityPercentageBeforeChanges = _batteryUnderTest.CurrentChargePercentage;
			_batteryUnderTest.ChangeCurrentCapacity(delta);
			actualCapacityPercentageAfterChanges = _batteryUnderTest.CurrentChargePercentage;

			Assert.AreEqual(expectedCapacityPercentageBeforeChanges, actualCapacityPercentageBeforeChanges);
			Assert.AreEqual(expectedCapacityPercentageAfterChanges, actualCapacityPercentageAfterChanges);
		}
		[TestMethod]
		public void ChangeCurrentCapacity_NegativeDeltaThatLowerThanZero_ExpectCurrentCapacityPctIsZero() {
			// 500 Mah / 1000 Mah => 50%
			// 500 Mah + (-1000 Mah) = -500 Mah => Only 0 min
			// 0 Mah / 1000 Mah => 0%
			int delta = -1000;
			int expectedCapacityPercentageBeforeChanges = 50;
			int expectedCapacityPercentageAfterChanges = 0;
			int actualCapacityPercentageBeforeChanges;
			int actualCapacityPercentageAfterChanges;

			actualCapacityPercentageBeforeChanges = _batteryUnderTest.CurrentChargePercentage;
			_batteryUnderTest.ChangeCurrentCapacity(delta);
			actualCapacityPercentageAfterChanges = _batteryUnderTest.CurrentChargePercentage;

			Assert.AreEqual(expectedCapacityPercentageBeforeChanges, actualCapacityPercentageBeforeChanges);
			Assert.AreEqual(expectedCapacityPercentageAfterChanges, actualCapacityPercentageAfterChanges);
		}
	}
}
