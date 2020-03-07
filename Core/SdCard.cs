using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core {
    public class SdCard : ExternalComponent, IMemory {
        public int Capacity { get; set; }
        public int UsedSpace { get; set; }
    }
}