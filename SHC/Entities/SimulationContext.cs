using SHC.Entities.Room;
using SHC.Utilities.Observer;
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
        public bool hasRenderLoaded { get; set; } = false;
        public double OutsideTemperature { get; set; } = 7.1;
        public DateTime CurrentDateTime { get; set; } = DateTime.Now;
        public VirtualUser? CurrentUser { get; set; }
        public List<VirtualUser> Users { get; set; } = new List<VirtualUser>();
        public List<(IRoom, (double x, double y))> RenderRooms { get; set; } = new List<(IRoom, (double x, double y))>();
        public IRoom? SelectedRoom { get; set; }
        public string? SelectedGroup { get; set; }
        public House? House { get; set; }
        public SHHListener? SHHListener { get; set; }


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
