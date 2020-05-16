using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.SoftwareComponents;

namespace Core.Interfaces {
	public interface IContact : IComparable<IContact> {
		string Name { get; set; }
		IList<PhoneNumber> PhoneNumbers { get; set; }
	}
}
