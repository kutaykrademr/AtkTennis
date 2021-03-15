using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtkTennis.Models;
using AtkTennis.Security;

namespace AtkTennis.ViewModels
{
    public class RegisterViewModel
    {
        public Register Registers { get; set; } = new Register();
        public List<AppIdentityRole> AppIdentityRoles { get; set; } = new List<AppIdentityRole>();

    }
}

