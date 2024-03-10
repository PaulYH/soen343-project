using SHC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Utilities
{
    internal interface RegisterRequestHandler
    {
        Task<VirtualUser> HandleRegisterRequest(RegisterRequest request);
    }
}
