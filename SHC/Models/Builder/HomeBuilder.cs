using SHC.Entities;
using SHC.Entities.Door;
using SHC.Entities.Light;
using SHC.Entities.Room;
using SHC.Entities.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace SHC.Models.Builder
{
    public class HomeBuilder : IBuilder
    {
        private Wall leftWall { get; set; }
        private Wall rightWall { get; set; }
        private Wall topWall { get; set; }
        private Wall bottomWall { get; set; }
        private List<ILight> lights { get; set; }

        private List<IDoor> doors { get; set; } 
        private List<IWindow> windows { get; set; } 

        private List <IRoom> rooms { get; set; }

        private House singleHome { get; set; }


        public void buildWalls() {
            leftWall = new Wall();

            rightWall = new Wall();

            topWall = new Wall();

            bottomWall = new Wall();

            // Distribute the Doors, and Windows on the 4 walls.... 
        }
        public void buildWindow(int rWindowNum, int sWindowNum) {

            int totalWindows = sWindowNum + rWindowNum;

            for (int i =0; i< sWindowNum; i++)
            {
                windows.Add(new SmartWindow());
            }
            for (int i = 0; i < rWindowNum; i++)
            {
                windows.Add(new RegularWindow());

            }
             // Adding the the windows to the Wall based on the drawings

        }
        public void buildDoor(int rDoorNum, int SDoorNum) {

            for (int i = 0; i < SDoorNum; i++)
            {
                doors.Add(new SmartDoor());
            }
            for (int i = 0; i < rDoorNum; i++)
            {
                doors.Add(new RegularDoor());

            }

            // Adding the the Doors to the Wall based on the drawings

        }
        public void buildLight(int rLightNum, int sLightNum) {
         
            
            for (int i = 0; i < sLightNum; i++)
            {
                lights.Add(new SmartLight());
            }
            for (int i = 0; i < rLightNum; i++)
            {
                lights.Add(new RegularLight());

            }

        }
        public void buildRoom(String type, String name)
        {

            switch (type)
            {
                case "Entrance":
                    {
                        Entrance entrance = new Entrance(name, leftWall, rightWall, topWall, bottomWall, lights);
                        rooms.Add(entrance);
                        break;
                    }
                case "CommonRoom":
                    {
                        CommonRoom commonRoom = new CommonRoom(name, leftWall, rightWall, topWall, bottomWall, lights);
                        rooms.Add(commonRoom);

                        // code block
                        break;
                    }
                case "Garage":
                    {
                        Garage garage = new Garage(name, leftWall, rightWall, topWall, bottomWall, lights);
                        rooms.Add(garage);

                        // code block
                        break;
                    }
                case "Backyard":
                    {
                        Backyard backyard = new Backyard(name, leftWall, rightWall, topWall, bottomWall, lights);
                        rooms.Add(backyard);

                        // code block
                        break;
                    }


                default:
                    break;
            }

           
            leftWall = null;
         rightWall = null;
            topWall = null;
            bottomWall = null;
            lights = null;
            doors = null;
            windows = null;


        }
            public void buildHouse() {
            singleHome = new House();
            rooms = null;
        }

        public House getProduct()
        {
            return singleHome;
        }
    }
}
