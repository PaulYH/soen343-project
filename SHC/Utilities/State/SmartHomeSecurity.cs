using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Utilities.State
{
    public class SmartHomeSecurity
    {
        private IState state;
        private int policeTimerMinutes = 1;
        private int policeTimerSeconds = 0;
        private int policeTimerTicks = -1;

        public SmartHomeSecurity()
        {
            state = new RegularState(this);
        }

        public void ChangeState(IState newState)
        {
            state = newState;
        }

        public int CheckForPresenceInRooms()
        {
            return state.CheckForPresenceInRooms();
        }

        public void SetTimerMinutes(int value)
        {
            policeTimerMinutes = value;
        }

        public void SetTimerSeconds(int value)
        {
            policeTimerSeconds = value;
        }

        public void SetTimerTicks(int value)
        { 
            policeTimerTicks = value;
        }

        public int GetTimerMinutes()
        {
            return policeTimerMinutes;
        }

        public int GetTimerSeconds()
        {
            return policeTimerSeconds;
        }

        public int GetTimerTicks()
        {
            return policeTimerTicks;
        }
    }
}
