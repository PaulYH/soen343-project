using SHC.Entities;
using SHC.Entities.Room;
using SHC.Entities.Window;
using SHC.Utilities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Utilities.Observer
{
    public class SmartHomeHeating : IObserver
    {
        public List<(int zoneNum, List<IRoom> rooms, double temp1, double temp2, double temp3)> ZoneManagement;
        public List<(int roomId, List<double> roomTemps)> OldRoomTemps = new List<(int roomId, List<double> roomTemps)>();
        private int minuteTickCounter = 0;

        public SmartHomeHeating() 
        {
            var simContext = SimulationContext.GetInstance();
            foreach (var room in simContext.RenderRooms)
            {
                
                OldRoomTemps.Add((room.Item1.Id, new List<double>() { room.Item1.Temperature }));
            }
        }

        public void Update(IEventListener eventListener)
        {
            ZoneManagement = ((SHHListener)eventListener).state;
        }



        public async Task UpdateRoomTemperaturesHAVCOn(string timeOfDay)
        {
            SimulationContext simulationContext = SimulationContext.GetInstance();

            switch (timeOfDay)
            {
                case "time1":
                    foreach (var room in simulationContext.RenderRooms)
                    {
                        if (room.Item1.Name == "Backyard")
                        {
                            room.Item1.Temperature = simulationContext.OutsideTemperature;
                            room.Item1.TempStatus = "outside";
                            continue;
                        }

                        if (!room.Item1.IsZoneOverriden)
                        {
                            var zone = ZoneManagement.Where(x => x.zoneNum == room.Item1.ZoneNum).FirstOrDefault();

                            if (room.Item1.Temperature < zone.temp1 - 0.25 || room.Item1.Temperature > zone.temp1 + 0.25)
                            {
                                if (room.Item1.Temperature < zone.temp1)
                                {
                                    room.Item1.TempStatus = "heating";
                                    room.Item1.Temperature += 0.1;
                                    continue;
                                }

                                if (room.Item1.Temperature > zone.temp1)
                                {
                                    room.Item1.TempStatus = "cooling";
                                    room.Item1.Temperature -= 0.1;
                                    continue;
                                }
                            }

                            if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature += 0.05;
                                continue;
                            }

                            if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature -= 0.05;
                                continue;
                            }
                        }
                        else
                        {
                            if (room.Item1.Temperature < room.Item1.OverrideTemp - 0.25 || room.Item1.Temperature > room.Item1.OverrideTemp + 0.25)
                            {
                                if (room.Item1.Temperature < room.Item1.OverrideTemp)
                                {
                                    room.Item1.TempStatus = "heating";
                                    room.Item1.Temperature += 0.1;
                                    continue;
                                }

                                if (room.Item1.Temperature > room.Item1.OverrideTemp)
                                {
                                    room.Item1.TempStatus = "cooling";
                                    room.Item1.Temperature -= 0.1;
                                    continue;
                                }
                            }

                            if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature += 0.05;
                                continue;
                            }

                            if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature -= 0.05;
                                continue;
                            }
                        }
                    }
                    break;
                case "time2":
                    foreach (var room in simulationContext.RenderRooms)
                    {
                        if (room.Item1.Name == "Backyard")
                        {
                            room.Item1.Temperature = simulationContext.OutsideTemperature;
                            room.Item1.TempStatus = "outside";
                            continue;
                        }

                        if (!room.Item1.IsZoneOverriden)
                        {
                            var zone = ZoneManagement.Where(x => x.zoneNum == room.Item1.ZoneNum).FirstOrDefault();

                            if (room.Item1.Temperature < zone.temp2 - 0.25 || room.Item1.Temperature > zone.temp2 + 0.25)
                            {
                                if (room.Item1.Temperature < zone.temp2)
                                {
                                    room.Item1.TempStatus = "heating";
                                    room.Item1.Temperature += 0.1;
                                    continue;
                                }

                                if (room.Item1.Temperature > zone.temp2)
                                {
                                    room.Item1.TempStatus = "cooling";
                                    room.Item1.Temperature -= 0.1;
                                    continue;
                                }
                            }

                            if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature += 0.05;
                                continue;
                            }

                            if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature -= 0.05;
                                continue;
                            }
                        }
                        else
                        {
                            if (room.Item1.Temperature < room.Item1.OverrideTemp - 0.25 || room.Item1.Temperature > room.Item1.OverrideTemp + 0.25)
                            {
                                if (room.Item1.Temperature < room.Item1.OverrideTemp)
                                {
                                    room.Item1.TempStatus = "heating";
                                    room.Item1.Temperature += 0.1;
                                    continue;
                                }

                                if (room.Item1.Temperature > room.Item1.OverrideTemp)
                                {
                                    room.Item1.TempStatus = "cooling";
                                    room.Item1.Temperature -= 0.1;
                                    continue;
                                }
                            }

                            if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature += 0.05;
                                continue;
                            }

                            if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature -= 0.05;
                                continue;
                            }
                        }                    
                    }
                    break;
                case "time3":
                    foreach (var room in simulationContext.RenderRooms)
                    {
                        if (room.Item1.Name == "Backyard")
                        {
                            room.Item1.Temperature = simulationContext.OutsideTemperature;
                            room.Item1.TempStatus = "outside";
                            continue;
                        }

                        if (!room.Item1.IsZoneOverriden)
                        {
                            var zone = ZoneManagement.Where(x => x.zoneNum == room.Item1.ZoneNum).FirstOrDefault();

                            if (room.Item1.Temperature < zone.temp3 - 0.25 || room.Item1.Temperature > zone.temp3 + 0.25)
                            {
                                if (room.Item1.Temperature < zone.temp3)
                                {
                                    room.Item1.TempStatus = "heating";
                                    room.Item1.Temperature += 0.1;
                                    continue;
                                }

                                if (room.Item1.Temperature > zone.temp3)
                                {
                                    room.Item1.TempStatus = "cooling";
                                    room.Item1.Temperature -= 0.1;
                                    continue;
                                }
                            }

                            if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature += 0.05;
                                continue;
                            }

                            if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature -= 0.05;
                                continue;
                            }
                        }
                        else
                        {
                            if (room.Item1.Temperature < room.Item1.OverrideTemp - 0.25 || room.Item1.Temperature > room.Item1.OverrideTemp + 0.25)
                            {
                                if (room.Item1.Temperature < room.Item1.OverrideTemp)
                                {
                                    room.Item1.TempStatus = "heating";
                                    room.Item1.Temperature += 0.1;
                                    continue;
                                }

                                if (room.Item1.Temperature > room.Item1.OverrideTemp)
                                {
                                    room.Item1.TempStatus = "cooling";
                                    room.Item1.Temperature -= 0.1;
                                    continue;
                                }
                            }

                            if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature += 0.05;
                                continue;
                            }

                            if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                            {
                                room.Item1.TempStatus = "off";
                                room.Item1.Temperature -= 0.05;
                                continue;
                            }
                        }
                    }
                    break;
            }

            foreach (var room in simulationContext.RenderRooms)
            {
                CheckTempHistoryForJump(room.Item1);

                if (room.Item1.Temperature > 135)
                {
                    simulationContext.SHPContext.ChangeState(new RegularState(simulationContext.SHPContext));

                    var msg = $"Temperature over 135 °C in {room.Item1.Name}. Turning off Away mode.";

                    if (simulationContext.UserMessage != msg)
                    {
                        simulationContext.UserMessage = $"Temperature over 135 °C in {room.Item1.Name}. Turning off Away mode.";
                        OutputConsole.GetInstance().Log($"Room-{room.Item1.Id}", "SHP module", "Emergency Away mode shut off.", $"Temperature over 135 °C in {room.Item1.Name}.");
                    }
                }

                if (room.Item1.Temperature < simulationContext.OutsideTemperature && simulationContext.OutsideTemperature >= 20 && !simulationContext.IsAwayOn)
                {
                    var roomWindowTop = room.Item1.TopWall.Window;
                    var roomWindowBottom = room.Item1.BottomWall.Window;
                    var roomWindowRight = room.Item1.RightWall.Window;
                    var roomWindowLeft = room.Item1.LeftWall.Window;

                    List<IWindow> windows = new List<IWindow>() { roomWindowTop, roomWindowBottom, roomWindowRight, roomWindowLeft};

                    foreach (SmartWindow window in windows)
                    {
                        if (window != null)
                        {
                            if (window.isBlocked)
                            {
                                simulationContext.UserMessage = $"Window is blocked in {room.Item1.Name}. SHH module cannot open the windows.";
                                OutputConsole.GetInstance().Log(window.Name, "Window open failed", "Blocked window", $"Window is blocked in {room.Item1.Name}. SHH module cannot open the windows.");
                                break;
                            }
                            window.isOpen = true;
                        }
                    }
                }

                if (room.Item1.Temperature <= 0)
                {
                    simulationContext.UserMessage = "Temperature of 0 or less detected in home. This is a risk for pipes bursting.";
                    OutputConsole.GetInstance().Log(room.Item1.Name, "Low temperature", "Temperature warning", $"Temperature of 0 or less detected in {room.Item1.Name}. This is a risk for pipes bursting.");
                }
            }

            if (minuteTickCounter < 59)
            {
                minuteTickCounter++;
            }
        }

        public async Task UpdateRoomTemperaturesHAVCOff()
        {
            SimulationContext simulationContext = SimulationContext.GetInstance();

            foreach (var room in simulationContext.RenderRooms)
            {
                if (room.Item1.Name == "Backyard")
                {
                    room.Item1.Temperature = simulationContext.OutsideTemperature;
                    room.Item1.TempStatus = "outside";
                    continue;
                }

                var zone = ZoneManagement.Where(x => x.zoneNum == room.Item1.ZoneNum).FirstOrDefault();

                if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                {
                    room.Item1.TempStatus = "off";
                    room.Item1.Temperature += 0.05;
                    continue;
                }
                if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                {
                    room.Item1.TempStatus = "off";
                    room.Item1.Temperature -= 0.05;
                    continue;
                }

                CheckTempHistoryForJump(room.Item1);
            }

            if (minuteTickCounter < 59)
            {
                minuteTickCounter++;
            }
        }

        private void CheckTempHistoryForJump(IRoom room)
        {
            if (minuteTickCounter < 59)
            {
                OldRoomTemps.Where(x => x.roomId == room.Id).First().roomTemps.Add(room.Temperature);
            }
            else
            {
                OldRoomTemps.Where(x => x.roomId == room.Id).First().roomTemps.Add(room.Temperature);
                OldRoomTemps.Where(x => x.roomId == room.Id).First().roomTemps.RemoveAt(0);

                var roomTemps = OldRoomTemps.Where(x => x.roomId == room.Id).First().roomTemps;

                var difference = roomTemps.Last() - roomTemps.First();

                if (difference >= 15)
                {
                    // turn off away mode and notify owners
                    var simContext = SimulationContext.GetInstance();
                    simContext.SHPContext.ChangeState(new RegularState(simContext.SHPContext));

                    simContext.UserMessage = $"Sudden jump of {difference} °C in {room.Name} detected. Turning off Away mode.";
                    OutputConsole.GetInstance().Log($"Room-{room.Id}", "SHP module", "Emergency Away mode shut off.", $"Sudden jump of {difference} °C in {room.Name} detected.");
                }
            }
        }
    }
}
