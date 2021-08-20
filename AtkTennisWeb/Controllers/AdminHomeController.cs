﻿using AtkTennisWeb.Models;
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
    public class AdminHomeController : Controller
    {

        public IActionResult Index(string date)
        {

            HomeModelDto model = new HomeModelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<HomeModelDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetHome?date=" +date));
                if(model == null)
                    model = new HomeModelDto();
            }
            catch (Exception)
            {
                model = new HomeModelDto();
            }
            ViewBag.date = date;
            return View(model);
        }

        public IActionResult NewRegister()
        {

            List<AppIdentityRoleDto> model = new List<AppIdentityRoleDto>();

            try
            {
                model = Helpers.Serializers.DeserializeJson<List<AppIdentityRoleDto>>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetRole"));

                if (model == null)

                    model = new List<AppIdentityRoleDto>();
            }
            catch (Exception)
            {
                model = new List<AppIdentityRoleDto>();
            }
            return View(model);
        }

        public IActionResult RegisterMember()
        {

            List<AppIdentityRoleDto> model = new List<AppIdentityRoleDto>();

            try
            {
                model = Helpers.Serializers.DeserializeJson<List<AppIdentityRoleDto>>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetRole"));

                if (model == null)

                    model = new List<AppIdentityRoleDto>();
            }
            catch (Exception)
            {
                model = new List<AppIdentityRoleDto>();
            }
            return View(model);
        }

        public JsonResult Register(string name,string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation , string phoneExp, string phone2, string phone2Exp , string email, string emailExp, string birthPlace, string motherName, string fatherName , string city, string district , string job , string note, string phone, string password, string birthdate, string gender, string role , string nickName , int memberNumber)
        {
            AppIdentityUserDto model = new AppIdentityUserDto();
            try
            {
                 model = Helpers.Serializers.DeserializeJson<AppIdentityUserDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/NewRegister?name=" + name + "&username=" + username + "&phone=" + phone + "&password=" + password + "&birthdate=" + birthdate + "&gender=" + gender + "&email=" + email + "&role=" + role + 
                     "&startDate=" + startDate + "&finishDate=" + finishDate + "&condition=" + condition + "&identificationNumber=" + identificationNumber + "&webReservation=" + webReservation + 
                     "&phoneExp=" + phoneExp + "&phone2=" + phone2 + "&phone2Exp=" + phone2Exp + "&emailExp=" + emailExp + "&birthPlace=" + birthPlace + "&motherName=" + motherName + "&fatherName=" + fatherName + "&city=" + city + "&district=" + district + "&job=" + job + "&note=" + note + "&nickName=" + nickName + "&memberNumber=" + memberNumber));

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
                model = Helpers.Serializers.DeserializeJson<IdentityPartialViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetUser"));

                if (model == null)

                    model = new IdentityPartialViewDto();
            }
            catch (Exception)
            {
                model = new IdentityPartialViewDto();
            }
            return View(model);
        }

        public IActionResult ListMember()
        {

            IdentityPartialViewDto model = new IdentityPartialViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<IdentityPartialViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetMember"));

                if (model == null)

                    model = new IdentityPartialViewDto();
            }
            catch (Exception)
            {
                model = new IdentityPartialViewDto();
            }
            return View(model);
        }

        public JsonResult NewReservationAdmin(ReservationDto res)
        {
            var model = new ReservationViewDto();
            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/NewReservationAdmin?UserId=" + res.UserId + "&CourtId=" + res.CourtId + "&ResDate=" + res.ResDate + "&ResTime=" + res.ResTime + "&ResStartTime=" + res.ResStartTime + "&ResFinishTime=" + res.ResFinishTime + "&ResEvent=" + res.ResEvent + "&ResNowDate=" + res.ResNowDate + "&Price=" + res.Price + "&PriceIds=" + res.PriceIds + "&UserName=" + res.UserName + "&PrivRes=" + res.PrivRes));

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

        public JsonResult GetResUpdTime(int courtId, string dateInf , int resId)
        {
            List<court_reserved> model = new List<court_reserved>();
            try

            {
                model = Helpers.Serializers.DeserializeJson<List<court_reserved>>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetResTimeUpd?courtId=" + courtId + "&dateInf=" + dateInf + "&resId=" + resId));

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

        public JsonResult CancelResAdmin(int id, string userId, bool procedure, string cancelReasons)
        {
            ReservationCourtViewDto model = new ReservationCourtViewDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationCourtViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/CancelResAdmin?id=" + id + "&userId=" + userId + "&procedure=" + procedure + "&cancelReasons=" + cancelReasons));

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

        public JsonResult GetUpdateResAdmin(int id)
        {
            ReservationCourtViewDto model = new ReservationCourtViewDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationCourtViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetUpdateResAdmin?id=" + id ));

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
                return Json(new ReservationCourtViewDto());
            }

        }

        public JsonResult UpdateResAdmin(int id , string startTime , string finishTime , string time , int cId)
        {
            ReservationCourtViewDto model = new ReservationCourtViewDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationCourtViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/UpdateResAdmin?id=" + id + "&startTime=" + startTime + "&finishTime=" + finishTime + "&time=" + time + "&cId=" + cId));

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
                return Json(new ReservationCourtViewDto());
            }

        }


        public JsonResult CancelResProcedureModal(int id)
        {


            ResModalViewDto model = new ResModalViewDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<ResModalViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/cancelResProcedureModal?id=" + id));

                if (model == null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(model);
                }
            }
            catch (Exception)
            {
                return Json(new ResModalViewDto());
            }

        }

        public JsonResult GetMemberList(string id)
        {
            MemberListDto model = new MemberListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetMemberListInf?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new MemberListDto());
            }

            return Json(model);

        }

        public JsonResult GetResSchemaDetail(string date)
        {
            ResSchemaViewDto model = new ResSchemaViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ResSchemaViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetResSchemaDetail?date=" + date));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new ResSchemaViewDto());
            }

            return Json(model);

        }

        public JsonResult UpdateMemberList(string id, string name, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role , string checkpass)
        {
            AppIdentityRoleDto model = new AppIdentityRoleDto();
            try
            {
               model =   Helpers.Serializers.DeserializeJson<AppIdentityRoleDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/UpdateMemberList?name=" + name + "&username=" + username + "&id=" + id + "&phone=" + phone + "&password=" + password + "&birthdate=" + birthdate + "&gender=" + gender + "&email=" + email + "&role=" + role +
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
                model = Helpers.Serializers.DeserializeJson<AppIdentityUserDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/DeleteUser?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new AppIdentityUserDto());
            }

            return Json(true);

        }

        public JsonResult AddPrice(int id, int money)
        {
            MemberListDto model = new MemberListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/AddPrice?id=" + id + "&money=" + money));

                if (model != null)

                    return Json(true);
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                return Json(new ToDoListDto());
            }

        }

        public JsonResult AddToDo(string toDo , string today)
        {
            ToDoListDto model = new ToDoListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ToDoListDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/AddToDo?toDo=" + toDo + "&today=" + today));

                if (model != null)

                    return Json(true);
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                return Json(new ToDoListDto());
            }

        }

        public JsonResult ControlNickName(string nickName)
        {
            MemberListDto model = new MemberListDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/ControlNickName?nickName=" + nickName));

                if (model == null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                return Json(new MemberListDto());
            }

        }

        public JsonResult ControlUserName(string userName)
        {
            MemberListDto model = new MemberListDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/ControlUserName?userName=" + userName));

                if (model == null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                return Json(new MemberListDto());
            }

        }

        public JsonResult ControlMemberNumber(string memberNumber)
        {
            MemberListDto model = new MemberListDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/ControlMemberNumber?memberNumber=" + memberNumber));

                if (model == null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                return Json(new MemberListDto());
            }

        }

    }


}
