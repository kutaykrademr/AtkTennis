
using AtkTennisApp.Models;
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
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<Court> courts { get; set; } = new List<Court>();
        public List<Reservation> reservations { get; set; } = new List<Reservation>();

    }
}
