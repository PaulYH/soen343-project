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
    }
}
