using AtkTennisWeb.Models;
using AtkTennisWeb.Providers;
using Helpers.Dto;
using Helpers.Dto.ViewDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisWeb.Controllers
{
    [AuthorizeUser]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            HomeModelDto model = new HomeModelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<HomeModelDto>(Helpers.Request.Get(Mutuals.AppUrl + "Home/GetHome"));
                if(model == null)
                    model = new HomeModelDto();
            }
            catch (Exception)
            {
                model = new HomeModelDto();
            }
            return View(model);
        }



        public IActionResult NewRegister()
        {

            List<AppIdentityRoleDto> model = new List<AppIdentityRoleDto>();

            try
            {
                model = Helpers.Serializers.DeserializeJson<List<AppIdentityRoleDto>>(Helpers.Request.Get(Mutuals.AppUrl + "Home/GetRole"));

                if (model == null)

                    model = new List<AppIdentityRoleDto>();
            }
            catch (Exception)
            {
                model = new List<AppIdentityRoleDto>();
            }
            return View(model);
        }



        public JsonResult Register(string name,string username, string phone, string password, string birthdate, string gender, string email, string role)
        {
            AppIdentityUserDto model = new AppIdentityUserDto();
            try
            {
                 model = Helpers.Serializers.DeserializeJson<AppIdentityUserDto>(Helpers.Request.Get(Mutuals.AppUrl + "Home/NewRegister?name=" + name + "&username=" + username + "&phone=" + phone + "&password=" + password + "&birthdate=" + birthdate + "&gender=" + gender + "&email=" + email + "&role=" + role));

                if (model == null)
                    model = new AppIdentityUserDto();
            }
            catch (Exception)
            {
                return Json(new AppIdentityUserDto());
            }

            return Json(model);
        }
    }
}
