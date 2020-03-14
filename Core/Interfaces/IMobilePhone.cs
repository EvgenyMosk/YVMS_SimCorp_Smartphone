using System.Collections.Generic;

using Core.Enums;

namespace Core {
	public interface IMobilePhone : ICommonDescription {
		// Software
		PhoneBootState PhoneBootState { get; set; }
		Recovery Recovery { get; set; }
		Bootloader Bootloader { get; set; }
		OperatingSystem OperatingSystem { get; set; }

		// Hardware
		IChipset Chipset { get; set; }
		List<SimCard> SimCards { get; set; }
		IDisplay Screen { get; set; } //===
		Button PowerButton { get; set; } // ===
		NetworkModule NetworkModule { get; set; }
		IAudioInputDevice AudioInputDevice { get; set; }
		IAudioOutputDevice<object> AudioOutputDevice { get; set; }
		IPowerSource Battery { get; set; }
		RAM RAM { get; set; }
		Storage InternalStorage { get; set; }
		Case Case { get; set; }
	}
}