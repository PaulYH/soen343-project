using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Utilities.State
{
    public class RegularState : IState
    {
        private SmartHomeSecurity context;
        public RegularState(SmartHomeSecurity context) 
        { 
            this.context = context;
        }
    }
}
