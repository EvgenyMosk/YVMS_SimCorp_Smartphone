namespace Core
{
	public interface IAudioOutputDevice
	{
		void StartPlayingSound();
		void StopPlayingSound();
		void VolumeIncrease(int delta);
		void VolumeDecrease(int delta);
	}
}
