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
                            Doors = new List<IDoor>()
                            {
                                new SmartDoor()
                                {
                                    Name = "SmartDoor1"
                                }
                            },
                            Windows = new List<IWindow>()
                            {
                                new RegularWindow()
                                {
                                    Name = "RegularWindow1"
                                }
                            }
                        },
                        RightWall = new Wall()
                        {
                            Length = 1,
                            Doors = new List<IDoor>()
                            {
                                new RegularDoor()
                                {
                                    Name = "RegularDoor2"
                                }
                            },
                            Windows = new List<IWindow>()
                            {
                                new RegularWindow()
                                {
                                    Name = "RegularWindow2"
                                }
                            }
                        },
                        TopWall = new Wall()
                        {
                            Length = 1,
                            Doors = new List<IDoor>()
                            {
                                new RegularDoor()
                                {
                                    Name = "RegularDoor3"
                                }
                            },
                            Windows = new List<IWindow>()
                            {
                                new SmartWindow()
                                {
                                    Name = "SmartWindow3"
                                }
                            }
                        },
                        BottomWall = new Wall()
                        {
                            Length = 1,
                            Doors = new List<IDoor>()
                            {
                                new RegularDoor()
                                {
                                    Name = "RegularDoor4"
                                }
                            },
                            Windows = new List<IWindow>()
                            {
                                new RegularWindow()
                                {
                                    Name = "RegularWindow4"
                                }
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
                            Doors = new List<IDoor>()
                            {
                                new SmartDoor()
                                {
                                    Name = "SmartDoor1"
                                }
                            },
                            Windows = new List<IWindow>()
                            {
                                new RegularWindow()
                                {
                                    Name = "RegularWindow1"
                                }
                            }
                        },
                        RightWall = new Wall()
                        {
                            Length = 1,
                            Doors = new List<IDoor>()
                            {
                                new RegularDoor()
                                {
                                    Name = "RegularDoor2"
                                }
                            },
                            Windows = new List<IWindow>()
                            {
                                new RegularWindow()
                                {
                                    Name = "RegularWindow2"
                                }
                            }
                        },
                        TopWall = new Wall()
                        {
                            Length = 1,
                            Doors = new List<IDoor>()
                            {
                                new RegularDoor()
                                {
                                    Name = "RegularDoor3"
                                }
                            },
                            Windows = new List<IWindow>()
                            {
                                new SmartWindow()
                                {
                                    Name = "SmartWindow3"
                                }
                            }
                        },
                        BottomWall = new Wall()
                        {
                            Length = 1,
                            Doors = new List<IDoor>()
                            {
                                new RegularDoor()
                                {
                                    Name = "RegularDoor4"
                                }
                            },
                            Windows = new List<IWindow>()
                            {
                                new RegularWindow()
                                {
                                    Name = "RegularWindow4"
                                }
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
                    Name = "Room2",
                    LeftWall = new Wall()
                    {
                        Length = 1,
                        Doors = new List<IDoor>()
                        {
                            new SmartDoor()
                            {
                                Name = "SmartDoor1"
                            }
                        },
                        Windows = new List<IWindow>()
                        {
                            new RegularWindow()
                            {
                                Name = "RegularWindow1"
                            }
                        }
                    },
                    RightWall = new Wall()
                    {
                        Length = 1,
                        Doors = new List<IDoor>()
                        {
                            new RegularDoor()
                            {
                                Name = "RegularDoor2"
                            }
                        },
                        Windows = new List<IWindow>()
                        {
                            new RegularWindow()
                            {
                                Name = "RegularWindow2"
                            }
                        }
                    },
                    TopWall = new Wall()
                    {
                        Length = 1,
                        Doors = new List<IDoor>()
                        {
                            new RegularDoor()
                            {
                                Name = "RegularDoor3"
                            }
                        },
                        Windows = new List<IWindow>()
                        {
                            new SmartWindow()
                            {
                                Name = "SmartWindow3"
                            }
                        }
                    },
                    BottomWall = new Wall()
                    {
                        Length = 1,
                        Doors = new List<IDoor>()
                        {
                            new RegularDoor()
                            {
                                Name = "RegularDoor4"
                            }
                        },
                        Windows = new List<IWindow>()
                        {
                            new RegularWindow()
                            {
                                Name = "RegularWindow4"
                            }
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
                            if (CheckWallForDoors(room.LeftWall))
                                sideWithFreeDoor = side;
                            break;
                        case "right":
                            if (CheckWallForDoors(room.RightWall))
                                sideWithFreeDoor = side;
                            break;
                        case "top":
                            if (CheckWallForDoors(room.TopWall))
                                sideWithFreeDoor = side;
                            break;
                        case "bottom":
                            if (CheckWallForDoors(room.BottomWall))
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
                                    if (CheckWallForDoors(renderRoom.Item1.RightWall))
                                    {
                                        var x = renderRoom.Item2.x + 100;
                                        var y = renderRoom.Item2.y;
                                        var newCoords = (x, y);
                                        foreach(IDoor door in room.LeftWall.Doors)
                                        {
                                            door.SideB = renderRoom.Item1;
                                        }

                                        var newRenderRoom = (room, newCoords);

                                        foreach (IDoor door in renderRoom.Item1.RightWall.Doors)
                                        {
                                            door.SideB = newRenderRoom.room;
                                        }

                                        renderRooms.Add(newRenderRoom);
                                        renderRooms[randomIndex] = renderRoom;

                                        roomAttached = true;
                                    }
                                    break;
                                case "right":
                                    if (CheckWallForDoors(renderRoom.Item1.LeftWall))
                                    {
                                        var x = renderRoom.Item2.x - 100;
                                        var y = renderRoom.Item2.y;
                                        var newCoords = (x, y);
                                        foreach (IDoor door in room.RightWall.Doors)
                                        {
                                            door.SideB = renderRoom.Item1;
                                        }

                                        var newRenderRoom = (room, newCoords);

                                        foreach (IDoor door in renderRoom.Item1.LeftWall.Doors)
                                        {
                                            door.SideB = newRenderRoom.room;
                                        }

                                        renderRooms.Add(newRenderRoom);
                                        renderRooms[randomIndex] = renderRoom;

                                        roomAttached = true;
                                    }
                                    break;
                                case "top":
                                    if (renderRoom.Item1 is Entrance)
                                        break;
                                    if (CheckWallForDoors(renderRoom.Item1.BottomWall))
                                    {
                                        var x = renderRoom.Item2.x;
                                        var y = renderRoom.Item2.y + 100;
                                        var newCoords = (x, y);
                                        foreach (IDoor door in room.TopWall.Doors)
                                        {
                                            door.SideB = renderRoom.Item1;
                                        }

                                        var newRenderRoom = (room, newCoords);

                                        foreach (IDoor door in renderRoom.Item1.BottomWall.Doors)
                                        {
                                            door.SideB = newRenderRoom.room;
                                        }

                                        renderRooms.Add(newRenderRoom);
                                        renderRooms[randomIndex] = renderRoom;

                                        roomAttached = true;
                                    }
                                    break;
                                case "bottom":
                                    if (CheckWallForDoors(renderRoom.Item1.TopWall))
                                    {
                                        var x = renderRoom.Item2.x;
                                        var y = renderRoom.Item2.y - 100;
                                        var newCoords = (x, y);
                                        foreach (IDoor door in room.BottomWall.Doors)
                                        {
                                            door.SideB = renderRoom.Item1;
                                        }

                                        var newRenderRoom = (room, newCoords);

                                        foreach (IDoor door in renderRoom.Item1.TopWall.Doors)
                                        {
                                            door.SideB = newRenderRoom.room;
                                        }

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


        public bool CheckWallForDoors(Wall wall)
        {
            foreach (var door in wall.Doors)
            {
                if (door.SideB == null)
                    return true;
            }
            return false;
        }
    }
}
