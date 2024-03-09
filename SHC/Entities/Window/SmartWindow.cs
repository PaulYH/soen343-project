using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities.Window
{
    public class SmartWindow : IWindow
    {
        public string Name { get; set; }
        public bool isOpen { get; set; } = false;
    }
}
