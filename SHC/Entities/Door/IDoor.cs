using SHC.Entities.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities.Door
{
    public interface IDoor
    {
        public string Name { get; set; }
        public IRoom? SideA { get; set; }
        public IRoom? SideB { get; set; }
    }
}
