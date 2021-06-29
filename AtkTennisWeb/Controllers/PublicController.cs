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

                    }
                }
                else
                {
                    return Json("false");
                }
            }
            catch (Exception)
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
                model = Helpers.Serializers.DeserializeJson<ReservationViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetRes?date="+ date));

                if (model == null)

                    model = new ReservationViewDto();
            }
            catch (Exception)
            {
                model = new ReservationViewDto();
            }

            return View(model);
        }

        public JsonResult GetResTime(string courtInf, string dateInf, int timeMin)
        {
            List<court_reserved> model = new List<court_reserved>();
            try

            {
                model = Helpers.Serializers.DeserializeJson<List<court_reserved>>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetResTime?courtInf=" + courtInf + "&dateInf=" + dateInf + "&timeMin=" + timeMin));

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
                model = Helpers.Serializers.DeserializeJson<ReservationViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/NewReservation?UserId=" + res.UserId + "&CourtId=" + res.CourtId + "&ResDate=" + res.ResDate + "&ResTime=" + res.ResTime + "&ResStartTime=" + res.ResStartTime + "&ResFinishTime=" + res.ResFinishTime + "&ResEvent=" + res.ResEvent));

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

        public JsonResult ChangeCurrentUserPass(string id, string currentPass, string newPass)
        {
            MemberListDto model = new MemberListDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/ChangeCurrentUserPass?id=" + id + "&currentPass=" + currentPass + "&newPass=" + newPass));


            }
            catch (Exception)
            {
                return Json(new ReservationViewDto());
            }

            return Json(true);


        }

    }
    

    public class court_reserved
    {
        public int timeId { get; set; }
        public string start { get; set; }
        public bool isTaken { get; set; }
    }
}

