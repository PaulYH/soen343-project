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
        Task<(string, VirtualUser)> Login(LoginRequest request);
        Task<IEnumerable<VirtualUser>> GetAllUsers();
        Task<bool> DeleteUser(int id);
        Task<VirtualUser?> EditUser(VirtualUser updatedUser);

    }
}
