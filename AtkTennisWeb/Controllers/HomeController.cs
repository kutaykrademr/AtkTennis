using AtkTennisWeb.Models;
using AtkTennisWeb.Providers;
using Helpers.Dto;
using Helpers.Dto.PartialViewDtos;
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
    
        public JsonResult Register(string name,string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation , string phoneExp, string phone2, string phone2Exp , string email, string emailExp, string birthPlace, string motherName, string fatherName , string city, string district , string job , string note, string phone, string password, string birthdate, string gender, string role)
        {
            AppIdentityUserDto model = new AppIdentityUserDto();
            try
            {
                 model = Helpers.Serializers.DeserializeJson<AppIdentityUserDto>(Helpers.Request.Get(Mutuals.AppUrl + "Home/NewRegister?name=" + name + "&username=" + username + "&phone=" + phone + "&password=" + password + "&birthdate=" + birthdate + "&gender=" + gender + "&email=" + email + "&role=" + role + 
                     "&startDate=" + startDate + "&finishDate=" + finishDate + "&condition=" + condition + "&identificationNumber=" + identificationNumber + "&webReservation=" + webReservation + 
                     "&phoneExp=" + phoneExp + "&phone2=" + phone2 + "&phone2Exp=" + phone2Exp + "&emailExp=" + emailExp + "&birthPlace=" + birthPlace + "&motherName=" + motherName + "&fatherName=" + fatherName + "&city=" + city + "&district=" + district + "&job=" + job + "&note=" + note));

                if (model == null)
                    model = new AppIdentityUserDto();
            }
            catch (Exception)
            {
                return Json(new AppIdentityUserDto());
            }

            return Json(model);


        }

        public IActionResult ListUser()
        {

            IdentityPartialViewDto model = new IdentityPartialViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<IdentityPartialViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Home/GetUser"));

                if (model == null)

                    model = new IdentityPartialViewDto();
            }
            catch (Exception)
            {
                model = new IdentityPartialViewDto();
            }
            return View(model);
        }

        public JsonResult GetMemberList(string id)
        {
            MemberListDto model = new MemberListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "Home/GetMemberListInf?id=" + id));

                if (model.Id == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new MemberListDto());
            }

            return Json(model);

        }

        public JsonResult UpdateMemberList(string id, string name, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role , string checkpass)
        {
            AppIdentityRoleDto model = new AppIdentityRoleDto();
            try
            {
               model =   Helpers.Serializers.DeserializeJson<AppIdentityRoleDto>(Helpers.Request.Get(Mutuals.AppUrl + "Home/UpdateMemberList?name=" + name + "&username=" + username + "&id=" + id + "&phone=" + phone + "&password=" + password + "&birthdate=" + birthdate + "&gender=" + gender + "&email=" + email + "&role=" + role +
                     "&startDate=" + startDate + "&finishDate=" + finishDate + "&condition=" + condition + "&identificationNumber=" + identificationNumber + "&webReservation=" + webReservation +
                     "&phoneExp=" + phoneExp + "&phone2=" + phone2 + "&phone2Exp=" + phone2Exp + "&emailExp=" + emailExp + "&birthPlace=" + birthPlace + "&motherName=" + motherName + "&fatherName=" + fatherName + "&city=" + city + "&district=" + district + "&job=" + job + "&note=" + note + "&checkpass=" + checkpass));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);

        }

        public JsonResult DeleteUser(string id)
        {
            AppIdentityUserDto model = new AppIdentityUserDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AppIdentityUserDto>(Helpers.Request.Get(Mutuals.AppUrl + "Home/DeleteUser?id=" + id));

                if (model != null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new AppIdentityUserDto());
            }

            return Json(true);

        }
    }
}
