using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Interfaces;

namespace Core {
	public interface IOutput {
		void Output(IMessage message);
		string OutputAsString(object data);
	}
}