using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class AllPaidLogsViewModel
    {
        public AllGetPaidLogs allGetPaid { get; set; } = new AllGetPaidLogs();
        public Reservation reservation { get; set; } = new Reservation();
        public ReservationCancel reservationCancel { get; set; } = new ReservationCancel();
        public MemberDuesInfTable memberDuesInf { get; set; } = new MemberDuesInfTable();
        public CabinetListUser cabinetListUser { get; set; } = new CabinetListUser();

       
    }
}
