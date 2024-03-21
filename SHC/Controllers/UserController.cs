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
            if (request == null) { return "request is null."; }
            if (request.FirstName == null || request.FirstName == "") { exceptionToThrow += "FirstName is null\n"; }
            if (request.LastName == null || request.LastName == "") { exceptionToThrow += "LastName is null\n"; }
            if (request.Email == null || request.Email == "") { exceptionToThrow += "Email is null\n"; }
            if (request.Password == null || request.Password == "") { exceptionToThrow += "Password is null\n"; }
            if (request.PasswordConfirm == null || request.PasswordConfirm == "") { exceptionToThrow += "PasswordConfirm is null\n"; }

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
            if (request.Email == null || request.Email == "") { error += "Email is null\n"; }
            if (request.Password == null || request.Password == "") { error += "Password is null\n"; }

            if (error != "") { return (error, null); } else { return await _userService.Login(request); }
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userService.DeleteUser(id);
        }

        public async Task<VirtualUser?> EditUser(VirtualUser user)
        {
            if (user == null) { return null; }
            return await _userService.EditUser(user);
        }

        public async Task<IEnumerable<VirtualUser>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

    }
}