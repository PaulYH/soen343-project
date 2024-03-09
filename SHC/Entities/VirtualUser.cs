using SHC.Entities.Room;
using SHC.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities
{
    public class VirtualUser
    {
        public int Id { get; set; }
        public UserType UserType { get; set; } = UserType.Guest;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public IRoom? CurrentLocation = null;

    }
}
