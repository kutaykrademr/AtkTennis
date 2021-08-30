using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class GetMemberDetailViewModel
    {
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<ReservationCancel> reservationCancels { get; set; } = new List<ReservationCancel>();
        public List<CabinetOperations> cabinetOperations { get; set; } = new List<CabinetOperations>();
        public List<CabinetType> cabinetTypes { get; set; } = new List<CabinetType>();
        public List<CabinetListUser> cabinetListUsers { get; set; } = new List<CabinetListUser>();

        public MemberList memberLists { get; set; } = new MemberList();
        public int totalPrice {get ;set;}
    }
}
