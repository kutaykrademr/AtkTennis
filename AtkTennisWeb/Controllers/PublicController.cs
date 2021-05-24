using Helpers.Dto.PartialViewDtos;
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

                if(model != null)
                {
                    if (model.UserName == null || model.Password == null)
                        return Json("false");
                    else
                    {
                        HttpContext.Session.SetString("UserName", model.UserName);
                        HttpContext.Session.SetString("UserId", model.custom_userid);

                        var name = HttpContext.Session.GetString("UserName");
                        var id = HttpContext.Session.GetString("UserId");

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

        public IActionResult Reservation()
        {
            ReservationViewDto model = new ReservationViewDto();

            try
            {
                var getResult = Helpers.Request.Get(Mutuals.AppUrl + "Public/GetRes");
                model = Helpers.Serializers.DeserializeJson<ReservationViewDto>(getResult);

                if (model == null)

                    model = new ReservationViewDto();
            }
            catch (Exception)
            {
                model = new ReservationViewDto();
            }

            return View(model);
        }
    }
}
