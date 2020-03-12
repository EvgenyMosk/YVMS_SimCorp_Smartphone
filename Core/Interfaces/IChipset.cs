namespace Core {
	public interface IChipset {
		CPU CPU { get; set; }
		GPU GPU { get; set; }
		WiFi WiFi { get; set; }
		Bluetooth Bluetooth { get; set; }
		string Model { get; set; }
		string Manufacturer { get; set; }
		int? YearOfProduction { get; set; }
		string Version { get; set; }
	}
}