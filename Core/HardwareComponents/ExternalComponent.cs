using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core {
    public abstract class ExternalComponent : ICommonDescription {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int? YearOfProduction { get; set; }
        public string Version { get; set; }

        public override string ToString() {
            string description;
            description = DescriptionFormatter.CreateDescription(this);
            return description;
        }
    }
}