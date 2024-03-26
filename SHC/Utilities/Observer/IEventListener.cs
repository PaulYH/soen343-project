using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Utilities.Observer
{
    public interface IEventListener
    {
        public void AddSubscriber(IObserver observer);
        public void RemoveSubscriber(IObserver observer);
        public void Notify();
    }
}
