using SHC.Entities;
using SHC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Services
{
    public interface IUserService
    {
        Task<string> HandleRegisterRequest(RegisterRequest request);
        Task<string> Login(LoginRequest request);


    }
}
