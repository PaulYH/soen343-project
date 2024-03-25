using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities.Light
{
    public class SmartLight : ILight
    {
        public string Name { get; set; }
        public bool isOn { get; set; } = false;
        public bool autoMode { get; set; } = true;
    }
}
