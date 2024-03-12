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
        public List<IRoom>? rooms { get; set; }

        public int width = 1;

        public int height = 1;

        public House (List <IRoom> pRooms)
        {

            rooms = pRooms;
        }

        public House()
        {

        }
    }
}
