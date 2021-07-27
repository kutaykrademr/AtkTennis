using Helpers.Dto;
using Helpers.Dto.PartialViewDtos;
using Helpers.Dto.ViewDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisWeb.Controllers
{
    public class PublicController : Controller
    {
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpGet]
        public JsonResult SignInReq(string UserName, string Password)
        {

            try
            {
                var url = Mutuals.AppUrl + "Public/SignIn?Username=" + UserName + "&Password=" + Password;

                var model = Helpers.Serializers.DeserializeJson<Helpers.Dto.SignInDto>(Helpers.Request.Get(url));

                if (model != null)
                {
                    if (model.UserName == null || model.Password == null)

                        return Json("false");

                    else
                    {
                        HttpContext.Session.SetString("UserName", model.UserName);
                        HttpContext.Session.SetString("UserId", model.custom_userid);
                        HttpContext.Session.SetString("FullName", model.custom_name);
                        HttpContext.Session.SetString("Role", model.custom_role);
                        HttpContext.Session.SetString("RoleId", model.custom_roleId);
                        HttpContext.Session.SetString("NickName", model.custom_nickName);

                    }
                }
                else
                {
                    return Json("false");
                }
            }
            catch (Exception ex)
            {
                return Json("false");
            }

            return Json("true");

        }

        public IActionResult Reservation(string date)
        {
            ReservationViewDto model = new ReservationViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetRes?date=" + date));

                if (model == null)

                    model = new ReservationViewDto();
            }
            catch (Exception)
            {
                model = new ReservationViewDto();
            }

            ViewBag.date = date;

            return View(model);
        }

        public IActionResult ReservationList()
        {

            ReservationListViewDto model = new ReservationListViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationListViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetResList"));

                if (model == null)

                    model = new ReservationListViewDto();
            }
            catch (Exception)
            {
                model = new ReservationListViewDto();
            }

            return View(model);
        }

        public IActionResult ReservationCancel()
        {
            ReservationListViewDto model = new ReservationListViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationListViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/ReservationCancel"));

                if (model == null)

                    model = new ReservationListViewDto();
            }
            catch (Exception)
            {
                model = new ReservationListViewDto();
            }

            return View(model);
        }

        public IActionResult MemberInf()
        {

            List<MemberListDto> model = new List<MemberListDto>();
            try
            {
                model = Helpers.Serializers.DeserializeJson<List<MemberListDto>>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetMemberInf"));

                if (model == null)

                    model = new List<MemberListDto>();
            }
            catch (Exception)
            {
                model = new List<MemberListDto>();
            }

            return View(model);
        }

        public JsonResult GetUserListModal( string id)
        {

            ReservationListViewDto model = new ReservationListViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationListViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetUserListModal?id=" + id));

                if (model == null)

                    model = new ReservationListViewDto();
            }
            catch (Exception)
            {
                model = new ReservationListViewDto();
            }

            return Json(model);
        }

        public JsonResult GetPaymentOperations(int resId, string userId)
        {

            ReservationListViewDto model = new ReservationListViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationListViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetPaymentOperations?resId=" + resId + "&userId=" + userId));

                if (model == null)

                    model = new ReservationListViewDto();
            }
            catch (Exception)
            {
                model = new ReservationListViewDto();
            }

            return Json(model);
        }
        public JsonResult PaymentOperations(int resId, string userId)
        {

            ReservationListViewDto model = new ReservationListViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationListViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/PaymentOperations?resId=" + resId + "&userId=" + userId));

                if (model == null)

                    model = new ReservationListViewDto();
            }
            catch (Exception)
            {
                model = new ReservationListViewDto();
            }

            return Json(model);
        }



        public JsonResult GetResTime(int courtId, string dateInf)
        {
            List<court_reserved> model = new List<court_reserved>();
            try

            {
                model = Helpers.Serializers.DeserializeJson<List<court_reserved>>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetResTime?courtId=" + courtId + "&dateInf=" + dateInf ));

                if (model == null)


                {
                    return Json(false);
                }


            }
            catch (Exception)
            {
                return Json(new ReservationViewDto());
            }

            return Json(model);


        }

        public JsonResult NewReservation(ReservationDto res)
            {
            var model = new ReservationViewDto();
            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/NewReservation?UserId=" + res.UserId + "&CourtId=" + res.CourtId + "&ResDate=" + res.ResDate + "&ResTime=" + res.ResTime + "&ResStartTime=" + res.ResStartTime + "&ResFinishTime=" + res.ResFinishTime + "&ResEvent=" + res.ResEvent + "&ResNowDate=" + res.ResNowDate + "&Price=" + res.Price + "&PriceIds=" + res.PriceIds));

            }
            catch (Exception)
            {
                return Json(new ReservationViewDto());
            }

            if (model == null)
            {
                return Json(false);
            }

            return Json(true);

        }

        public JsonResult GetResModalInf(int id)
        {
            ResModalViewDto model = new ResModalViewDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<ResModalViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetResModalInf?id=" + id));


            }
            catch (Exception)
            {
                return Json(new ResModalViewDto());
            }

            return Json(model);


        }

        public JsonResult CancelRes(int id , string userId)
        {
            ReservationDto model = new ReservationDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/CancelRes?id=" + id + "&userId=" + userId));

                if (model != null)
                {
                    return Json(model);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                return Json(new ResSchemaModalDto());
            }

        }




        public JsonResult ChangeCurrentUserPass(string id, string currentPass, string newPass)
        {
            MemberListDto model = new MemberListDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/ChangeCurrentUserPass?id=" + id + "&currentPass=" + currentPass + "&newPass=" + newPass));


            }
            catch (Exception)
            {
                return Json(new MemberListDto());
            }

            return Json(true);


        }

        public IActionResult Logout()
        {

            try
                
            {
                Helpers.Request.Get(Mutuals.AppUrl + "Public/Logout");
            }

            catch (Exception)
            {
                
            }

            return RedirectToAction("SignIn", "Public");
        }
    }




    public class court_reserved
    {
        public int timeId { get; set; }
        public string start { get; set; }
        public bool isTaken { get; set; }
    }
}

