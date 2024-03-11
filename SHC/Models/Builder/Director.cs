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
            roomNum = rd.name.Count;
            Console.WriteLine("Created");

        }

        public void constructHouse()
        {
            for (int i =0; i<roomNum; i++)
            {
                Console.WriteLine(roomNum);
                Console.WriteLine("Going in the loop");
                homeBuilder.buildDoor(rd.rDoorNum[i], rd.sDoorNum[i]);
                homeBuilder.buildWindow(rd.rWindowNum[i], rd.sWindowNum[i]);
                homeBuilder.buildWalls();
                homeBuilder.buildLight(rd.rLightNum[i], rd.sLightNum[i]);
                homeBuilder.buildRoom(rd.type[i], rd.name[i]);
            }
            homeBuilder.buildHouse();
            Console.WriteLine("Home in the builder");
        }
    }
}
