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
        public async Task<string> HandleRegisterRequest(RegisterRequest request)
        {
            string exceptionToThrow = "";
            if (request == null) { throw new ArgumentNullException("request is null."); }
            if (request.FirstName == null) { exceptionToThrow += "FirstName is null\n"; }
            if (request.LastName == null) { exceptionToThrow += "LastName is null\n"; }
            if (request.Email == null) { exceptionToThrow += "Email is null\n"; }
            if (request.Password == null) { exceptionToThrow += "Password is null\n"; }
            if (request.PasswordConfirm == null) { exceptionToThrow += "PasswordConfirm is null\n"; }

            if (exceptionToThrow != "")
            {
                //throw new ArgumentNullException(exceptionToThrow);
                return "Invalid request: \n" + exceptionToThrow;
            }
            else
            {
                // pass to PasswordValidationHandler
                PasswordValidationHandler passwordValidationHandler = new PasswordValidationHandler(_userService);
                return await passwordValidationHandler.HandleRegisterRequest(request);
            }
        }
        public async Task<(string, VirtualUser?)> Login(LoginRequest request)
        {
            string error = "";
            if (request == null) { error += "request is null.\n"; return (error, null); }
            if (request.Email == null) { error += "Email is null\n"; }
            if (request.Password == null) { error += "Password is null\n"; }

            if (error != "") { return (error, null); } else { return await _userService.Login(request); }

        }
    }
}