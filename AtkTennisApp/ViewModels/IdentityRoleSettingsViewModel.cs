using AtkTennisApp.Models;
using AtkTennisApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class IdentityRoleSettingsViewModel
    {
        public List<UserSettings>userSettings  { get; set; } = new List<UserSettings>();
        public List<AppIdentityRole> appIdentityRoles { get; set; } = new List<AppIdentityRole>();
    }
}
