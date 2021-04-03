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
                        HttpContext.Session.SetString("UserId", model.UserName);
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
    }
}
