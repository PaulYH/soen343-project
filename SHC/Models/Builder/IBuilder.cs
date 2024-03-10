using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHC.Entities;
using SHC.Entities.Door;
using SHC.Entities.Light;
using SHC.Entities.Room;
using SHC.Entities.Window;

namespace SHC.Models.Builder
{

    public interface IBuilder
    {
        public void buildWalls();
        public void buildWindow(int rWindowNum, int sWindowNum);
        public void buildDoor(int rDoorNum, int SDoorNum);
        public void buildLight(int rLightNum, int sLightNum);
        public void buildRoom(String type, String name);
        public void buildHouse();

        public House getProduct();
    }
}
