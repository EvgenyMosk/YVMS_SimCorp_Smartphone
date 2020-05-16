using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core.SoftwareComponents {
	public class Contact : IContact {
		public string Name { get; set; }
		public IList<PhoneNumber> PhoneNumbers { get; set; }
		public Contact(string name, IList<PhoneNumber> phoneNumbers) {
			Name = name;
			PhoneNumbers = phoneNumbers;
		}

		public int CompareTo(IContact other) {
			return Name.CompareTo(other.Name);
		}

		public override bool Equals(object obj) {
			return obj is Contact contact &&
				   Name == contact.Name &&
				   EqualityComparer<IList<PhoneNumber>>.Default.Equals(PhoneNumbers, contact.PhoneNumbers);
		}

		public override int GetHashCode() {
			int hashCode = -1688101219;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<IList<PhoneNumber>>.Default.GetHashCode(PhoneNumbers);
			return hashCode;
		}
	}
}
