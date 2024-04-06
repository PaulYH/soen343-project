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
        }

    }
}
