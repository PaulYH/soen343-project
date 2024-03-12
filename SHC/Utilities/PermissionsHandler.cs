using SHC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SHC.Services;
using Microsoft.EntityFrameworkCore;
using SHC.Data;

namespace SHC.Utilities
{
    public class PermissionsHandler : RegisterRequestHandler
    {
        IDbContextFactory<UserContext> DbFactory;
        private readonly UserContext userContext;
        public PermissionsHandler() 
        {
            userContext = DbFactory.CreateDbContext();
        }
        public async Task<VirtualUser> HandleRegisterRequest(RegisterRequest request)
        {
            VirtualUser user = new VirtualUser();
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.UserType = request.UserType;

            userContext.Users.Add(user);
            await userContext.SaveChangesAsync();
            return user;


        }
    }
}
