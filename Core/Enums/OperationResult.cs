using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums {
	public enum OperationResult {
		Success = 0,
		FileNotFound = 1,
		FileAlreadyExist = 2,
		FileWithSuchNameAlreadyExist = 3,
		ExceedingAvailableSpace = 4,
		NotEnoughSpaceOnDisk = 5,
		NoInternetConnection = 6,
		DeviceNotExist = 7,
	}
}
