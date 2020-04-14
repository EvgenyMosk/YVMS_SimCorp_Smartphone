﻿using System;
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
using Core.Writers;

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class PlaybackControl : Form {
		private string[] _headphonesAvailable = { "Standard Headphones", "Wireless Headphones" };
		internal PhoneControl PhoneControl { get; set; }
		private IOutput Output { get; set; }
		public PlaybackControl() {
			InitializeComponent();

			InitComboBox_Helper(comboBoxDeviceToPlay);
			Output = new RichTextBoxWriter(visualConsole); // visualConsole => RichTextBox
			IMobilePhone mobilePhone = MobilePhone.CreateMobilePhone(PresetsPhones.MicrosoftLumia640XL);
			IAudioOutputDevice audioOutputDevice = SelectOutputDevice(comboBoxDeviceToPlay.SelectedItem);
			PhoneControl = new PhoneControl(mobilePhone, audioOutputDevice, Output);
		}

		private void InitComboBox_Helper(ComboBox comboBox) {
			comboBox.Items.AddRange(_headphonesAvailable);
			comboBox.SelectedIndex = 0;
		}

		private void buttonPlay_Click(object sender, EventArgs e) {
			if (PhoneControl == null || PhoneControl.mobilePhone == null) {
				MessageBox.Show("Unfortunatelly, nothing can be done due to no phone present!");
				return;
			}
			IAudioOutputDevice outputDevice = SelectOutputDevice(comboBoxDeviceToPlay.SelectedItem);
			PhoneControl.mobilePhone.AudioOutputDevice = outputDevice;

			string audioFile = textBoxAudioFile.Text;

			PrintToImaginaryConsole(PhoneControl.mobilePhone.AudioOutputDevice, audioFile);
		}

		private IAudioOutputDevice SelectOutputDevice(object selectedItem) {
			IAudioOutputDevice outputDevice;

			switch (selectedItem.ToString().Trim().ToLower()) {
				case "standard headphones":
					outputDevice = new Headphones("MDR-XB660AP", "SONY", 2018, "v.1.0", Output);
					break;
				case "wireless headphones":
					outputDevice = new HeadphonesWireless(new Headphones("Strix Wireless", "ASUS", 2017, "v.1.1", Output));
					break;
				default:
					throw new ArgumentException("Ho appropriate headphones found!");
			}
			return outputDevice;
		}
		private void PrintToImaginaryConsole(IAudioOutputDevice audioOutputDevice, string audioFile) {
			if (audioOutputDevice == null) {
				MessageBox.Show("Audio device cannot be null!");
				return;
			}

			if (string.IsNullOrWhiteSpace(audioFile)) {
				audioFile = "%NO_FILE_SELECTED%";
			}

			visualConsole.AppendText("=======================\n");
			visualConsole.AppendText("Sound can be heard through:\n" + PhoneControl.mobilePhone.AudioOutputDevice.ToString());

			PhoneControl.mobilePhone.AudioOutputDevice.PlayFile(audioFile);
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
				selectedFileName = openFileDialog1.SafeFileName + "\n";
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
			if (PhoneControl == null
				|| PhoneControl.mobilePhone == null
				|| PhoneControl.mobilePhone.AudioOutputDevice == null) {
				MessageBox.Show("No device that can be used for output found!");
				return;
			}
			PrintToImaginaryConsole(PhoneControl.mobilePhone.AudioOutputDevice, string.Empty);
			textBoxAudioFile.Text = string.Empty;
		}

		private void buttonNotificationsFormLaunch_Click(object sender, EventArgs e) {
			NotificationsPanel notificationsPanel = new NotificationsPanel(PhoneControl);
			notificationsPanel.ShowDialog();
		}
	}
}