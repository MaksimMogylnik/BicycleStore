using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleStore.Models
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
    }
}