using Microsoft.AspNetCore.Mvc;
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

            Model2.UserName = UserName;
            Model2.Password = Password;

            SignIn model = new SignIn();

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
                model.reservationSettings = db.reservationSettings.ToList();
                model.memberLists = db.memberLists.ToList();

            }
            catch (Exception ex)
            {
                model = new ReservationViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return model;

        }

        [HttpGet("GetResTime", Name = "GetResTime")]
        public JsonResult GetResTime(string courtInf, string dateInf)
        {
            if (courtInf == "Kort Seçiniz")
            {
                return Json("false");
            }

            var court = db.courts.Where(x => x.CourtName == courtInf).FirstOrDefault();
            var model = db.reservations.Where(x => x.Court.CourtId == court.CourtId && x.ResDate == dateInf).ToList();
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
        public JsonResult NewReservation(string ResDate, string ResTime, string ResStartTime, string ResFinishTime, string ResEvent, string UserId, int CourtId, string ResNowDate, int Price , string PriceIds)
        {

            var model = new Reservation();
            Reservation res = new Reservation();
            Court court = new Court();


            if (ResDate == null || ResTime == null || ResStartTime == null || ResFinishTime == null || ResEvent == null || UserId == null || ResNowDate == null || PriceIds == null)
            {
                return Json(false);
            }

            else
            {
                try
                {
                    model = db.reservations.Where(x => x.Court.CourtId == CourtId && x.ResStartTime == ResStartTime && x.ResDate == ResDate).FirstOrDefault();
                    court = db.courts.SingleOrDefault(x => x.CourtId == CourtId);
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
        public JsonResult CancelRes(int id)

        {
            Reservation model = new Reservation();

            try
            {

                model = db.reservations.Where(x => x.ResId == id).FirstOrDefault();

                if (model != null)
                {
                    db.Remove(model);
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