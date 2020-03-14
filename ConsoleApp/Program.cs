using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Enums;

namespace YVMS_SC.ConsoleApp {
	public class Program {
		private static void Main(string[] args) {
			IMobilePhone mobilePhone = MobilePhoneConfigurator.CreateMobilePhone(PresetsPhones.MicrosoftLumia640XL);
			Console.WriteLine(mobilePhone);

			Console.ReadLine();
		}
	}
}