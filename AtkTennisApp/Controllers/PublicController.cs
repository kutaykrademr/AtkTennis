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
        public async Task<SignIn>  SignIn(string UserName, string Password)
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
                

                var user =  await userManager.FindByIdAsync(model.custom_userid);
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
                model.reservations = db.reservations.Where(x=>x.ResDate == date).ToList();
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
        public JsonResult GetResTime(string courtInf, string dateInf , int timeMin)
        {
            if (courtInf == "Kort Seçiniz")
            {
                return Json("false");
            }

            if (timeMin == 30)
            {
                var court = db.courts.Where(x => x.CourtName == courtInf).FirstOrDefault();
                var model = db.reservations.Where(x => x.Court.CourtId == court.CourtId && x.ResDate == dateInf).ToList();
                var day_routine = db.resTimes.Where(x => x.ResTimes30 == timeMin).ToList();


                List<court_reserve> daily_reservations = new List<court_reserve>();

                try
                {

                    bool _isTaken = false;

                    for (int i = 0; i < day_routine.Count(); i++)
                    {
                        foreach (var item in model)
                        {
                            if (day_routine[i].ResTimes == item.ResStartTime) _isTaken = true;
                            if (day_routine[i].ResTimes == item.ResFinishTime) _isTaken = false;
                        }

                        daily_reservations.Add(new court_reserve
                        {
                            start = day_routine[i].ResTimes,
                            isTaken = _isTaken,
                            timeId = day_routine[i].ResTimeId
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

            else if (timeMin == 60)
            {
                var court = db.courts.Where(x => x.CourtName == courtInf).FirstOrDefault();
                var model = db.reservations.Where(x => x.Court.CourtId == court.CourtId && x.ResDate == dateInf).ToList();
                var day_routine = db.resTimes.Where(x => x.Restimes60 == timeMin).ToList();

                List<court_reserve> daily_reservations = new List<court_reserve>();

                try
                {

                    bool _isTaken = false;

                    for (int i = 0; i < day_routine.Count(); i++)
                    {
                        foreach (var item in model)
                        {
                            if (day_routine[i].ResTimes == item.ResStartTime) _isTaken = true;
                            if (day_routine[i].ResTimes == item.ResFinishTime) _isTaken = false;
                        }

                        daily_reservations.Add(new court_reserve
                        {
                            start = day_routine[i].ResTimes,
                            isTaken = _isTaken,
                            timeId = day_routine[i].ResTimeId
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

            else
            {
                var court = db.courts.Where(x => x.CourtName == courtInf).FirstOrDefault();
                var model = db.reservations.Where(x => x.Court.CourtId == court.CourtId && x.ResDate == dateInf).ToList();
                var day_routine = db.resTimes.ToList();

                List<court_reserve> daily_reservations = new List<court_reserve>();

                try
                {

                    bool _isTaken = false;

                    for (int i = 0; i < day_routine.Count(); i++)
                    {
                        foreach (var item in model)
                        {
                            if (day_routine[i].ResTimes == item.ResStartTime) _isTaken = true;
                            if (day_routine[i].ResTimes == item.ResFinishTime) _isTaken = false;
                        }

                        daily_reservations.Add(new court_reserve
                        {
                            start = day_routine[i].ResTimes,
                            isTaken = _isTaken,
                            timeId = day_routine[i].ResTimeId
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
      
        }

        [HttpGet("NewReservation", Name = "NewReservation")]
        public JsonResult NewReservation(string ResDate , string ResTime ,string ResStartTime , string ResFinishTime , string ResEvent, string UserId , int CourtId)
        {

            var model = new Reservation();
            Reservation res = new Reservation();
            Court court = new Court();

            if (ResDate == null || ResTime ==null || ResStartTime == null || ResFinishTime == null || ResEvent == null || UserId == null )
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

}