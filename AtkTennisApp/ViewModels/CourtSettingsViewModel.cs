using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class CourtSettingsViewModel
    {
        public List<Court> Courts { get; set; } = new List<Court>();
        public List<CourtPriceList> courtPriceLists { get; set; } = new List<CourtPriceList>();
        public List<ResTime> resTimes { get; set; } = new List<ResTime>();
        public List<CourtRecipeType> courtRecipeTypes { get; set; } = new List<CourtRecipeType>();
        public List<CourtScaleList> courtScales { get; set; } = new List<CourtScaleList>();
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<PerformanceType> performanceTypes { get; set; } = new List<PerformanceType>();
        public List<SchoolType> schoolTypes { get; set; } = new List<SchoolType>();
    }
}
