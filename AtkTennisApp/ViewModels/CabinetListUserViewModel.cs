using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class CabinetListUserViewModel
    {
        public List<CabinetListUser> cabinetListUsers { get; set; } = new List<CabinetListUser>();
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
    }
}
