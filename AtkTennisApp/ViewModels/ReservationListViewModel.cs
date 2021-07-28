using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class ReservationListViewModel
    {
        public List<Court> courts { get; set; } = new List<Court>();
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<ReservationCancel> reservationCancels { get; set; } = new List<ReservationCancel>();
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<string> date { get; set; }
        public int debtCount { get; set; }
        public int debtNotCount { get; set; }
        public int cancelResCount { get; set; }
        public int activeResCount { get; set; }
    }
}
