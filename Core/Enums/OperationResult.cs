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
		ExceedingAvailableSpace = 3,
		NotEnoughSpaceOnDisk = 4,
		NoInternetConnection = 5,

	}
}
