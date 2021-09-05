using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class ResSchemaViewModel
    {
        public List<Court> courts { get; set; } = new List<Court>();
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<CourtScaleList> courtScales { get; set; } = new List<CourtScaleList>();

    }
}
