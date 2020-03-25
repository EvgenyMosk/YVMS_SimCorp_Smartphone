using System;
using System.Collections.Generic;

using Core.Enums;

namespace Core.SoftwareComponents {
	public class OperatingSystem : Software, IOperatingSystem {
		public IFileManager FileManager { get; set; }
		public IList<Software> InstalledApplications { get; set; }

		public OperatingSystem(string model, string manufacturer, int? yearOfProduction, string version, int size) : base(model, manufacturer, yearOfProduction, version, size) {

		}
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