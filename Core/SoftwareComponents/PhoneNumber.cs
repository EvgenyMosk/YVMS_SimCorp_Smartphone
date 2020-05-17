using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SoftwareComponents {
	public class PhoneNumber : IComparable<PhoneNumber>, ICloneable {
		private int _countryCode;
		private int _operatorCode;
		private int _userIdentifier;

		public PhoneNumber(int countryCode, int operatorCode, int userIdentifier) {
			_countryCode = countryCode;
			_operatorCode = operatorCode;
			_userIdentifier = userIdentifier;
		}
		public PhoneNumber(string countryCode, string operatorCode, string userIdentifier) {
			int.TryParse(countryCode, out _countryCode);
			int.TryParse(operatorCode, out _operatorCode);
			int.TryParse(userIdentifier, out _userIdentifier);
		}

		public object Clone() {
			return new PhoneNumber(_countryCode, _operatorCode, _userIdentifier);
		}

		public int CompareTo(PhoneNumber other) {
			return ToString().CompareTo(other.ToString());
		}

		public override bool Equals(object obj) {
			return obj is PhoneNumber other &&
				ToString().Equals(other.ToString());
		}

		public override int GetHashCode() {
			int hashCode = 1931566958;
			hashCode = hashCode * -1521134295 + _countryCode.GetHashCode();
			hashCode = hashCode * -1521134295 + _operatorCode.GetHashCode();
			hashCode = hashCode * -1521134295 + _userIdentifier.GetHashCode();
			return hashCode;
		}

		public override string ToString() {
			return "+" + _countryCode + " " + _operatorCode + " " + _userIdentifier;
		}
	}
}