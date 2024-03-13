using SHC.Entities;
using SHC.Entities.Door;
using SHC.Entities.Light;
using SHC.Entities.Room;
using SHC.Entities.Window;

namespace HomeSHS.Components.Helpers
{
    public class HouseAssembler
    {
        private List<(IRoom, (double x, double y))> renderRooms = new List<(IRoom, (double x, double y))>();
        private House house;
        private Entrance? entrance;
        private int roomSize = 100;
        private static Random rand = new Random();

        public HouseAssembler()
        {
            house = GetHouse();
        }

        private House GetHouse()
        {
            //this hard-coded house is temporary, should be replaced with the one defined by the house-layout file
            var result = new House()
            {
                Rooms = new List<IRoom>()
                {
                    new Entrance()
                    {
                        Id = 0,
                        Name = "Entrance",
                        LeftWall = new Wall()
                        {
                            Length = 1,
                            Door = new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            },

                            Window = new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                            
                        },
                        RightWall = new Wall()
                        {
                            Length = 1,
                            Door = new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            },

                            Window = new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                        },
                        TopWall = new Wall()
                        {
                            Length = 1,
                            Door = new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            },

                            Window = new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                        },
                        BottomWall = new Wall()
                        {
                            Length = 1,
                            Door = new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            },

                            Window = new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                        },
                        Lights = new List<ILight>()
                        {
                            new RegularLight()
                            {
                                Name = "RegularLight1"
                            },
                            new SmartLight()
                            {
                                Name = "SmartLight2"
                            }
                        }
                    },
                    new CommonRoom()
                    {
                        Id = 1,
                        Name = "Room1",
                        LeftWall = new Wall()
                        {
                            Length = 1,
                            Door = new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            },

                            Window = new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                        },
                        RightWall = new Wall()
                        {
                            Length = 1,
                            Door = new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            },

