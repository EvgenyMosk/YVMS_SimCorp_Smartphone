using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Enums;

namespace YVMS_SC.ConsoleApp {
	public class Program {

		private static void Main(string[] args) {
			IMobilePhone mobilePhone = MobilePhoneConfigurator.CreateMobilePhone(PresetsPhones.MicrosoftLumia640XL);

			Random random = new Random();

			Console.WriteLine(mobilePhone);

			Console.WriteLine(string.Empty); ;
			Console.ReadLine();
		}
	}
}