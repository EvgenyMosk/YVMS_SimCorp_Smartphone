using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;
using Core.Enums;
using Core.HardwareComponents;

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class PlaybackControl : Form {
		private string[] _headphonesAvailable = { "Standard Headphones", "Wireless Headphones" };
		private PhoneControl phoneControl { get; set; }
		private IOutput Output { get; set; }
		public PlaybackControl() {
			InitializeComponent();

			InitComboBox_Helper(comboBox1);
			Output = new ConsoleWriter();
			IMobilePhone mobilePhone = MobilePhoneConfigurator.CreateMobilePhone(PresetsPhones.MicrosoftLumia640XL);
			phoneControl = new PhoneControl(mobilePhone, null, Output);
		}

		private void InitComboBox_Helper(ComboBox comboBox) {
			comboBox.Items.AddRange(_headphonesAvailable);
			comboBox.SelectedIndex = 0;
		}

		private void buttonPlay_Click(object sender, EventArgs e) {
			if (phoneControl == null || phoneControl.mobilePhone == null) {
				MessageBox.Show("Unfortunatelly, nothing can be done due to no phone present!");
				return;
			}
			IAudioOutputDevice outputDevice = SelectOutputDevice(comboBox1.SelectedItem);
			phoneControl.mobilePhone.AudioOutputDevice = outputDevice;
			PrintToImaginaryConsole(visualConsole, phoneControl.mobilePhone.AudioOutputDevice, textBoxAudioFile.Text);
		}

		private IAudioOutputDevice SelectOutputDevice(object selectedItem) {
			IAudioOutputDevice outputDevice;

			switch (selectedItem.ToString().Trim().ToLower()) {
				case "standard headphones":
					outputDevice = new Headphones(Output) {
						Manufacturer = "SONY",
						Model = "MDR-XB660AP"
					};
					break;
				case "wireless headphones":
					outputDevice = new HeadphonesWireless(new Headphones(Output)) {
						Manufacturer = "ASUS",
						Model = "Strix Wireless"
					};
					break;
				default:
					throw new ArgumentException("Ho appropriate headphones found!");
			}
			return outputDevice;
		}
		private void PrintToImaginaryConsole(RichTextBox richTextBox, IAudioOutputDevice audioOutput, string audioFile) {
			StringBuilder textToAppend = new StringBuilder();

			textToAppend.AppendLine("=======================");
			textToAppend.Append("Sound can be heard through:\n" + audioOutput.ToString());

			string audioFileToPlay = audioOutput.PlayFileAndReturnString(audioFile);
			if (string.IsNullOrWhiteSpace(audioFileToPlay)) {
				audioFileToPlay = "%NO_FILE_SELECTED%";
			}
			textToAppend.Append("Current file: " + audioFileToPlay);

			richTextBox.AppendText(textToAppend.ToString());
			richTextBox.ScrollToCaret();
		}
		private string PickFile() {
			OpenFileDialog openFileDialog1 = new OpenFileDialog {
				InitialDirectory = "c:\\",
				Filter = "Audio files (*.mp3, *.flac, *.wav)|*.mp3;*.flac;*.wav",
				FilterIndex = 0,
				RestoreDirectory = false
			};

			string selectedFileName = string.Empty;

			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				selectedFileName = openFileDialog1.SafeFileName;
			}

			return selectedFileName;
		}

		private void button3_Click(object sender, EventArgs e) {
			string fileToPlay = PickFile();

			if (!string.IsNullOrWhiteSpace(fileToPlay)) {
				textBoxAudioFile.Text = fileToPlay;
			}
		}

		private void buttonStop_Click(object sender, EventArgs e) {
			PrintToImaginaryConsole(visualConsole, phoneControl.mobilePhone.AudioOutputDevice, string.Empty);
			textBoxAudioFile.Text = string.Empty;
		}
	}
}