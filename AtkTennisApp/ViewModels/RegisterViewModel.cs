using AtkTennisApp.Models;
using AtkTennisApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AtkTennisApp.ViewModels
{
    public class RegisterViewModel
    {
        public Register Registers { get; set; } = new Register();
        public AppIdentityUser AppIdentityUsers { get; set; } = new AppIdentityUser();
        

    }
}

