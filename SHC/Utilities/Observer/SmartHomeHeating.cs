using SHC.Entities;
using SHC.Entities.Room;
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
        public List<(int roomId, List<double> roomTemps)> OldRoomTemps;
        private int minuteTickCounter = 0;

        public void Update(IEventListener eventListener)
        {
            ZoneManagement = ((SHHListener)eventListener).state;

            var simContext = SimulationContext.GetInstance();

            foreach (var room in simContext.RenderRooms)
            {
                OldRoomTemps.Add((room.Item1.Id, new List<double>() { room.Item1.Temperature }));
            }
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

                        CheckTempHistoryForJump(room.Item1);
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

                        CheckTempHistoryForJump(room.Item1);
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

                        CheckTempHistoryForJump(room.Item1);
                    }
                    break;
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
                    Console.WriteLine($"Jump of over 15 c in room {room.Name}");
                }
            }
        }
    }
}
