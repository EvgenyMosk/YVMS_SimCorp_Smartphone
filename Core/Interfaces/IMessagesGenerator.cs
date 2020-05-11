using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces {
	public interface IMessagesGenerator {
		int MessagesGenerationInterval { get; }
		void StartGeneratingNewMessages();
		void StopGeneratingNewMessages();
	}
}
