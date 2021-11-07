using AtkTennisApp.Models;
using AtkTennisApp.Security;
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
        public List<MemberDuesInfTable> memberDuesInfs { get; set; } = new List<MemberDuesInfTable>();
        public List<AppIdentityUser> AppIdentityUsers { get; set; } = new List<AppIdentityUser>();
        public List<AppIdentityRole> AppIdentityRoles { get; set; } = new List<AppIdentityRole>();

        public MemberList memberLists { get; set; } = new MemberList();
        public List<MemberList> memberLists2 { get; set; } = new List<MemberList>();
        public int totalPrice {get ;set;}
    }
}
