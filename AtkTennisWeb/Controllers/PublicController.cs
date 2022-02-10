using AtkTennisWeb.Providers;
using Helpers.Dto;
using Helpers.Dto.PartialViewDtos;
using Helpers.Dto.ViewDtos;
using Microsoft.AspNetCore.Authorization;
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
        public JsonResult GetRoles(string UserName, string Password)
        {
            SignInDto model = new SignInDto();
            try
            {
                var url = Mutuals.AppUrl + "Public/GetRoles?Username=" + UserName + "&Password=" + Password ;

                model = Helpers.Serializers.DeserializeJson<Helpers.Dto.SignInDto>(Helpers.Request.Get(url));

                if (model.custom_role == null)
                {
                    return Json("false");
                }
                else if (model.custom_role.Count > 0)
                {
                    return Json(model);
                }
                else
                
                    return Json("false");
                
              
            }
            catch (Exception ex)
            {
                return Json("false");
            }

            return Json("true");
        }

        [HttpGet]
        public JsonResult SignInReq(string UserName, string Password , string RoleName, string RoleId)
        {

            try
            {
                var url = Mutuals.AppUrl + "Public/SignIn?Username=" + UserName + "&Password=" + Password + "&RoleName=" + RoleName + "&RoleId=" + RoleId;

                var model = Helpers.Serializers.DeserializeJson<Helpers.Dto.SignInDto>(Helpers.Request.Get(url));

                if (model != null)
                {
                    if (model.UserName == null || model.Password == null)

                        return Json("false");

                    else
                    {
                        HttpContext.Session.SetString("UserName", model.UserName);
                        HttpContext.Session.SetString("UserId", model.custom_userid);

                        if (model.custom_nickName == null || model.custom_name == null)
                        {
                            HttpContext.Session.SetString("FullName", "Sistem Kurulum");
                            HttpContext.Session.SetString("NickName", "SS");
                        }
                        else
                        {
                            HttpContext.Session.SetString("FullName", model.custom_name);
                            HttpContext.Session.SetString("NickName", model.custom_nickName);
                        }
                       
                        HttpContext.Session.SetString("Role", model.custom_role[0]);
                        HttpContext.Session.SetString("RoleId", model.custom_roleId[0]);
                        HttpContext.Session.SetString("CompId", model.comp_Id);

                        return Json(model);
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

        public IActionResult GetMemberDebt(string userId)
        {

            List<MemberDuesInfTableDto> model = new List<MemberDuesInfTableDto>();
            try
            {
                model = Helpers.Serializers.DeserializeJson<List<MemberDuesInfTableDto>>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetMemberDebt?userId=" + userId));

                if (model == null)

                    model = new List<MemberDuesInfTableDto>();
            }
            catch (Exception)
            {
                model = new List<MemberDuesInfTableDto>();
            }

            return View(model);
        }

        public JsonResult GetMem(string id)
        {

            MemberListDto model = new MemberListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetMem?id=" + id));

                if (model == null)

                    model = new MemberListDto();
            }
            catch (Exception)
            {
                model = new MemberListDto();
            }

            return Json(model);
        }


        public IActionResult GetCabinetDebt(string userId)
        {

            CabinetViewDto model = new CabinetViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CabinetViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetCabinetDebt?userId=" + userId));

                if (model == null)

                    model = new CabinetViewDto();
            }
            catch (Exception)
            {
                model = new CabinetViewDto();
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

        public JsonResult UserList()
        {

            IdentityPartialViewDto model = new IdentityPartialViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<IdentityPartialViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetUsers"));

                if (model == null)

                    model = new IdentityPartialViewDto();
            }
            catch (Exception)
            {
                model = new IdentityPartialViewDto();
            }
            return Json(model);
        }

        public JsonResult GetResList2(string date , string userId)
        {

            List<ReservationDto> model = new List<ReservationDto>();

            try
            {
                model = Helpers.Serializers.DeserializeJson<List<ReservationDto>>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetResList2?date=" + date + "&userId=" + userId));

                if (model == null)

                    model = new List<ReservationDto>();
            }
            catch (Exception)
            {
                model = new List<ReservationDto>();
            }
            return Json(model);
        }

        public IActionResult Error403()
        {

       
            return View();
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

             userId = userId.Trim();

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

        public class CourtPriceListViewModel
        {
            public List<CourtPriceListDto> courtPriceLists { get; set; } = new List<CourtPriceListDto>();
            public List<CourtPriceListDto> priceLists { get; set; } = new List<CourtPriceListDto>();
            public List<string> priceListsId { get; set; } = new List<string>();

        }


        public JsonResult GetListPrice(int id, string day, string month, string time)
        {
            CourtPriceListViewModel model = new CourtPriceListViewModel();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtPriceListViewModel>(Helpers.Request.Get(Mutuals.AppUrl + "Public/GetListPrice?id=" + id + "&day=" + day + "&month=" + month + "&time=" + time));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtPriceListViewModel());
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
                model = Helpers.Serializers.DeserializeJson<ReservationViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/NewReservation?UserId=" + res.UserId + "&CourtId=" + res.CourtId + "&CompanyId=" + res.CompanyId + "&ResDate=" + res.ResDate + "&ResTime=" + res.ResTime + "&ResStartTime=" + res.ResStartTime + "&ResFinishTime=" + res.ResFinishTime + "&ResEvent=" + res.ResEvent + "&ResNowDate=" + res.ResNowDate + "&Price=" + res.Price + "&PriceIds=" + res.PriceIds + "&RoleName=" + res.RoleName + "&RoleId=" + res.RoleId ));

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

        public JsonResult CancelRes(int id , string userId , bool procedure , string cancelReasons , string compId)
        {
            ReservationDto model = new ReservationDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/CancelRes?id=" + id + "&userId=" + userId + "&procedure=" + procedure + "&cancelReasons=" + "Üye Kararı" + "&compId=" + compId));

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

        public JsonResult CancelResProcedure(int id)
        {
            ReservationDto model = new ReservationDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/CancelResProcedure?id=" + id ));

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

        public JsonResult AddMemberBalance(int price)
        {
            MemberListDto model = new MemberListDto();

            try

            {
               var id = HttpContext.Session.GetString("UserId");

                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/AddMemberBalance?id=" + id + "&price=" + price));

                if (model != null)
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
                return Json(new ResSchemaModalDto());
            }

        }



        public JsonResult ChangeCurrentUserPass(string id, string currentPass, string newPass , int checkPrivacy)
        {
            MemberListDto model = new MemberListDto();

            try

            {
                model = Helpers.Serializers.DeserializeJson<MemberListDto>(Helpers.Request.Get(Mutuals.AppUrl + "Public/ChangeCurrentUserPass?id=" + id + "&currentPass=" + currentPass + "&newPass=" + newPass + "&checkPrivacy=" + checkPrivacy));

                if (model == null)
                {
                    return Json(false);
                }

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
                HttpContext.Session.Clear();
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
        public double Period { get; set; }
        public string start { get; set; }
        public bool isTaken { get; set; }
    }
}

