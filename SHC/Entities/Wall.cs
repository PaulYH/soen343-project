using SHC.Entities.Door;
using SHC.Entities.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities
{
    public class Wall
    {
        public int Length { get; set; }
        public List<IDoor> Doors { get; set; } = new List<IDoor>();
        public List<IWindow> Windows { get; set; } = new List<IWindow>();
    }
}
