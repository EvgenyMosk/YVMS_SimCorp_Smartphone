using System;
using System.Collections.Generic;

using Core.Enums;

namespace Core {
	public interface IWirelessConnectionModule : ICommonDescription {
		IList<IWirelessConnectionModule> connectedDevices { get; set; }
		IEnumerable<IWirelessConnectionModule> SearchForDevicesNearby();
		OperationResult ConnectToDevice(IWirelessConnectionModule targetDevice);
		OperationResult DisconectDevice(IWirelessConnectionModule targetDevice);
	}
}