using System.Collections.Generic;

using Core.Enums;

namespace Core {
	public interface IOperatingSystem {
		ILauncherApp LauncherApp { get; set; }
		IFileManager FileManager { get; set; }
		IWebBrowser WebBrowser { get; set; }
		IPhoneCallsApp PhoneCallsApp { get; set; }
		ITextMessagingApp TextMessagingApp { get; set; }
		IList<Software> InstalledApplications { get; set; }

		OperationResult MakePhoneCall(IMobilePhone target);
		OperationResult SendTextMessage(IMobilePhone target);
		OperationResult LaunchApplication(Software application);
		OperationResult OpeWebPage(string webPageAddress);
	}
}