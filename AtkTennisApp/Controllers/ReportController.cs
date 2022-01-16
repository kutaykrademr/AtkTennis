using AtkTennis.Models;
using AtkTennisApp.Models;
using AtkTennisApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : Controller
    {

        Context db = new Context();

        public class DuesInf
        {
            public List<MemberList> memberLists { get; set; } = new List<MemberList>();
            public List<DuesPaymentInfo> duesInf { get; set; } = new List<DuesPaymentInfo>();
            public List<Reservation> res { get; set; } = new List<Reservation>();
            public List<ReservationCancel> resCan { get; set; } = new List<ReservationCancel>();
           
        }

        public class DuesPaymentInfo
        {
            public Reservation res { get; set; }
            public AllGetPaidLogs paymentLog { get; set; }
            public MemberDuesInfTable dues { get; set; }

        }

        [HttpGet("GetDuesPayment", Name = "GetDuesPayment")]
        public JsonResult GetDuesPayment(int id)
        {
            DuesInf duesInf = new DuesInf();

            duesInf.duesInf = (from paidLogs in db.allGetPaidLogs
                               join dues in db.memberDuesInfTables on paidLogs.RefId equals dues.MemberDuesInfTableId
                               where paidLogs.RefType == 2 && paidLogs.RefId == id
                               select new DuesPaymentInfo
                               {
                                   paymentLog = paidLogs,
                                   dues = dues

                               }).OrderByDescending(x => x.paymentLog.UserId).ThenBy(x => x.paymentLog.RefId).ThenBy(x => x.paymentLog.Date).ToList();

            duesInf.memberLists = db.memberLists.ToList();

            return Json(duesInf);
        }

        [HttpGet("MemberDuesDebtList", Name = "MemberDuesDebtList")]
        public List<MemberDuesInfTable> MemberDuesDebtList()
        {
            List<MemberDuesInfTable> duesInfTables = new List<MemberDuesInfTable>();

            duesInfTables = db.memberDuesInfTables.OrderBy(x => x.MemberId).ToList();

            return duesInfTables;
        }

        [HttpGet("BalanceOperationReports", Name = "BalanceOperationReports")]
        public BalanceOpViewModel BalanceOpModels()
        {
            BalanceOpViewModel blcOP = new BalanceOpViewModel();

            blcOP.balanceOpModels = db.balanceOpModels.ToList();
            blcOP.memberLists = db.memberLists.ToList();

            return blcOP;
        }

        [HttpGet("GetCabinetPayment", Name = "GetCabinetPayment")]
        public JsonResult GetCabinetPayment(int id)
        {
            DuesInf duesInf = new DuesInf();

            duesInf.duesInf = (from paidLogs in db.allGetPaidLogs
                               join dues in db.memberDuesInfTables on paidLogs.RefId equals dues.MemberDuesInfTableId
                               where paidLogs.RefType == 3 && paidLogs.RefId == id
                               select new DuesPaymentInfo
                               {
                                   paymentLog = paidLogs,
                                   dues = dues

                               }).OrderByDescending(x => x.paymentLog.RefId).ThenBy(x => x.paymentLog.UserId).ThenBy(x => x.paymentLog.Date).ToList();

            duesInf.memberLists = db.memberLists.ToList();

            return Json(duesInf);
        }

        [HttpGet("GetResPayment", Name = "GetResPayment")]
        public JsonResult GetResPayment()
        {
            DuesInf duesInf = new DuesInf();

            duesInf.duesInf = (from paidLogs in db.allGetPaidLogs
                               join res in db.reservations on paidLogs.RefId equals res.ResId
                               where paidLogs.RefType == 1
                               select new DuesPaymentInfo
                               {
                                   paymentLog = paidLogs,
                                   res = res

                               }).OrderByDescending(x => x.paymentLog.RefId).ThenBy(x => x.paymentLog.UserId).ThenBy(x => x.paymentLog.Date).ToList();

            duesInf.memberLists = db.memberLists.ToList();

            return Json(duesInf);
        }

        public class ResandCancelList
        {
            public List<Reservation> reservation { get; set; } = new List<Reservation>();
            public List<ReservationCancel> reservationCancel { get; set; } = new List<ReservationCancel>();
            public List<MemberList> memberLists { get; set; } = new List<MemberList>();
            public List<Court> courts { get; set; } = new List<Court>();
        }

        [HttpGet("MemberReservationDebtList", Name = "MemberReservationDebtList")]
        public ResandCancelList MemberReservationDebtList()
        {
            ResandCancelList model = new ResandCancelList();

            model.reservation = db.reservations.OrderBy(x => x.UserId).ToList();
            model.reservationCancel = db.reservationCancels.OrderBy(x => x.UserId).ToList();
            model.memberLists = db.memberLists.ToList();
            model.courts = db.courts.ToList();

            return model;
        }

        public class CourtOccupancy
        {
            public List<Reservation> myAL { get; set; } = new List<Reservation>();
            public List<Court> court { get; set; } = new List<Court>();
        }

        [HttpGet("GetResOccupancy", Name = "GetResOccupancy")]
        public CourtOccupancy GetResOccupancy(string firstDate, string secDate)
        {
            List<Reservation> res = new List<Reservation>();
            CourtOccupancy model = new CourtOccupancy();

            model.court = db.courts.ToList();

            DateTime startDate = Convert.ToDateTime(firstDate);
            DateTime finishDate = Convert.ToDateTime(secDate);

            List<string> allDates = new List<string>();
            ArrayList myAL = new ArrayList();

            for (var date = startDate; date <= finishDate; date = date.AddDays(1))
            {

                allDates.Add(date.ToString("yyyy-MM-dd"));
            }
            for (int i = 0; i < allDates.Count(); i++)
            {
                res = db.reservations.Where(x => x.ResDate == allDates[i]).ToList();

                if (res.Count != 0)
                {
                    model.myAL.AddRange(res);
                }

            }
            try
            {

            }
            catch (Exception e)
            {

            }

            return model;
        }
    }
}
