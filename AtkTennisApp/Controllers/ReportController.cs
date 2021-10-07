﻿using AtkTennis.Models;
using AtkTennisApp.Models;
using AtkTennisApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
        }

        public class DuesPaymentInfo
        {
            public Reservation res { get; set; }
            public AllGetPaidLogs paymentLog { get; set; }
            public MemberDuesInfTable dues { get; set; }

        }

        [HttpGet("GetDuesPayment", Name = "GetDuesPayment")]
        public JsonResult GetDuesPayment()
        {
            DuesInf duesInf = new DuesInf();

            duesInf.duesInf = (from paidLogs in db.allGetPaidLogs
                               join dues in db.memberDuesInfTables on paidLogs.RefId equals dues.MemberDuesInfTableId
                               where paidLogs.RefType == 2
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

        [HttpGet("GetCabinetPayment", Name = "GetCabinetPayment")]
        public JsonResult GetCabinetPayment()
        {
            DuesInf duesInf = new DuesInf();

            duesInf.duesInf = (from paidLogs in db.allGetPaidLogs
                               join dues in db.memberDuesInfTables on paidLogs.RefId equals dues.MemberDuesInfTableId
                               where paidLogs.RefType == 3
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
    }
}