using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core {
    public interface ICommonDescription {
        string Model { get; }
        string Manufacturer { get; }
        int? YearOfProduction { get; }
        string Version { get; set; }
    }
}