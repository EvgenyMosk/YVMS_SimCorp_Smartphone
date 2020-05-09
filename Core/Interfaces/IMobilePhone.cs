using System.Collections.Generic;

using Core.Enums;
using Core.Interfaces;
using Core.SoftwareComponents;
using Core.Writers;

namespace Core {
	public interface IMobilePhone : ICommonDescription {
		// Software
		PhoneBootState PhoneBootState { get; set; }
		OperatingSystem OperatingSystem { get; set; }
		IOutput NotificationsOutput { get; set; }

		MessagesStorage MessagesStorage { get; set; }
		// Hardware
		IChipset Chipset { get; set; }
		IAudioOutputDevice AudioOutputDevice { get; set; }
		IMemory InternalStorage { get; set; }
		IBattery Battery { get; set; }

		void ReceiveMessage(string senderName, string messageBody);
	}
}