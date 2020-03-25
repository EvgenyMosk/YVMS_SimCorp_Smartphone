using Core.HardwareComponents;

namespace Core {
	public interface IChipset : ICommonDescription {
		CPU CPU { get; }
	}
}