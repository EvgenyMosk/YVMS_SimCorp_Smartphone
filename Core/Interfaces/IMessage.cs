using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
	public interface IMessage : IEquatable<IMessage> {
		string Sender { get; set; }
		string Body { get; set; }
		DateTime ReceivedTime { get; set; }
	}
}