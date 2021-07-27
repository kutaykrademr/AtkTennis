﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers.Dto;
using AtkTennisApp.Models;
using AtkTennisApp.Security;
using Microsoft.AspNetCore.Identity;
using AtkTennis.Models;
using AtkTennisApp.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Helpers.Dto.ViewDtos;
using System.Globalization;

namespace AtkTennisApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public PublicController(UserManager<AppIdentityUser> userManager,
            RoleManager<AppIdentityRole> roleManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;

        }

        Context db = new Context();

        [HttpGet("GetMySettings", Name = "GetMySettings")]
        public MutualsConstantsDto GetMySettings()
        {
            MutualsConstantsDto model = new MutualsConstantsDto();

            model.M1 = MutualConstants.M1;
            model.M2 = MutualConstants.M2;
            model.M3 = MutualConstants.M3;
            model.M4 = MutualConstants.M4;
            model.M5 = MutualConstants.M5;
            model.M6 = MutualConstants.M6;
            model.PhotoUrl = MutualConstants.PhotoUrl;
            model.SunucuIp = MutualConstants.SunucuIp;
            model.CompanyName = MutualConstants.CompanyName;
            model.ExpirationDate = MutualConstants.ExpirationDate;


            model.UserSettingsList = Mapping.AutoMapperBase._mapper.Map<List<Helpers.Dto.ViewDtos.UserSettingsDto>>(db.userSettings.ToList());

            return model;
        }

        [HttpGet("SignIn", Name = "SignIn")]
        public async Task<SignIn> SignIn(string UserName, string Password)
        {

            SignIn Model2 = new SignIn();
            SignIn model = new SignIn();
            MemberList mem = new MemberList();

            Model2.UserName = UserName;
            Model2.Password = Password;


            if (ModelState.IsValid)
            {
                try
                {
                    var result = signInManager.PasswordSignInAsync(Model2.UserName, Model2.Password, Model2.RememberMe, false).Result;

                    if (!result.Succeeded)
                        return new SignIn();

                }
                catch (Exception ex)
                {

                    Mutuals.monitizer.AddException(ex);
                    return new SignIn();
                }

                var a = db.memberLists.Where(x => x.UserName == UserName).FirstOrDefault();

                model.custom_nickName = a.NickName;
                model.UserName = Model2.UserName;
                model.Password = Model2.Password;
                model.custom_userid = signInManager.UserManager.Users.SingleOrDefault(x => x.UserName == UserName).Id;
                model.custom_name = signInManager.UserManager.Users.SingleOrDefault(x => x.UserName == UserName).FullName;


                var user = await userManager.FindByIdAsync(model.custom_userid);

                var roles = await userManager.GetRolesAsync(user);

                var roleID = await roleManager.FindByNameAsync(roles[0]);

                model.custom_role = roles[0];
                model.custom_roleId = roleID.Id;

            }

            return model;
        }

        [HttpGet("GetRes", Name = "GetRes")]
        public ReservationViewModel GetRes(string date)

        {
            ReservationViewModel model = new ReservationViewModel();


            try
            {
                model.resTimes = db.resTimes.ToList();
                model.courts = db.courts.ToList();
                model.courtPriceLists = db.courtPriceLists.ToList();
                model.reservations = db.reservations.Where(x => x.ResDate == date).ToList();
                model.reservationCancels = db.reservationCancels.Where(x => x.ResDate == date).ToList();
                model.reservationSettings = db.reservationSettings.ToList();
                model.memberLists = db.memberLists.ToList();
                model.courtTimeInfs = db.courtTimeInfs.ToList();

            }
            catch (Exception ex)
            {
                model = new ReservationViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return model;

        }

        [HttpGet("ReservationCancel", Name = "ReservationCancel")]
        public JsonResult ReservationCancel()

        {
            ReservationListViewModel model = new ReservationListViewModel();

            

            try
            {

                model.reservations = db.reservations.ToList();
                model.courts = db.courts.ToList();

                if (model == null)
                {
                    return Json(false);
                }
            }
            catch (Exception ex)
            {
                model = new ReservationListViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return Json (model);

        }



        [HttpGet("GetMemberInf", Name = "GetMemberInf")]
        public List<MemberList> GetMemberInf(string date)

        {
            List<MemberList> model = new List<MemberList>();


            try
            {
                model = db.memberLists.ToList();

            }
            catch (Exception ex)
            {
                model = new List<MemberList>();

                Mutuals.monitizer.AddException(ex);
            }

            return model;

        }

        [HttpGet("GetResTime", Name = "GetResTime")]
        public JsonResult GetResTime(int courtId, string dateInf)
        {


            var court = db.courts.Where(x => x.CourtId == courtId).FirstOrDefault();
            var model = db.reservations.Where(x => x.Court.CourtId == court.CourtId && x.ResDate == dateInf && x.CancelRes == false).ToList();
            var courtTime = db.courtTimeInfs.Where(x => x.CourtId == court.CourtId).FirstOrDefault();


            if (courtTime == null)
            {
                return Json(false);
            }

            string startTime = courtTime.CourtStartTime;
            string finishTime = courtTime.CourtFinishTime;
            string period = courtTime.CourtTimePeriod;
            var periodTime = Convert.ToDouble(period);

            var mStartTime = startTime.Split(":");
            var sTime = mStartTime[0] + mStartTime[1];

            var mFinishTime = finishTime.Split(":");
            var fTime = mFinishTime[0] + mFinishTime[1];

            var mf = Convert.ToInt32(fTime);
            var ms = Convert.ToInt32(sTime);

            var miles = ((mf - ms) / 100);

            List<res_time> res_Times = new List<res_time>();

            if (periodTime == 15)
            {
                var count = (miles * 4);


                for (int i = 0; i < count; i++)
                {
                    var a = Convert.ToDateTime(startTime);
                    var b = a.AddMinutes(periodTime);
                    var c = b.ToString("HH:mm");

                    var d = Convert.ToString(c);

                    startTime = d;



                    res_Times.Add(new res_time
                    {
                        TimesId = i,
                        Times = d
                    });

                }

            }
            else if (periodTime == 30)
            {
                var count = miles * 2;

                for (int i = 0; i < count; i++)
                {
                    var a = Convert.ToDateTime(startTime);
                    var b = a.AddMinutes(periodTime);
                    var c = b.ToString("HH:mm");

                    var d = Convert.ToString(c);

                    startTime = d;



                    res_Times.Add(new res_time
                    {
                        TimesId = i,
                        Times = d
                    });

                }
            }
            else
            {
                var count = miles;

                for (int i = 0; i < count; i++)
                {
                    var a = Convert.ToDateTime(startTime);
                    var b = a.AddMinutes(periodTime);
                    var c = b.ToString("HH:mm");

                    var d = Convert.ToString(c);

                    startTime = d;



                    res_Times.Add(new res_time
                    {
                        TimesId = i,
                        Times = d
                    });

                }

            }

            var day_routine = res_Times;
            List<court_reserve> daily_reservations = new List<court_reserve>();

            try
            {

                bool _isTaken = false;

                for (int i = 0; i < day_routine.Count(); i++)
                {
                    foreach (var item in model)
                    {
                        if (day_routine[i].Times == item.ResStartTime) _isTaken = true;
                        if (day_routine[i].Times == item.ResFinishTime) _isTaken = false;
                    }

                    daily_reservations.Add(new court_reserve
                    {
                        start = day_routine[i].Times,
                        isTaken = _isTaken,
                        timeId = day_routine[i].TimesId
                    }
                    );
                }


            }
            catch (Exception ex)
            {
                model = new List<Reservation>();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(daily_reservations);

        }

        [HttpGet("NewReservation", Name = "NewReservation")]
        public JsonResult NewReservation(string ResDate, string ResTime, string ResStartTime, string ResFinishTime, string ResEvent, string UserId, int CourtId, string ResNowDate, int Price, string PriceIds)
        {

            var model = new Reservation();
            Reservation res = new Reservation();
            Court court = new Court();
            MemberList mem = new MemberList();
            CourtTimeInf time = new CourtTimeInf();
            ReservationTotal model4 = new ReservationTotal();

            time.CourtTimePeriod = db.courtTimeInfs.SingleOrDefault(x => x.CourtId == CourtId).CourtTimePeriod;
            var x = ResFinishTime.Split(":");
            var h = Convert.ToInt32(x[0]);
            var m = Convert.ToInt32(x[1]);
            var per = Convert.ToInt16(time.CourtTimePeriod);

            if (per == 15)
            {
                if (m == 45)
                {
                    h = h + 1;
                    if (h<10)
                    {
                        ResFinishTime = "0"+ h + ":" + "00";
                    }
                    else
                    ResFinishTime = h + ":" + "00";
                }
                else
                {

                    m = m + 15;
                    if (h < 10)
                    {
                        ResFinishTime = "0" + h + ":" + m;
                    }
                    else
                    ResFinishTime = h + ":" + m;
                }    
            }

            else if (per == 30)
            {
                if (m == 30)
                {
                    h = h + 1;
                    if (h < 10)
                    {
                        ResFinishTime = "0" + h + ":" + "00";
                    }
                    else
                    ResFinishTime = h + ":" + "00";
                }
                else
                {
                    m = m + 30;
                    if (h < 10)
                    {
                        ResFinishTime = "0" + h + ":" + m;
                    }
                    else
                    ResFinishTime = h + ":" + "00";
                }
               
            }
            else
            {
                h = h + 1;
                if (h < 10)
                {
                    ResFinishTime = "0" + h + ":" + "00";
                }
                ResFinishTime = h + ":" + "00";
            }
              

            if (ResDate == null || ResTime == null || ResStartTime == null || ResFinishTime == null || ResEvent == null || UserId == null || ResNowDate == null || PriceIds == null)
            {
                return Json(false);
            }

            else
            {
                try
                {
                    model = db.reservations.Where(x => x.Court.CourtId == CourtId && x.ResStartTime == ResStartTime && x.ResDate == ResDate && x.CancelRes == false).FirstOrDefault();
                    court = db.courts.SingleOrDefault(x => x.CourtId == CourtId);
                    mem.NickName = db.memberLists.FirstOrDefault(x => x.UserId == UserId).NickName;


                }

                catch (Exception e)
                {
                    return Json("false");

                }
            }

            if (model == null)
            {
                try
                {
                    res.NickName = mem.NickName;
                    res.Court = court;
                    res.ResFinishTime = ResFinishTime;
                    res.ResStartTime = ResStartTime;
                    res.ResDate = ResDate;
                    res.ResEvent = ResEvent;
                    res.ResTime = ResTime;
                    res.UserId = UserId;
                    res.ResNowDate = ResNowDate;
                    res.Price = Price;
                    res.PriceIds = PriceIds;

                    
                    
                    db.reservations.Add(res);
                    db.SaveChanges();
                }

                catch (Exception e)
                {

                    return Json("false");

                }

                return Json(res);
            }
            else

                return Json("false");
        }

        [HttpGet("GetResList", Name = "GetResList")]
        public JsonResult GetResList()

        {
            ReservationListViewModel model = new ReservationListViewModel();


            try
            {
                model.reservationCancels = db.reservationCancels.ToList();
                model.reservations = db.reservations.ToList();
                model.memberLists = db.memberLists.ToList();
                model.courts = db.courts.ToList();


            }
            catch (Exception ex)
            {
                model = new ReservationListViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);

        }

        [HttpGet("GetUserListModal", Name = "GetUserListModal")]
        public JsonResult GetUserListModal(string id)

        {
            ReservationListViewModel model = new ReservationListViewModel();


            try
            {
                model.date = db.reservations.Where(x => x.UserId == id).ToList().OrderByDescending(x => x.ResDate).Select(x => x.ResDate.Split("-")[0]).Distinct().ToList();
                model.debtCount = db.reservations.Where(x => x.UserId == id && x.PriceInf == false).Count();
                model.debtNotCount = db.reservations.Where(x => x.UserId == id && x.PriceInf == true).Count();
                model.cancelResCount = db.reservations.Where(x => x.UserId == id && x.CancelRes == true).Count();



                model.reservations = db.reservations.Where(x => x.UserId == id).ToList();
                model.courts = db.courts.ToList();
                model.memberLists = db.memberLists.Where(x => x.UserId == id).ToList();


            }
            catch (Exception ex)
            {
                model = new ReservationListViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);

        }

        [HttpGet("PaymentOperations", Name = "PaymentOperations")]
        public JsonResult PaymentOperations(string userId, int resId)

        {
            MemberList model = new MemberList();
            Reservation model2 = new Reservation();
            ReservationCancel model3 = new ReservationCancel();


            try
            {
                model3 = db.reservationCancels.Where(x => x.ResId == resId).FirstOrDefault();
                model = db.memberLists.Where(x => x.UserId == userId).FirstOrDefault();
                model2 = db.reservations.Where(x => x.ResId == resId).FirstOrDefault();

                if (model2 == null)
                {
                    if (model.Price - model3.Price >= 0)
                    {
                        var x = model.Price - model3.Price;

                        model3.PriceInf = true;
                        model.Price = x;

                        db.Update(model);
                        db.Update(model3);
                        db.SaveChanges();
                    }    
                    
                }

                else
                {

                    if (model.Price - model2.Price >= 0)
                    {
                        var y = model.Price - model2.Price;

                        model2.PriceInf = true;
                        model.Price = y;

                        db.Update(model);
                        db.Update(model2);
                        db.SaveChanges();
                    }
                }

               
             

               

            }
            catch (Exception ex)
            {


                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);

        }

        [HttpGet("GetPaymentOperations", Name = "GetPaymentOperations")]
        public JsonResult GetPaymentOperations(string userId, int resId)

        {
            ReservationListViewModel model = new ReservationListViewModel();



            try
            {
                model.courts = db.courts.ToList();
                model.reservations = db.reservations.Where(x => x.ResId == resId).ToList();

                if (model.reservations.Count == 0)
                {
                    model.reservationCancels = db.reservationCancels.Where(x => x.ResId == resId).ToList();
                }
                model.memberLists = db.memberLists.Where(x => x.UserId == userId).ToList();



            }
            catch (Exception ex)
            {


                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);

        }

        [HttpGet("ChangeCurrentUserPass", Name = "ChangeCurrentUserPass")]
        public async Task<JsonResult> ChangeCurrentUserPass(string id, string currentPass, string newPass)

        {
            AppIdentityUser model2 = new AppIdentityUser();
            MemberList model = new MemberList();

            try
            {
                model = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();
                var user = await userManager.FindByIdAsync(id);
                var res = await userManager.ChangePasswordAsync(user, currentPass, newPass);
                if (res.Succeeded == false)
                {
                    return Json(false);
                }
                else
                {
                    model.Password = newPass;
                    db.Update(model);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                model = new MemberList();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(true);

        }

        [HttpGet("GetResModalInf", Name = "GetResModalInf")]
        public JsonResult GetResModalInf(int id)

        {
            MemberList mem = new MemberList();
            ReservationCourtViewModel model = new ReservationCourtViewModel();
            ResModalViewModel model2 = new ResModalViewModel();

            try
            {

                model.courts = db.courts.ToList();
                model.reservations = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                mem = db.memberLists.Where(x => x.UserId == model.reservations.UserId).FirstOrDefault();

                model2.courtPriceLists = db.courtPriceLists.ToList();
                model2.resSchemaModal.FullName = mem.FullName;
                model2.resSchemaModal.NickName = mem.NickName;
                model2.resSchemaModal.CourtName = model.reservations.Court.CourtName;
                model2.resSchemaModal.ResDate = model.reservations.ResDate;
                model2.resSchemaModal.ResEvent = model.reservations.ResEvent;
                model2.resSchemaModal.ResFinishTime = model.reservations.ResFinishTime;
                model2.resSchemaModal.ResId = id;
                model2.resSchemaModal.ResStartTime = model.reservations.ResStartTime;
                model2.resSchemaModal.ResTime = model.reservations.ResTime;
                model2.resSchemaModal.ResNowDate = model.reservations.ResNowDate;
                model2.resSchemaModal.PriceInf = model.reservations.PriceInf;
                model2.resSchemaModal.Price = model.reservations.Price;
                model2.resSchemaModal.PriceIds = model.reservations.PriceIds;


            }
            catch (Exception ex)
            {
                model = new ReservationCourtViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(model2);

        }

        [HttpGet("CancelRes", Name = "CancelRes")]
        public JsonResult CancelRes(int id , string userId)

        {
            Reservation model = new Reservation();
            ReservationCancel model2 = new ReservationCancel();           
            List<Court> model3 = new List<Court>();
            

            try
            {
                
                model = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                model3 = db.courts.ToList();
          
                if (model != null)
                {
                 
                    model2.CancelRes = true;
                    model2.CancelResUserId = userId;
                    model2.CourtId = model.Court.CourtId;
                    model2.NickName = model.NickName;
                    model2.Price = model.Price;
                    model2.PriceIds = model.PriceIds;
                    model2.PriceInf = model.PriceInf;
                    model2.Procedure = model.Procedure;
                    model2.ResDate = model.ResDate;
                    model2.ResEvent = model.ResEvent;
                    model2.ResFinishTime = model.ResFinishTime;
                    model2.ResId = model.ResId;
                    model2.ResNowDate = model.ResNowDate;
                    model2.ResStartTime = model.ResStartTime;
                    model2.ResTime = model.ResTime;
                    model2.UserId = model.UserId;

                   

                    db.Remove(model);
                    db.Add(model2);
                    db.SaveChanges();

                    return Json(model);
                }
                else
                {
                    return Json(false);
                }

            }
            catch (Exception ex)
            {
                model = new Reservation();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);

        }

        [HttpGet("Logout", Name = "Logout")]
        public async Task<IActionResult> Logout()

        {
            try
            {
                await signInManager.SignOutAsync();
            }

            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);
            }

            return View();
        }

    }

    public class court_reserve
    {
        public int timeId { get; set; }
        public string start { get; set; }
        public bool isTaken { get; set; }
    }

    public class res_time
    {
        public int TimesId { get; set; }
        public string Times { get; set; }

    }



}