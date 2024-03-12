using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SHC.Entities;
using SHC.Utilities;
using SHC.Enums;
using SHC.Services;
using Microsoft.EntityFrameworkCore;
using SHC.Data;



namespace SHC.Controllers
{
    public class UserController : RegisterRequestHandler
    {
        //private readonly IUserService _userService;

        public UserController()
        {
            //_userService = userService;
        }
        public async Task<VirtualUser> HandleRegisterRequest(RegisterRequest request)
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
                throw new ArgumentNullException(exceptionToThrow);
            }
            else
            {
                // pass to PasswordValidationHandler
                PasswordValidationHandler passwordValidationHandler = new PasswordValidationHandler();
                return await passwordValidationHandler.HandleRegisterRequest(request);
            }
        }
        //public async Task<VirtualUser> Login(LoginRequest request)
        //{
        //    if (request == null)
        //    {
        //        throw new ArgumentNullException("request is null");
        //    }
        //    if (request == null) { throw new ArgumentNullException("request is null."); }
        //    if (request.Email == null) { throw new ArgumentNullException("Email is null\n"); }
        //    if (request.Password == null) { throw new ArgumentNullException("Password is null\n"); }

        //    return await .Login(request);
        //}

    }
}
