using SHC.Entities.Light;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities.Room
{
    public class Entrance : IRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Temperature { get; set; } = 0;
        public int ZoneNum { get; set; } = 0;
        public bool IsZoneOverriden { get; set; } = false;
        public Wall LeftWall { get; set; }
        public Wall RightWall { get; set; }
        public Wall TopWall { get; set; }
        public Wall BottomWall { get; set; }
        public List<ILight> Lights { get; set; } = new List<ILight>();
        public List<VirtualUser> Occupants { get; set; } = new List<VirtualUser>();

    }
}
