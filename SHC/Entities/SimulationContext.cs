using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities
{
    public sealed class SimulationContext
    {
        private static SimulationContext? _instance;
        public bool IsOn { get; set; } = false;
        public double OutsideTemperature { get; set; } = 0.00;
        public DateTime CurrentDateTime { get; set; } = DateTime.Now;
        public Stopwatch Stopwatch { get; set; } = new Stopwatch();
        public VirtualUser? CurrentUser { get; set; }
        public List<VirtualUser> Users { get; set; } = new List<VirtualUser>();
        public House? House { get; set; }


        private SimulationContext() { }
        public static SimulationContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SimulationContext();
            }
            return _instance;
        }
    }
}
