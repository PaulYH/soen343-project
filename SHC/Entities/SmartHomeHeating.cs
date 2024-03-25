using SHC.Entities.Room;
using SHC.Utilities.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities
{
    public class SmartHomeHeating : IObserver
    {
        public List<(int zoneNum, List<IRoom> rooms, double temp1, double temp2, double temp3)> ZoneManagement;
        public void Update(IEventListener eventListener)
        {
            ZoneManagement = ((SHHListener) eventListener).state;
        }

        public async Task UpdateRoomTemperaturesHAVCOn(string timeOfDay)
        {
            SimulationContext simulationContext = SimulationContext.GetInstance();

            switch (timeOfDay)
            {
                case "time1":
                    foreach (var room in simulationContext.RenderRooms)
                    {
                        var zone = ZoneManagement.Where(x => x.zoneNum == room.Item1.ZoneNum).FirstOrDefault();

                        if (room.Item1.Temperature < zone.temp1 - 0.25 || room.Item1.Temperature > zone.temp1 + 0.25)
                        {
                            if (room.Item1.Temperature < zone.temp1)
                            {
                                room.Item1.Temperature += 0.1;
                                continue;
                            }

                            if (room.Item1.Temperature > zone.temp1)
                            {
                                room.Item1.Temperature -= 0.1;
                                continue;
                            }
                        }
                        
                        if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                        {
                            room.Item1.Temperature += 0.05;
                            continue;
                        }

                        if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                        {
                            room.Item1.Temperature -= 0.05;
                            continue;
                        }
                    }
                    break;
                case "time2":
                    foreach (var room in simulationContext.RenderRooms)
                    {
                        var zone = ZoneManagement.Where(x => x.zoneNum == room.Item1.ZoneNum).FirstOrDefault();

                        if (room.Item1.Temperature < zone.temp2 - 0.25 || room.Item1.Temperature > zone.temp2 + 0.25)
                        {
                            if (room.Item1.Temperature < zone.temp2)
                            {
                                room.Item1.Temperature += 0.1;
                                continue;
                            }

                            if (room.Item1.Temperature > zone.temp2)
                            {
                                room.Item1.Temperature -= 0.1;
                                continue;
                            }
                        }

                        if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                        {
                            room.Item1.Temperature += 0.05;
                            continue;
                        }

                        if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                        {
                            room.Item1.Temperature -= 0.05;
                            continue;
                        }
                    }
                    break;
                case "time3":
                    foreach (var room in simulationContext.RenderRooms)
                    {
                        var zone = ZoneManagement.Where(x => x.zoneNum == room.Item1.ZoneNum).FirstOrDefault();

                        if (room.Item1.Temperature < zone.temp3 - 0.25 || room.Item1.Temperature > zone.temp3 + 0.25)
                        {
                            if (room.Item1.Temperature < zone.temp3)
                            {
                                room.Item1.Temperature += 0.1;
                                continue;
                            }

                            if (room.Item1.Temperature > zone.temp3)
                            {
                                room.Item1.Temperature -= 0.1;
                                continue;
                            }
                        }

                        if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                        {
                            room.Item1.Temperature += 0.05;
                            continue;
                        }

                        if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                        {
                            room.Item1.Temperature -= 0.05;
                            continue;
                        }
                    }
                    break;
            }

        }

        public async Task UpdateRoomTemperaturesHAVCOff()
        {
            SimulationContext simulationContext = SimulationContext.GetInstance();

            foreach (var room in simulationContext.RenderRooms)
            {
                var zone = ZoneManagement.Where(x => x.zoneNum == room.Item1.ZoneNum).FirstOrDefault();

                if (room.Item1.Temperature < simulationContext.OutsideTemperature)
                {
                    room.Item1.Temperature += 0.05;
                    continue;
                }
                if (room.Item1.Temperature > simulationContext.OutsideTemperature)
                {
                    room.Item1.Temperature -= 0.05;
                    continue;
                }
            }
        }
    }
}
