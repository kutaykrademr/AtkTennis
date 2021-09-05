using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class MemberSchoolPerViewModel
    {
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<SchoolType> schoolTypes { get; set; } = new List<SchoolType>();
        public List<PerformanceType> performanceTypes { get; set; } = new List<PerformanceType>();
    }
}
