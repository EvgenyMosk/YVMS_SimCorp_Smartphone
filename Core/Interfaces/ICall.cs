using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;
using Core.SoftwareComponents;

namespace Core.Interfaces {
	public interface ICall : IComparable {
		IContact Contact { get; }
		PhoneNumber PhoneNumber { get; }
		PhoneCallType CallType { get; }
		DateTime CallTime { get; }
	}
}
