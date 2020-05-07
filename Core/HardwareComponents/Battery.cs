using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.HardwareComponents {
	public class Battery : IBattery {
		#region ICommonDescription implementation
		public string Model { get; }
		public string Manufacturer { get; }
		public int? YearOfProduction { get; }
		public string Version { get; set; }

		#endregion
		private int _currentCapacity;
		public int MaximumCapacity { get; }
		public int CurrentChargePercentage {
			get {
				float currCap = Convert.ToSingle(_currentCapacity);
				float maxCap = Convert.ToSingle(MaximumCapacity);
				return Convert.ToInt32((currCap / maxCap) * 100);
			}
		}

		public Battery(int capacityMaximum, int currentCapacity)
			: this(capacityMaximum, currentCapacity, "defaultModel", "defaultManufacturer", 2000, "v.1.0") { }

		public Battery(int capacityMaximum, int currentCapacity, string model, string manufacturer, int? yearOfProduction, string version) {
			if (capacityMaximum <= 0) {
				throw new ArgumentException("Maximum capacity cannot be zero, or below!", nameof(capacityMaximum));
			}
			MaximumCapacity = capacityMaximum;

			if (!CapacityIsValid(currentCapacity)) {
				throw new ArgumentException("currentCapacity cannot exceed maximum value, or be below zero!", nameof(capacityMaximum));
			}
			_currentCapacity = currentCapacity;

			// ICommonDescription
			Model = model;
			Manufacturer = manufacturer;
			YearOfProduction = yearOfProduction;
			Version = version;
		}

		private bool CapacityIsValid(int capacity) {
			if (CapacityIsBelowZero(capacity) || CapacityIsAboveMaximum(capacity)) {
				return false;
			} else {
				return true;
			}
		}
		private bool CapacityIsBelowZero(int capacity) {
			if (capacity < 0) {
				return true;
			} else {
				return false;
			}
		}
		private bool CapacityIsAboveMaximum(int capacity) {
			if (capacity > MaximumCapacity) {
				return true;
			} else {
				return false;
			}
		}

		public void ChangeCurrentCapacity(int delta) {
			if (delta > 0) {
				IncreaseCurrentCapacity(delta);
			} else {
				delta *= -1;
				DecreaseCurrentCapacity(delta);
			}
		}
		private void IncreaseCurrentCapacity(int delta) {
			if (delta < 0) {
				throw new ArgumentException("Delta cannot be less than zero!", nameof(delta));
			}

			int newCurrentCapacity = _currentCapacity + delta;
			if (CapacityIsAboveMaximum(newCurrentCapacity)) {
				_currentCapacity = MaximumCapacity;
			} else {
				_currentCapacity = newCurrentCapacity;
			}
		}
		private void DecreaseCurrentCapacity(int delta) {
			if (delta < 0) {
				throw new ArgumentException("Delta cannot be less than zero!", nameof(delta));
			}

			int newCurrentCapacity = _currentCapacity - delta;
			if (CapacityIsBelowZero(newCurrentCapacity)) {
				_currentCapacity = 0;
			} else {
				_currentCapacity = newCurrentCapacity;
			}
		}
	}
}
