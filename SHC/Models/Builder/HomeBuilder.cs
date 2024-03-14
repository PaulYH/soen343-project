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
                        door.Name = "LeftDoor";
                        leftWall.Door = door;
                        break;
                    case "right":
                        door.Name = "RightDoor";
                        rightWall.Door = door;
                        break;
                    case "top":
                        door.Name = "TopDoor";
                        topWall.Door = door;
                        break;
                    case "bottom":
                        door.Name = "BottomDoor";
                        bottomWall.Door = door;
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
                        window.Name = "LeftWindow";
                        leftWall.Window = window;
                        break;
                    case "right":
                        window.Name = "RightWindow";
                        rightWall.Window = window;
                        break;
                    case "top":
                        window.Name = "TopWindow";
                        topWall.Window = window;
                        break;
                    case "bottom":
                        window.Name = "BottomWindow";
                        bottomWall.Window = window;
                        break;

                }

                roomSides.Remove(side);
            }
        }
        public void buildWindow(int sWindowNum) {

            for (int i =0; i< sWindowNum; i++)
            {
                windows.Add(new SmartWindow());
            }
             // Adding the the windows to the Wall based on the drawings
        }
        public void buildDoor(int SDoorNum) {

            for (int i = 0; i < SDoorNum; i++)
            {
                doors.Add(new SmartDoor());
            }

            // Adding the the Doors to the Wall based on the drawings
        }
        public void buildLight(int sLightNum) {
         
            for (int i = 0; i < sLightNum; i++)
            {
                lights.Add(new SmartLight() { Name = $"Light {i}" });
            }
        }
        public void buildRoom(int id, String type, String name)
        {

            switch (type)
            {
                case "Entrance":
                    {
                        Entrance entrance = new Entrance()
                        {
                            Id = id,
                            Name = name,
                            LeftWall = leftWall,
                            RightWall = rightWall,
                            TopWall = topWall,
                            BottomWall = bottomWall,
                            Lights = lights
                        };
                        rooms.Add(entrance);
                        break;
                    }
                case "CommonRoom":
                    {
                        CommonRoom commonRoom = new CommonRoom()
                        {
                            Id = id,
                            Name = name,
                            LeftWall = leftWall,
                            RightWall = rightWall,
                            TopWall = topWall,
                            BottomWall = bottomWall,
                            Lights = lights
                        };
                        rooms.Add(commonRoom);

                        // code block
                        break;
                    }
                case "Garage":
                    {
                        Garage garage = new Garage()
                        {
                            Id = id,
                            Name = name,
                            LeftWall = leftWall,
                            RightWall = rightWall,
                            TopWall = topWall,
                            BottomWall = bottomWall,
                            Lights = lights
                        };
                        rooms.Add(garage);
                        break;
                    }       
                case "Backyard":
                    {
                        Backyard backyard = new Backyard()
                        {
                            Id = id,
                            Name = name,
                            LeftWall = leftWall,
                            RightWall = rightWall,
                            TopWall = topWall,
                            BottomWall = bottomWall,
                            Lights = lights
                        };
                        rooms.Add(backyard);

                        // code block
                        break;
                    }
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
            singleHome = new House()
            {
                Rooms = rooms
            };
            
        }

        public House getProduct()
        {
            return singleHome;
            Console.WriteLine("Mercy");
        }
        
    }
}
