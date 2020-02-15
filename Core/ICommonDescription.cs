using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public interface ICommonDescription
    {
        String Model { get; set; }
        String Manufacturer { get; set; }
        Int32 YearOfProduction { get; set; }
        String Version { get; set; }
        String GetDescription();
    }
}