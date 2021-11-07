using AtkTennisApp.Models;
using AtkTennisApp.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class ReservationViewModel
    {
        public List<Court> courts { get; set; } = new List<Court>();
        public List<CourtPriceList> courtPriceLists { get; set; } = new List<CourtPriceList>();
        public List<ResTime> resTimes { get; set; } = new List<ResTime>();
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<ReservationCancel> reservationCancels { get; set; } = new List<ReservationCancel>();
        public List<ReservationSettings> reservationSettings { get; set; } = new List<ReservationSettings>();
        public List<MemberList> memberLists { get; set; } = new List<MemberList>();
        public List<CourtScaleList> courtScales { get; set; } = new List<CourtScaleList>();
        public List<MemberDuesInfTable> memberDues { get; set; } = new List<MemberDuesInfTable>();

        public List<Reservation> res { get; set; } = new List<Reservation>();
        public List<ReservationCancel> resCan { get; set; } = new List<ReservationCancel>();
    }
}
