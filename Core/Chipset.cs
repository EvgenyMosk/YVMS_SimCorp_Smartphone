namespace Core
{
	public class Chipset
	{
		protected class CPU
		{

		}
		protected class GPU
		{

		}
		protected abstract class WirelessConnectionModule : PowerableComponent
		{
			protected bool _isTurnedOn;
			public void TurnOff()
			{
				throw new System.NotImplementedException();
			}

			public void TurnOn()
			{
				throw new System.NotImplementedException();
			}
		}
		protected class WiFi : WirelessConnectionModule
		{

		}
		protected class Bluetooth : WirelessConnectionModule
		{

		}
		protected class NFC : WirelessConnectionModule
		{

		}
	}
}
