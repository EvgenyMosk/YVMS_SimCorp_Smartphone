namespace Core {
	public interface IAudioOutputDevice : ICommonDescription {
		IOutput Output { get; set; }
		int AudioVolumeLevelCurrent { get; set; }
		string AudioFile { get; set; }
		void PlayFile(string audioFile);
		void StopPlayingAudio();
		void ChangeVolume(int delta);
		string PlayFileAndReturnString(string audioFile);
	}
}