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
            SimulationContext simulationContext = SimulationContext.GetInstance();
            VirtualUser user = new VirtualUser();
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.UserType = request.UserType;
            user.Password = request.Password;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            simulationContext.CurrentUser = user;
            return "User Creation Successful! Please log in to continue.";
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
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if ( user == null ) { return false; }
            else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<VirtualUser?> EditUser(VirtualUser user)
        {
            VirtualUser? newUser = _context.Users.Find(user.Id);
            if (newUser == null) { return null; }
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Email = user.Email;
            await _context.SaveChangesAsync();
            return newUser;
        }

    }
}
