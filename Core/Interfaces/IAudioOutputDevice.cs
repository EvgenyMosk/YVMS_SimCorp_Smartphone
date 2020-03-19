namespace Core {
	public interface IAudioOutputDevice<T> : ICommonDescription {
		IOutput Output { get; set; }
		int AudioVolumeLevelCurrent { get; set; }
		T AudioFile { get; set; }
		void PlayFile(T audioFile);
		void StopPlayingAudio();
		void ChangeVolume(int delta);
		string PlayFileAndReturnString(string audioFile);
	}
}