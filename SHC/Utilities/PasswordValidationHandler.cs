using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SHC.Entities;
using SHC.Controllers;
using SHC.Services;



namespace SHC.Utilities
{
    public class PasswordValidationHandler: RegisterRequestHandler
    {
        private readonly IUserService _userService;
        public PasswordValidationHandler(IUserService userService) 
        { 
            _userService = userService;
        }
        public async Task<VirtualUser> HandleRegisterRequest(RegisterRequest request)
        {
            string exceptionToThrow = "";
            if (request.Password != request.PasswordConfirm) { exceptionToThrow += "Passwords do not match.\n"; }
            if (request.Password.Length < 8) { exceptionToThrow += "Password is below the miminum length of 8 characters.\n"; }
            if (request.Password.Any(char.IsDigit)) { exceptionToThrow += "Password does not contain a digit.\n"; }
            if (request.Password.Any(char.IsLower)) { exceptionToThrow += "Password does not contain a lowercase letter.\n"; }
            if (request.Password.Any(char.IsUpper)) { exceptionToThrow += "Password does not contain an uppercase letter."; }

            if (exceptionToThrow != "") 
            {
                throw new Exception(exceptionToThrow);
            }
            else
            {
                // pass to PermissionsHandler
                PermissionsHandler permissionsHandler = new PermissionsHandler(_userService);
                return await permissionsHandler.HandleRegisterRequest(request);
            }
        }
    }
}
