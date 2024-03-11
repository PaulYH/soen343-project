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
        public IDoor? Doors { get; set; } 
        public IWindow? Windows { get; set; } 

        public Wall (IDoor door)
        {
            Doors = door;
        }
        public Wall(IWindow? window)
        {
            Windows = window;
        }

        public Wall(IDoor door, IWindow? window)
        {
            Doors = door;
            Windows = window;
        }

        public Wall()
        {
         
        }
    }
}
