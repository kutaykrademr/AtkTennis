using Helpers.Dto.PartialViewDtos;
using Helpers.Dto.ViewDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisWeb.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult DebtReports()
        {
            return View();
        }

        public class DuesPaymentInfoDto
        {
            public AllGetPaidLogsDto paymentLog { get; set; }
            public MemberDuesInfTableDto dues { get; set; }
            public ReservationDto res { get; set; }
        }

        public class DuesInfDto
        {
            public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
            public List<DuesPaymentInfoDto> duesInf { get; set; } = new List<DuesPaymentInfoDto>();
            public List<ReservationDto> res { get; set; } = new List<ReservationDto>();
        }

        public JsonResult GetDuesPayment()
        {

            DuesInfDto model = new DuesInfDto();
            try
            {
                var asd = Helpers.Request.Get(Mutuals.AppUrl + "Report/GetDuesPayment");
                model = Helpers.Serializers.DeserializeJson<DuesInfDto>(asd);
                if (model == null)
                    model = new DuesInfDto();
            }
            catch (Exception)
            {
                model = new DuesInfDto();
            }

            return Json(model);
        }

        public JsonResult MemberDuesDebtList()
        {
            List<MemberDuesInfTableDto> model = new List<MemberDuesInfTableDto>();
            try
            {
                var asd = Helpers.Request.Get(Mutuals.AppUrl + "Report/MemberDuesDebtList");
                model = Helpers.Serializers.DeserializeJson<List<MemberDuesInfTableDto>>(asd);

                if (model == null)
                    model = new List<MemberDuesInfTableDto>();
            }
            catch (Exception)
            {
                model = new List<MemberDuesInfTableDto>();
            }

            return Json(model);
        }

        public JsonResult GetCabinetPayment()
        {

            DuesInfDto model = new DuesInfDto();
            try
            {
                var asd = Helpers.Request.Get(Mutuals.AppUrl + "Report/GetCabinetPayment");
                model = Helpers.Serializers.DeserializeJson<DuesInfDto>(asd);
                if (model == null)
                    model = new DuesInfDto();
            }
            catch (Exception)
            {
                model = new DuesInfDto();
            }

            return Json(model);
        }

        public JsonResult GetResPayment()
        {

            DuesInfDto model = new DuesInfDto();
            try
            {
                var asd = Helpers.Request.Get(Mutuals.AppUrl + "Report/GetResPayment");
                model = Helpers.Serializers.DeserializeJson<DuesInfDto>(asd);
                if (model == null)
                    model = new DuesInfDto();
            }
            catch (Exception)
            {
                model = new DuesInfDto();
            }

            return Json(model);
        }


        public class ResandCancelListDto
        {
            public List<ReservationDto> reservation { get; set; } = new List<ReservationDto>();
            public List<ReservationCancelDto> reservationCancel { get; set; } = new List<ReservationCancelDto>();
            public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
            public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        }

        public JsonResult MemberReservationDebtList()
        {
            ResandCancelListDto model = new ResandCancelListDto();
            try
            {
                var asd = Helpers.Request.Get(Mutuals.AppUrl + "Report/MemberReservationDebtList");
                model = Helpers.Serializers.DeserializeJson<ResandCancelListDto>(asd);

                if (model == null)
                    model = new ResandCancelListDto();
            }
            catch (Exception)
            {
                model = new ResandCancelListDto();
            }

            return Json(model);
        }
    }
}

