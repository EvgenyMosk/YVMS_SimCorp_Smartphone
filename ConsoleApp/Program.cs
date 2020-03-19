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
			DescriptionFormatter.GenerateRandomDescription(mobilePhone.RAM, random);
			DescriptionFormatter.GenerateRandomDescription(mobilePhone.PowerButton, random);
			DescriptionFormatter.GenerateRandomDescription(mobilePhone.Bootloader, random);
			DescriptionFormatter.GenerateRandomDescription(mobilePhone.Recovery, random);

			Console.WriteLine(mobilePhone);

			Console.ReadLine();
		}
	}
}