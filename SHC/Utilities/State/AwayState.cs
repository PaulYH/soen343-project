using SHC.Entities;
using SHC.Entities.Door;
using SHC.Entities.Window;
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

            CloseWindowsAndDoors();
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

        private void CloseWindowsAndDoors()
        {
            var simulationContext = SimulationContext.GetInstance();

            foreach (var room in simulationContext.RenderRooms)
            {
                var topWall = room.Item1.TopWall;
                var bottomWall = room.Item1.BottomWall;
                var rightWall = room.Item1.RightWall;
                var leftWall = room.Item1.LeftWall;

                if (topWall.Window != null)
                {
                    var window = (SmartWindow)topWall.Window;
                    window.isOpen = false;
                }
                if (topWall.Door != null)
                {
                    var door = (SmartDoor)topWall.Door;
                    door.IsLocked = true;
                }


                if (bottomWall.Window != null)
                {
                    var window = (SmartWindow)bottomWall.Window;
                    window.isOpen = false;
                }
                if (bottomWall.Door != null)
                {
                    var door = (SmartDoor)bottomWall.Door;
                    door.IsLocked = true;
                }


                if (rightWall.Window != null)
                {
                    var window = (SmartWindow)rightWall.Window;
                    window.isOpen = false;
                }
                if (rightWall.Door != null)
                {
                    var door = (SmartDoor)rightWall.Door;
                    door.IsLocked = true;
                }


                if (leftWall.Window != null)
                {
                    var window = (SmartWindow)leftWall.Window;
                    window.isOpen = false;
                }
                if (leftWall.Door != null)
                {
                    var door = (SmartDoor)leftWall.Door;
                    door.IsLocked = true;
                }
            }
        }
    }
}
