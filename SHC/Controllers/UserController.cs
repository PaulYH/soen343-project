using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SHC.Entities;
using SHC.Utilities;
using SHC.Enums;
using SHC.Services;



namespace SHC.Controllers
{
    public class UserController : RegisterRequestHandler
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<VirtualUser> HandleRegisterRequest(RegisterRequest request)
        {
            string exceptionToThrow = "";
            if (request == null) { 
                exceptionToThrow += "request is null.";
                throw new Exception(exceptionToThrow);
            }
            if (request.FirstName == null) { exceptionToThrow += "FirstName is null\n"; }
            if (request.LastName == null) { exceptionToThrow += "LastName is null\n"; }
            if (request.Email == null) { exceptionToThrow += "Email is null\n"; }
            if (request.Password == null) { exceptionToThrow += "Password is null\n"; }
            if (request.PasswordConfirm == null) { exceptionToThrow += "PasswordConfirm is null\n"; }

            if (exceptionToThrow != "") 
            {
                throw new Exception(exceptionToThrow);
            }
            else
            {
                // pass to PasswordValidationHandler
                PasswordValidationHandler passwordValidationHandler = new PasswordValidationHandler(_userService);
                return await passwordValidationHandler.HandleRegisterRequest(request);
            }
        }
    }
}
