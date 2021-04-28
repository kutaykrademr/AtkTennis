﻿
using AtkTennisApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class IdentityPartialClass
    {
        public List<AppIdentityUser> AppIdentityUsers { get; set; } = new List<AppIdentityUser>();
        public List<AppIdentityRole> AppIdentityRoles { get; set; } = new List<AppIdentityRole>();

    }
}