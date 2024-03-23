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
    }
}
