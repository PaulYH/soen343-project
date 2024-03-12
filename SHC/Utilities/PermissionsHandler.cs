using SHC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SHC.Services;

namespace SHC.Utilities
{
    public class PermissionsHandler : RegisterRequestHandler
    {
        private readonly IUserService _userService;
        public PermissionsHandler(IUserService userService) 
        {
            _userService = userService;
        }
        public async Task<VirtualUser> HandleRegisterRequest(RegisterRequest request)
        {
            // pass to userService
            return await _userService.HandleRegisterRequest(request);
        }
    }
}
