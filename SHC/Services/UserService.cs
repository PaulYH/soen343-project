using SHC.Entities;
using SHC.Utilities;
using SHC.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SHC.Services
{
    public class UserService : IUserService, RegisterRequestHandler
    {
        private readonly SHSDbContext _context;

        public UserService(SHSDbContext context)
        {
            _context = context;
        }
        public async Task<string> HandleRegisterRequest(RegisterRequest request)
        {
            VirtualUser user = new VirtualUser();
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.UserType = request.UserType;
            user.Password = request.Password;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User Creation Successful!";
        }
        public async Task<(string, VirtualUser?)> Login(LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);
            if (user == null) { return ("Invalid email or password", null); } else { return ("Login Successful", user); }
        }

        public async Task<IEnumerable<VirtualUser>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

    }
}
