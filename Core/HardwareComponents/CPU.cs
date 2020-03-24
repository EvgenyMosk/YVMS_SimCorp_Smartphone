namespace Core {
	public class CPU : ProcessingUnit {
		public int Cores { get; }
		public int Lithography { get; } // Nanometers
		public CPU(string model, string manufacturer,
			double frequencyMax, int throttleTemperature,
			int criticalTemperature, int? yearOfProduction,
			string version, int cores,
			int lithography)
			: base(model, manufacturer,
				frequencyMax, throttleTemperature, criticalTemperature,
				yearOfProduction, version) {

			Cores = cores;
			Lithography = lithography;
		}
	}
}