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
    }
}
