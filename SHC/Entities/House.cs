using SHC.Entities.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities
{
    public class House
    {
        public List<IRoom>? Rooms { get; set; }

        public int width = 1;

        public int height = 1;

    }
}
