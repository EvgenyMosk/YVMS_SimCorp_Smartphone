using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Core;
using Core.Enums;
using Core.HardwareComponents;

using static System.Console;

namespace YVMS_SC.ConsoleApp {
	public class Program {
		private static void Main(string[] args) {
			IMobilePhone mobilePhone = MobilePhone.CreateMobilePhone(PresetsPhones.MicrosoftLumia640XL);
			IOutput output = new ConsoleWriter();



			mobilePhone.EnableNotifications(output);

			for (int i = 0; i < 10; i++) {
				Thread.Sleep(1000);
				mobilePhone.NotificationService.ReceiveMessage("Test text.");
			}


			//int userChoiceMain;
			//string userChoiceForFile;
			//string audioFile = "Judas Priest - Metal messiah.mp3";

			//do {
			//	Clear();
			//	PrintMainMenu();

			//	int.TryParse(ReadLine(), out userChoiceMain);

			//	if (userChoiceMain == 0) {
			//		return;
			//	}

			//	mobilePhone.AudioOutputDevice = SelectAudioDevice(userChoiceMain, output);

			//	WriteLine("Would you like to choose another song to play? (Y / N)");
			//	userChoiceForFile = ReadLine();

			//	audioFile = LetUserChangeAudioFile(userChoiceForFile, audioFile);

			//	WriteLine();
			//	mobilePhone.AudioOutputDevice.PlayFile(audioFile);
			//	PrintDeviceUsed(mobilePhone);
			//	WriteLine("\nPress any key to continue...");
			//	ReadKey();

			//} while (userChoiceMain != 0);


			ReadLine();
		}

		private static string LetUserChangeAudioFile(string userChoiceForFile, string audioFile) {
			if (userChoiceForFile.Trim().ToLower().Equals("y")) {
				WriteLine("Type the name/path of the file you wold like to play.");
				audioFile = ReadLine();
			} else if (userChoiceForFile.Trim().ToLower().Equals("n")) {
				// Don't change audio file
			} else { WriteLine("You have selected something else than 'Y' or 'N', so we suggest you don't want to choose another file."); }

			return audioFile;
		}

		private static void PrintMainMenu() {
			WriteLine("Please, select your headphones:\n" +
								" 1 - wired\n" +
								" 2 - wireless\n" +
								" 0 - exit application\n" +
								" anything else will be just defaulted.");
		}

		private static IAudioOutputDevice SelectAudioDevice(int userChoice, IOutput output) {
			IAudioOutputDevice audioOutputDevice = null;

			switch (userChoice) {
				case 1:
					audioOutputDevice = new Headphones("MDR-ZX660AP", "SONY", 2018, "v.1.0", output);
					break;
				case 2:
					audioOutputDevice = new HeadphonesWireless(new Headphones("Strix Wireless", "ASUS", 2017, "v.1.1", output));
					break;
				default:
					audioOutputDevice = new Headphones("DefaultModel", "DefaultManufacturer", 9999, "v.1.2.3.4", output);
					break;
			}

			return audioOutputDevice;
		}

		private static void PrintDeviceUsed(IMobilePhone mobilePhone) {
			WriteLine("Device used: " + mobilePhone.AudioOutputDevice.Manufacturer + " " + mobilePhone.AudioOutputDevice.Model);
			WriteLine("Type of device: " + mobilePhone.AudioOutputDevice.GetType());
		}
	}
}