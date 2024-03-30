using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SHC.Models.Builder
{
    public class Director
    {
      public IBuilder homeBuilder;

        public FileHomeReader rd;
        int roomNum;
        public Director (FileHomeReader rd, IBuilder homeBuilder)
        {
            this.rd = rd;
            this.homeBuilder = homeBuilder;
            roomNum = rd.Name.Count;
            Console.WriteLine("Created");

        }

        public void constructHouse()
        {
            for (int i = 0; i < roomNum; i++)
            {
                Console.WriteLine(roomNum);
                Console.WriteLine("Going in the loop");
                if (rd.Type[i] == "Backyard")
                    homeBuilder.buildDoor(1);
                else
                    homeBuilder.buildDoor(rd.DoorQty[i]);
                homeBuilder.buildWindow(rd.WindowQty[i]);
                homeBuilder.buildWalls();
                homeBuilder.buildLight(rd.LightQty[i]);
                homeBuilder.buildRoom(i, rd.Type[i], rd.Name[i]);
            }
            homeBuilder.buildHouse();
            Console.WriteLine("Home in the builder");
        }
    }
}
