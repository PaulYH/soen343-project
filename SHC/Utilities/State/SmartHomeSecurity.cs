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

        public SmartHomeSecurity()
        {
            state = new RegularState(this);
        }

        public void ChangeState(IState newState)
        {
            state = newState;
        }


    }
}