                            Window = new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                        },
                        TopWall = new Wall()
                        {
                            Length = 1,
                            Door = new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            },

                            Window = new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                        },
                        BottomWall = new Wall()
                        {
                            Length = 1,
                            Door = new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            },

                            Window = new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                        },
                        Lights = new List<ILight>()
                        {
                            new RegularLight()
                            {
                                Name = "RegularLight1"
                            },
                            new SmartLight()
                            {
                                Name = "SmartLight2"
                            }
                        }
                    },
                    new CommonRoom()
                    {
                        Id = 3,
                        Name = "Room2",
                        LeftWall = new Wall()
                        {
                                Length = 1,
                                Door = new SmartDoor()
                                {
                                    Name = "SmartDoor1"
                                },

                                Window = new RegularWindow()
                                {
                                    Name = "RegularWindow1"
                                }
                        },
                        RightWall = new Wall()
                        {
                                Length = 1,
                                Door = new SmartDoor()
                                {
                                    Name = "SmartDoor1"
                                },

                                Window = new RegularWindow()
                                {
                                    Name = "RegularWindow1"
                                }
                        },
                        TopWall = new Wall()
                        {
                                Length = 1,
                                Door = new SmartDoor()
                                {
                                    Name = "SmartDoor1"
                                },

                                Window = new RegularWindow()
                                {
                                    Name = "RegularWindow1"
                                }
                        },
                        BottomWall = new Wall()
                        {
                                Length = 1,
                                Door = new SmartDoor()
                                {
                                    Name = "SmartDoor1"
                                },

                                Window = new RegularWindow()
                                {
                                    Name = "RegularWindow1"
                                }
                        },
                        Lights = new List<ILight>()
                        {
                            new RegularLight()
                            {
                                Name = "RegularLight1"
                            },
                            new SmartLight()
                            {
                                Name = "SmartLight2"
                            }
                        }
                    }
                }
            };

            return result;
        }

        public List<(IRoom, (double x, double y))> BuildLayoutStructure()
        {
            AddEntrance();

            foreach(var room in house.Rooms)
            {
                List<string> sidesToCheck = new List<string>() {"left", "right", "top", "bottom"};
                string sideWithFreeDoor = "";
                bool roomAttached = false;
                while(!roomAttached && sidesToCheck.Count != 0)
                {
                    var side = sidesToCheck[rand.Next(sidesToCheck.Count)];
                    switch (side)
                    {
                        case "left":
                            if (CheckWallForDoor(room.LeftWall))
                                sideWithFreeDoor = side;
                            break;
                        case "right":
                            if (CheckWallForDoor(room.RightWall))
                                sideWithFreeDoor = side;
                            break;
                        case "top":
                            if (CheckWallForDoor(room.TopWall))
                                sideWithFreeDoor = side;
                            break;
                        case "bottom":
                            if (CheckWallForDoor(room.BottomWall))
                                sideWithFreeDoor = side;
                            break;
                    }
                    sidesToCheck.Remove(side);

                    if (sideWithFreeDoor != "")
                    {
                        List<(IRoom, (double x, double y))> roomsToCheck = new List<(IRoom, (double x, double y))>(renderRooms);
                        while(!roomAttached && roomsToCheck.Count != 0) 
                        {
                            var randomIndex = rand.Next(roomsToCheck.Count);
                            var renderRoom = renderRooms[randomIndex];
                            switch (sideWithFreeDoor)
                            {
                                case "left":
                                    if (CheckWallForDoor(renderRoom.Item1.RightWall))
                                    {
                                        var x = renderRoom.Item2.x + 100;
                                        var y = renderRoom.Item2.y;
                                        var newCoords = (x, y);
                                        room.LeftWall.Door.SideB = renderRoom.Item1;


                                        var newRenderRoom = (room, newCoords);

                                        room.RightWall.Door.SideB = renderRoom.Item1;

                                        renderRooms.Add(newRenderRoom);
                                        renderRooms[randomIndex] = renderRoom;

                                        roomAttached = true;
                                    }
                                    break;
                                case "right":
                                    if (CheckWallForDoor(renderRoom.Item1.LeftWall))
                                    {
                                        var x = renderRoom.Item2.x - 100;
                                        var y = renderRoom.Item2.y;
                                        var newCoords = (x, y);
                                        room.RightWall.Door.SideB = renderRoom.Item1;

                                        var newRenderRoom = (room, newCoords);

                                        room.LeftWall.Door.SideB = renderRoom.Item1;

                                        renderRooms.Add(newRenderRoom);
                                        renderRooms[randomIndex] = renderRoom;

                                        roomAttached = true;
                                    }
                                    break;
                                case "top":
                                    if (renderRoom.Item1 is Entrance)
                                        break;
                                    if (CheckWallForDoor(renderRoom.Item1.BottomWall))
                                    {
                                        var x = renderRoom.Item2.x;
                                        var y = renderRoom.Item2.y + 100;
                                        var newCoords = (x, y);
                                        room.TopWall.Door.SideB = renderRoom.Item1;

                                        var newRenderRoom = (room, newCoords);

                                        room.BottomWall.Door.SideB = renderRoom.Item1;

                                        renderRooms.Add(newRenderRoom);
                                        renderRooms[randomIndex] = renderRoom;

                                        roomAttached = true;
                                    }
                                    break;
                                case "bottom":
                                    if (CheckWallForDoor(renderRoom.Item1.TopWall))
                                    {
                                        var x = renderRoom.Item2.x;
                                        var y = renderRoom.Item2.y - 100;
                                        var newCoords = (x, y);
                                        room.BottomWall.Door.SideB = renderRoom.Item1;

                                        var newRenderRoom = (room, newCoords);

                                        room.TopWall.Door.SideB = renderRoom.Item1;

                                        renderRooms.Add(newRenderRoom);
                                        renderRooms[randomIndex] = renderRoom;

                                        roomAttached = true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            return renderRooms;
        }

        public void AddEntrance()
        {
            if (house.Rooms == null || house.Rooms.Count == 0)
                throw new InvalidDataException("The room list is empty");
            if (house.Rooms.First() is not Entrance)
                throw new InvalidDataException("The first element in the room list is not of type Entrance");

            entrance = (Entrance) house.Rooms.First();
            renderRooms.Add((entrance, (400, 400)));
            house.Rooms.Remove(entrance);
        }


        public bool CheckWallForDoor(Wall wall)
        {
            if (wall.Door == null)
                return false;
            if (wall.Door.SideB == null)
                return true;
            return false;
        }
    }
}
