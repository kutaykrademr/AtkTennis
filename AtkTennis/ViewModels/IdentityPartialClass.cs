using AtkTennis.Models;
using AtkTennis.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennis.ViewModels
{
    public class IdentityPartialClass
    {
        public List<AppIdentityUser> AppIdentityUsers { get; set; } = new List<AppIdentityUser>();
        public List<AppIdentityRole> AppIdentityRoles { get; set; } = new List<AppIdentityRole>();
        public List<Register> Registers { get; set; } = new List<Register>();
    }
}
