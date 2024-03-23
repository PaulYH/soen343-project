using SHC.Entities.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Utilities.Observer
{
    public class SHHListener : IEventListener
    {
        public List<(int zoneNum, List<IRoom> rooms, double temp1, double temp2, double temp3)> state;
        public List<IObserver> observers = new List<IObserver>();

        public SHHListener(List<(int zoneNum, List<IRoom> rooms, double temp1, double temp2, double temp3)> _state)
        {
            state = _state;
        }
        public void AddSubscriber(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveSubscriber(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(this);
            }
        }
    }
}
