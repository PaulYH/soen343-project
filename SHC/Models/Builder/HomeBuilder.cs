using SHC.Entities;
using SHC.Entities.Door;
using SHC.Entities.Light;
using SHC.Entities.Room;
using SHC.Entities.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace SHC.Models.Builder
{
    public class HomeBuilder : IBuilder
    {
        private Wall leftWall { get; set; } = new Wall();
        private Wall rightWall { get; set; } = new Wall();
        private Wall topWall { get; set; } = new Wall();
        private Wall bottomWall { get; set; } = new Wall();
        private List<ILight> lights { get; set; } = new List<ILight>();

        private List<IDoor> doors { get; set; } = new List<IDoor>();
        private List<IWindow> windows { get; set; } = new List<IWindow>();

        private List<IRoom> rooms { get; set; } = new List<IRoom>();
        private House singleHome { get; set; }

        private static Random random = new Random();


        public void buildWalls() {

            List<string> roomSides = new List<string>() { "left", "right", "top", "bottom" };

            List<string> roomSidesForWindows = new List<string>() { "left", "right", "top", "bottom" };



            foreach (var door in doors)
            {
                if (roomSides.Count == 0)
                    break;

                var side = roomSides[random.Next(roomSides.Count)];

                switch (side)
                {
                    case "left":
                        leftWall.Doors = door;
                        break;
                    case "right":
                        rightWall.Doors = door;
                        break;
                    case "top":
                        topWall.Doors = door;
                        break;
                    case "bottom":
                        bottomWall.Doors = door;
                        break;


                }

                roomSides.Remove(side);
            }

            foreach (var window in windows)
            {
                if (roomSidesForWindows.Count == 0)
                    break;

                var side = roomSidesForWindows[random.Next(roomSidesForWindows.Count)];

                switch (side)
                {
                    case "left":
                        leftWall.Windows = window;
                        break;
                    case "right":
                        rightWall.Windows = window;
                        break;
                    case "top":
                        topWall.Windows = window;
                        break;
                    case "bottom":
                        bottomWall.Windows = window;
                        break;


                }

                roomSides.Remove(side);
            }
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
            leftWall  = new Wall();
            rightWall = new Wall();
            topWall = new Wall();
            bottomWall  = new Wall();
             lights = new List<ILight>();

        doors = new List<IDoor>();
        windows = new List<IWindow>();




    }
            public void buildHouse() {
            singleHome = new House(rooms);
            
        }

        public House getProduct()
        {
            return singleHome;
            Console.WriteLine("Mercy");
        }
        
    }
}
