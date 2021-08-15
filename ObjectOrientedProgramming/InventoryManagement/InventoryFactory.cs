using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgramming.InventoryManagement
{
    class InventoryFactory
    {
        public List<Rice> RiceList { get; set; }
        public List<Pulses> PulsesList { get; set; }
        public List<Wheat> WheatList { get; set; }
    }
}
