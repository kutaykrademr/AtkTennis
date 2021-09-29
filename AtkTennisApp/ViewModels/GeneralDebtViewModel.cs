using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class GeneralDebtViewModel
    {
        public List<MemberDebtType> memberDebtTypes { get; set; } = new List<MemberDebtType>();
        public List<MemberDuesInfTable> memberDuesInfTables { get; set; } = new List<MemberDuesInfTable>();
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<CabinetListUser> cabinetListUsers { get; set; } = new List<CabinetListUser>();
        
    }
}
