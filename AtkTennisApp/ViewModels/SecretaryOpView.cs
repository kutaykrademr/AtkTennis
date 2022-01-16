using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class SecretaryOpView
    {
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<SecretaryOp> balanceOpModels { get; set; } = new List<SecretaryOp>();
    }
}
