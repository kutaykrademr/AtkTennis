using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class AddDuesViewModel
    {
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public MemberDuesInfTable memberDuesInfTable { get; set; } = new MemberDuesInfTable();
        public List<CabinetListUser> cabinetListUsers { get; set; } = new List<CabinetListUser>();
        public List<CabinetType> cabinetTypes { get; set; } = new List<CabinetType>();
        public List<MemberDuesInfTable> memberDuesInfs { get; set; } = new List<MemberDuesInfTable>();
        public List<MemberDuesType> memberDuesTypes { get; set; } = new List<MemberDuesType>();
    }
}
