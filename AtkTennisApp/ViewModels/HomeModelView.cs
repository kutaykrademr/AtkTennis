using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class HomeModelView
    {
        public int? TotalUserCount { get; set; }
        public int? TotalRoleCount { get; set; }
        public int? TotalResCount { get; set; }
        public int? TodayResCount { get; set; }
        public List<ToDoList> toDoLists { get; set; } = new List<ToDoList>();
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<Court> courts { get; set; } = new List<Court>();

        public List<CourtPriceList> courtPriceLists { get; set; } = new List<CourtPriceList>();
        public List<ResTime> resTimes { get; set; } = new List<ResTime>();
        public List<ReservationCancel> reservationCancels { get; set; } = new List<ReservationCancel>();
        public List<ReservationSettings> reservationSettings { get; set; } = new List<ReservationSettings>();
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<CourtScaleList> courtScaleLists { get; set; } = new List<CourtScaleList>();
      
    }
}
