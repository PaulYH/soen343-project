using SHC.Entities.Door;
using SHC.Entities.Light;
using SHC.Entities.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities.Room
{
    public interface IRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Temperature { get; set; }
        public double OverrideTemp { get; set; }
        public int ZoneNum { get; set; }
        public bool IsZoneOverriden { get; set; }
        public Wall LeftWall { get; set; }
        public Wall RightWall { get; set; }
        public Wall TopWall { get; set; }
        public Wall BottomWall { get; set; }
        public List<ILight> Lights { get; set; }
        public List<VirtualUser> Occupants { get; set; }

        /// <summary>
        /// Delete the following 2 attributes if it is not applicable 
        /// </summary>
        /// 
        ///  public List <IWindow> windows { get; set; }

        ///  public List<IDoor> door { get; set; }

        // Make a copy construcute that accept parameter for all the above attributes


    }
}