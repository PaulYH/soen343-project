using SHC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Utilities.State
{
    public class AwayState : IState
    {
        private SmartHomeSecurity context;

        public AwayState(SmartHomeSecurity context)
        { 
            this.context = context;

            int policeTimerTicks = (context.GetTimerMinutes() * 60) + context.GetTimerSeconds();
            context.SetTimerTicks(policeTimerTicks);
        }

        public int CheckForPresenceInRooms()
        {
            var simulationContext = SimulationContext.GetInstance();

            foreach (var room in simulationContext.RenderRooms)
            {
                if (room.Item1.HasMotionDetector && room.Item1.Occupants.Count > 0)
                {
                    simulationContext.UserMessage = "Motion detected in " + room.Item1.Name +". Police will be called in " + (context.GetTimerTicks()) + " seconds.";
                    return room.Item1.Id;
                }
            }

            return -1;
        }
    }
}
