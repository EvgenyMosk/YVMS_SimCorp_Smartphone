using System.Collections.Generic;

using Core.Enums;
using Core.SoftwareComponents;

namespace Core {
	public interface IMobilePhone : ICommonDescription {
		// Software
		PhoneBootState PhoneBootState { get; set; }
		OperatingSystem OperatingSystem { get; set; }
		NotificationService NotificationService { get; set; }
		IOutput NotificationsOutput { get; set; }
		void EnableNotifications(IOutput notificationsOutput);
		void DisableNotifications();
		void NotifyAboutReceivedMessage(object sender, NotificationEventArgs e);
		// Hardware
		IChipset Chipset { get; set; }
		IAudioOutputDevice AudioOutputDevice { get; set; }
		IMemory InternalStorage { get; set; }
	}
}