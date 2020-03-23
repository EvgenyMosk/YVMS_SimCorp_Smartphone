using System.Collections.Generic;

using Core.Enums;

namespace Core {
	public interface IOperatingSystem {
		IFileManager FileManager { get; set; }
		IList<Software> InstalledApplications { get; set; }

		OperationResult MakePhoneCall(IMobilePhone target);
		OperationResult SendTextMessage(IMobilePhone target);
		OperationResult LaunchApplication(Software application);
		OperationResult OpeWebPage(string webPageAddress);
	}
}