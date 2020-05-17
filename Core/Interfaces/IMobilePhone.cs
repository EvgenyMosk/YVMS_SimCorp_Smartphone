using System;
using System.Collections.Generic;

using Core.Enums;
using Core.Interfaces;
using Core.SoftwareComponents;
using Core.Writers;

namespace Core {
	public interface IMobilePhone : ICommonDescription {
		// Software
		PhoneBootState PhoneBootState { get; set; }
		Core.SoftwareComponents.OperatingSystem OperatingSystem { get; set; }
		IOutput NotificationsOutput { get; set; }

		PhoneCallsCollection PhoneCallsStorage { get; set; }
		MessagesStorage MessagesStorage { get; set; }

		// Hardware
		IChipset Chipset { get; set; }
		IAudioOutputDevice AudioOutputDevice { get; set; }
		IMemory InternalStorage { get; set; }
		IBattery Battery { get; set; }

		void ReceiveMessage(string senderName, string messageBody);
		void ReceiveCall(ICall call);
		void ReceiveCall(IContact contact, PhoneNumber phoneNumber, PhoneCallType callType, DateTime callTime);
	}
}