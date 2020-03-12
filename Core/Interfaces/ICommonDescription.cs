using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core {
    public interface ICommonDescription {
        string Model { get; set; }
        string Manufacturer { get; set; }
        int? YearOfProduction { get; set; }
        string Version { get; set; }
        string GetDescription();
    }
}