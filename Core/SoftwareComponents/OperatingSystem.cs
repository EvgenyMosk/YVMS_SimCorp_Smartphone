using System;
using System.Collections.Generic;

using Core.Enums;

namespace Core {
	public class OperatingSystem : Software, IOperatingSystem {
		public ILauncherApp LauncherApp { get; set; }
		public IFileManager FileManager { get; set; }
		public IWebBrowser WebBrowser { get; set; }
		public IPhoneCallsApp PhoneCallsApp { get; set; }
		public ITextMessagingApp TextMessagingApp { get; set; }
		public IList<Software> InstalledApplications { get; set; }

		public OperationResult MakePhoneCall(IMobilePhone target) {
			throw new NotImplementedException();
		}
		public OperationResult SendTextMessage(IMobilePhone target) {
			throw new NotImplementedException();
		}
		public OperationResult LaunchApplication(Software application) { // ===
			throw new NotImplementedException();
		}
		public OperationResult OpeWebPage(string webPageAddress) {
			throw new NotImplementedException();
		}
	}
}