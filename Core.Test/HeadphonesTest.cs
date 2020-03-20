using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test {
	[TestClass]
	public class HeadphonesTest {
		public Headphones Headphones { get; set; }

		public class FakeOutput : IOutput {
			public void Output(object data) {
				Console.WriteLine(data.ToString());
			}

			public string OutputAsString(object data) {
				return data.ToString();
			}
		}

		[TestInitialize]
		public void SetUp() {
			Headphones = new Headphones(new FakeOutput());
		}

		[TestMethod]
		public void ChangeVolume_ZeroPlusFifty_ExpectFifty() {
			int delta = 50;
			int expectedVolumeLevel = delta;
			int actualVolumeLevel;

			Headphones.ChangeVolume(delta);
			actualVolumeLevel = Headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void ChangeVolume_FiftyPlusFifty_ExpectOneHundred() {
			int delta = 50;
			int expectedVolumeLevel = 100;
			int actualVolumeLevel;
			Headphones.AudioVolumeLevelCurrent = 50;

			Headphones.ChangeVolume(delta);
			actualVolumeLevel = Headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void ChangeVolume_FiftyMinusFifty_ExpectZero() {
			int delta = -50;
			int expectedVolumeLevel = 0;
			int actualVolumeLevel;
			Headphones.AudioVolumeLevelCurrent = 50;

			Headphones.ChangeVolume(delta);
			actualVolumeLevel = Headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void ChangeVolume_FiftyPlusFiftyOne_ExpectOneHundred() {
			int delta = 51;
			int expectedVolumeLevel = 100;
			int actualVolumeLevel;
			Headphones.AudioVolumeLevelCurrent = 50;

			Headphones.ChangeVolume(delta);
			actualVolumeLevel = Headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void ChangeVolume_FifrtyMinusFiftyOne_ExpectZero() {
			int delta = -51;
			int expectedVolumeLevel = 0;
			int actualVolumeLevel;
			Headphones.AudioVolumeLevelCurrent = 50;

			Headphones.ChangeVolume(delta);
			actualVolumeLevel = Headphones.AudioVolumeLevelCurrent;

			Assert.AreEqual(expectedVolumeLevel, actualVolumeLevel);
		}
		[TestMethod]
		public void PlayFile_OutputNotNull_StrinngWithSomeSymbols_ExpectOutputToConsole() {
			string audioFile = "Metallica - Unforgiven.flac";
			string expectedResult = audioFile;
			string expectedAudioFileInHeadphones = audioFile;
			string actualResult;
			string actualAudioFileInHeadphones;

			using (StringWriter sw = new StringWriter()) {
				Console.SetOut(sw);

				Headphones.PlayFile(audioFile);
				actualResult = sw.ToString().Trim();
				actualAudioFileInHeadphones = Headphones.AudioFile;
			}

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedAudioFileInHeadphones, actualAudioFileInHeadphones);
		}
		[TestMethod]
		public void PlayFile_OutputNotNull_EmptyStrinng_ExpectNoOutputToConsole() {
			string audioFile = string.Empty;
			string expectedResult = "";
			string expectedAudioFileInHeadphones = audioFile;
			string actualResult;
			string actualAudioFileInHeadphones;

			using (StringWriter sw = new StringWriter()) {
				Console.SetOut(sw);

				Headphones.PlayFile(audioFile);
				actualResult = sw.ToString().Trim();
				actualAudioFileInHeadphones = Headphones.AudioFile;
			}

			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedAudioFileInHeadphones, actualAudioFileInHeadphones);
		}
		// Output == null
		[TestMethod]
		public void PlayFile_OutputIsNull_StringWithSomeSymbols_ExpectNoOutputToConsole() {
			string audioFile = "Metallica - Unforgiven.flac";
			string expectedOutputToConsole = string.Empty;
			string actualOutputToConsole;

			using (StringWriter sw = new StringWriter()) {
				Console.SetOut(sw);

				Headphones.Output = null;
				Headphones.PlayFile(audioFile);
				actualOutputToConsole = sw.ToString().Trim();
			}

			Assert.AreEqual(expectedOutputToConsole, actualOutputToConsole);
		}
		[TestMethod]
		public void PlayFile_OutputIsNull_StringWithSomeSymbols_ExpectAudioFileInHeadphones() {
			string audioFile = "Metallica - Unforgiven.flac";
			string expectedAudioFileInHeadphones = audioFile;
			string actualAudioFileInHeadphones;

			Headphones.Output = null;
			Headphones.PlayFile(audioFile);
			actualAudioFileInHeadphones = Headphones.AudioFile;

			Assert.AreEqual(expectedAudioFileInHeadphones, actualAudioFileInHeadphones);
		}
		[TestMethod]
		public void PlayFile_OutputIsNull_EmptyString_ExpectNoOutputToConsole() {
			string audioFile = string.Empty;
			string expectedOutputToConsole = audioFile;
			string actualOutputToConsole;

			using (StringWriter sw = new StringWriter()) {
				Console.SetOut(sw);

				Headphones.Output = null;
				Headphones.PlayFile(audioFile);
				actualOutputToConsole = sw.ToString().Trim();
			}

			Assert.AreEqual(expectedOutputToConsole, actualOutputToConsole);
		}
		[TestMethod]
		public void PlayFile_OutputIsNull_EmptyString_ExpectEmptyAudioFileInHeadphones() {
			string audioFile = string.Empty;
			string expectedAudioFileInHeadphones = audioFile;
			string actualAudioFileInHeadphones;

			Headphones.Output = null;
			Headphones.PlayFile(audioFile);
			actualAudioFileInHeadphones = Headphones.AudioFile;

			Assert.AreEqual(expectedAudioFileInHeadphones, actualAudioFileInHeadphones);
		}
		[TestMethod]
		public void StopPlayingAudio_ExpectAudilFileIsNull() {
			Headphones.AudioFile = "Judas Priest - Metal Messiah.mp3";
			string actualAudioFile;

			Headphones.StopPlayingAudio();
			actualAudioFile = Headphones.AudioFile;

			Assert.IsNull(actualAudioFile);
		}
		[TestMethod]
		public void PlayFileAndReturnString_OutputNotNull_StringWithSomeSymbols_ExpectAudioFileWithSameName() {
			string audioFile = "Metallica - Unforgiven.flac";
			string expectedAudioFile = audioFile;
			string actualAudioFileReturned;
			string actualAudioFileInHeadphones;

			actualAudioFileReturned = Headphones.PlayFileAndReturnString(audioFile);
			actualAudioFileInHeadphones = Headphones.AudioFile;

			Assert.AreEqual(expectedAudioFile, actualAudioFileReturned);
			Assert.AreEqual(expectedAudioFile, actualAudioFileInHeadphones);
		}
		[TestMethod]
		public void PlayFileAndReturnString_OutputNotNull_EmptyString_ExpectEmptyAudioFIle() {
			string audioFile = string.Empty;
			string expectedAudioFile = audioFile;
			string actualAudioFileReturned;
			string actualAudioFileInHeadphones;

			actualAudioFileReturned = Headphones.PlayFileAndReturnString(audioFile);
			actualAudioFileInHeadphones = Headphones.AudioFile;

			Assert.AreEqual(expectedAudioFile, actualAudioFileReturned);
			Assert.AreEqual(expectedAudioFile, actualAudioFileInHeadphones);
		}
		[TestMethod]
		public void PlayFileAndReturnString_OutputIsNull_StringWithSomeSymbols_ExpectEmptyAudioFileReturn() {
			string audioFile = "Judas Priest - Metal Messiah.mp3";
			string expectedAudioFileReturned = string.Empty;
			string actualAudioFileReturned;

			Headphones.Output = null;
			actualAudioFileReturned = Headphones.PlayFileAndReturnString(audioFile);

			Assert.AreEqual(expectedAudioFileReturned, actualAudioFileReturned);
		}
		[TestMethod]
		public void PlayFileAndReturnString_OutputIsNull_StringWithSomeSymbols_ExpectAudioFileInHeadphones() {
			string audioFile = "Judas Priest - Metal Messiah.mp3";
			string expectedAudioFileInHeadphones = audioFile;
			string actualAudioFileInHeadphones;

			Headphones.Output = null;
			Headphones.PlayFileAndReturnString(audioFile);
			actualAudioFileInHeadphones = Headphones.AudioFile;

			Assert.AreEqual(expectedAudioFileInHeadphones, actualAudioFileInHeadphones);
		}
		[TestMethod]
		public void PlayFileAndReturnString_OutputIsNull_EmptyString_ExpectEmptyAudioFileReturned() {
			string audioFile = string.Empty;
			string expectedAudioFileReturned = audioFile;
			string actualAudioFileReturned;

			Headphones.Output = null;
			actualAudioFileReturned = Headphones.PlayFileAndReturnString(audioFile);

			Assert.AreEqual(expectedAudioFileReturned, actualAudioFileReturned);
		}
		[TestMethod]
		public void PlayFileAndReturnString_OutputIsNull_EmptyString_ExpectEmptyAudioFileInHeadphones() {
			string audioFile = string.Empty;
			string expectedAudioFileReturned = audioFile;
			string actualAudioFileInHeadphones;

			Headphones.Output = null;
			Headphones.PlayFileAndReturnString(audioFile);
			actualAudioFileInHeadphones = Headphones.AudioFile;

			Assert.AreEqual(expectedAudioFileReturned, actualAudioFileInHeadphones);
		}
	}
}