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



        //[HttpGet("GetMySettings", Name = "GetMySettings")]
        //public MutualsConstantsDto GetMySettings(string companyId)
        //{
        //    MutualsConstantsDto model = new MutualsConstantsDto();

        //    model.M1 = MutualConstants.M1;
        //    model.M2 = MutualConstants.M2;
        //    model.M3 = MutualConstants.M3;
        //    model.M4 = MutualConstants.M4;
        //    model.M5 = MutualConstants.M5;
        //    model.M6 = MutualConstants.M6;
        //    model.PhotoUrl = MutualConstants.PhotoUrl;
        //    model.SunucuIp = MutualConstants.SunucuIp;
        //    model.CompanyName = MutualConstants.CompanyName;
        //    model.ExpirationDate = MutualConstants.ExpirationDate;
        //    model.UserSettingsList = Mapping.AutoMapperBase._mapper.Map<List<Helpers.Dto.ViewDtos.UserSettingsDto>>(db.userSettings.ToList());

        //    return model;
        //}

        [HttpGet("GetUsers", Name = "GetUsers")]
        public IdentityPartialClass GetUsers()

        {
            IdentityPartialClass model = new IdentityPartialClass();

            try
            {
                model.AppIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();
                model.AppIdentityRoles = (List<AppIdentityRole>)roleManager.Roles.ToList();
                model.memberLists = db.memberLists.ToList();

            }
            catch (Exception ex)
            {
                model.AppIdentityRoles = new List<AppIdentityRole>();
                model.AppIdentityUsers = new List<AppIdentityUser>();

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetRoles", Name = "GetRoles")]
        public async Task<SignIn> GetRoles(string UserName, string password)
        {
            SignIn model = new SignIn();

            List<string> roles = new List<string>();

            var result = signInManager.PasswordSignInAsync(UserName, password ,false, false).Result;

            if (result.Succeeded)
            {
                var _user = signInManager.UserManager.Users.SingleOrDefault(x => x.UserName == UserName);

                var _roles = await userManager.GetRolesAsync(_user);

                model.custom_role = (List<string>)_roles;
                model.custom_roleId = new List<string>();

                foreach (var role in _roles)
                {
                    var _role = await roleManager.FindByNameAsync(role);
                    model.custom_roleId.Add((string)_role.Id);
                }


                return model;
            }

            return model;
          
        }

        [HttpGet("SignIn", Name = "SignIn")]
        public async Task<SignIn> SignIn(string UserName, string Password ,string RoleName, string RoleId)
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
                model.comp_Id = a.CompanyId;


                var user = await userManager.FindByIdAsync(model.custom_userid);

                var roles = await userManager.GetRolesAsync(user);

                var roleID = await roleManager.FindByNameAsync(roles[0]);

                var _roles = await userManager.GetRolesAsync(user);

               
                model.custom_roleId = new List<string>();
                model.custom_role = new List<string>();

                model.custom_role.Add(RoleName);
                model.custom_roleId.Add(RoleId);
         

            }

            return model;
        }

        [HttpGet("GetRes", Name = "GetRes")]
        public ReservationViewModel GetRes(string date)

        {
            ReservationViewModel model = new ReservationViewModel();


            try
            {
                model.resTimes = db.resTimes.OrderBy(x=>x.ResTimes).ToList();
                model.courts = db.courts.ToList();
                model.courtPriceLists = db.courtPriceLists.ToList();
                model.reservations = db.reservations.Where(x => x.ResDate == date).ToList();
                model.reservationCancels = db.reservationCancels.Where(x => x.ResDate == date).ToList();
                model.memberDues = db.memberDuesInfTables.ToList();
                model.reservationSettings = db.reservationSettings.ToList();
                model.memberLists = db.memberLists.ToList();
                model.courtScales = db.courtScaleLists.ToList();

                model.res = db.reservations.ToList();
                model.resCan = db.reservationCancels.ToList();
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

            return Json(model);

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

        [HttpGet("GetMemberDebt", Name = "GetMemberDebt")]
        public List<MemberDuesInfTable> GetMemberDebt(string userId)

        {
            List<MemberDuesInfTable> model = new List<MemberDuesInfTable>();


            try
            {
                model = db.memberDuesInfTables.Where(x=>x.MemberId == userId && x.DuesInfType == false).ToList();

            }
            catch (Exception ex)
            {
                model = new List<MemberDuesInfTable>();

                Mutuals.monitizer.AddException(ex);
            }

            return model; 

        }

        public class cabinetView
        {
            public List<CabinetListUser> cabinetListUsers { get; set; } = new List<CabinetListUser>();
            public List<MemberDuesInfTable> memberDuesInfTables { get; set; } = new List<MemberDuesInfTable>();

        }

        [HttpGet("GetCabinetDebt", Name = "GetCabinetDebt")]
        public cabinetView GetCabinetDebt(string userId)

        {
            cabinetView model = new cabinetView();


            try
            {
                model.memberDuesInfTables = db.memberDuesInfTables.Where(x => x.MemberId == userId && x.DuesInfType == true).ToList();
                model.cabinetListUsers = db.cabinetListUsers.Where(x => x.CabinetUserId == userId).ToList();

            }
            catch (Exception ex)
            {
                model = new cabinetView();

                Mutuals.monitizer.AddException(ex);
            }

            return model;

        }

        [HttpGet("GetResTime", Name = "GetResTime")]
        public JsonResult GetResTime(int courtId, string dateInf)
        {

            var court = db.courts.Where(x => x.CourtId == courtId).FirstOrDefault();
            var model = db.reservations.Where(x => x.Court.CourtId == court.CourtId && x.ResDate == dateInf && x.CancelRes == false).OrderBy(x => x.ResStartTime).ToList();

            var startTime = Convert.ToDateTime(court.CourtStartTime);
            var finishTime = Convert.ToDateTime(court.CourtFinishTime);
            string period = court.CourtTimePeriod;
            var periodTime = Convert.ToDouble(period);
            var sTime = startTime.AddMinutes(-periodTime);

            var miles = (finishTime - sTime).TotalHours;

            List<res_time> res_Times = new List<res_time>();

            if (periodTime == 15)
            {
                var count = (miles * 4);


                for (int i = 0; i < count; i++)
                {

                    var b = sTime.AddMinutes(periodTime);
                    var c = b.ToString("HH:mm");
                    var d = Convert.ToString(c);

                    sTime = Convert.ToDateTime(d);

                    res_Times.Add(new res_time
                    {
                        TimesId = i,
                        Period = periodTime,
                        Times = d

                    });

                }

            }


            else if (periodTime == 30)
            {
                var count = miles * 2;

                for (int i = 0; i < count; i++)
                {
                    var b = sTime.AddMinutes(periodTime);
                    var c = b.ToString("HH:mm");
                    var d = Convert.ToString(c);

                    sTime = Convert.ToDateTime(d);

                    res_Times.Add(new res_time
                    {
                        TimesId = i,
                        Period = periodTime,
                        Times = d
                    });

                }
            }


            else
            {
                var count = miles;

                for (int i = 0; i < count; i++)
                {
                    var b = sTime.AddMinutes(periodTime);
                    var c = b.ToString("HH:mm");
                    var d = Convert.ToString(c);

                    sTime = Convert.ToDateTime(d);

                    res_Times.Add(new res_time
                    {
                        TimesId = i,
                        Period = periodTime,
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
                        Period = day_routine[i].Period,
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
        public JsonResult NewReservation(string ResDate, string CompanyId, string ResTime, string ResStartTime, string ResFinishTime, string ResEvent, string UserId, int CourtId, string ResNowDate, int Price, string PriceIds , string RoleName , string RoleId)
        {
            var model = new Reservation();
            Reservation res = new Reservation();
            Court court = new Court();
            MemberList mem = new MemberList();
            ReservationTotal model4 = new ReservationTotal();
            var canDebt = db.memberCanDebts.FirstOrDefault(x => x.CompanyId == CompanyId).CanDebt;
            court.CourtTimePeriod = db.courts.SingleOrDefault(x => x.CourtId == CourtId && x.CompanyId == CompanyId).CourtTimePeriod;

            var x = ResFinishTime.Split(":");
            var h = Convert.ToInt32(x[0]);
            var m = Convert.ToInt32(x[1]);
            var per = Convert.ToInt16(court.CourtTimePeriod);


            if (per == 15)
            {
                if (m == 45)
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
                        ResFinishTime = h + ":" + m;
                }

            }
          
            else
            {
                h = h + 1;

                if (h < 10)
                {
                    if (m == 0)
                    {
                        ResFinishTime = "0" + h + ":" + "00";
                    }
                    else
                    {
                        ResFinishTime = "0" + h + ":" + m;
                    }
                    
                }
                else
                {
                    if (m == 0)
                    {
                        ResFinishTime = h + ":" + "00";
                    }
                    else
                    {
                        ResFinishTime = h + ":" + m;
                    }
                   
                }

            }


            if (ResDate == null || ResTime == null || ResStartTime == null || ResFinishTime == null || ResEvent == null || UserId == null || ResNowDate == null || PriceIds == null)
            {
                return Json(false);
            }

            else
            {
                try
                {
                    model = db.reservations.Where(x => x.Court.CourtId == CourtId && x.ResStartTime == ResStartTime && x.ResDate == ResDate && x.CancelRes == false && x.CompanyId == CompanyId).FirstOrDefault();
                    court = db.courts.SingleOrDefault(x => x.CourtId == CourtId && x.CompanyId == CompanyId);
                    mem = db.memberLists.FirstOrDefault(x => x.UserId == UserId && x.CompanyId == CompanyId);
                  
                }

                catch (Exception e)
                {
                    return Json("false");

                }
            }

            if (model == null)
            {
                var memberPrice = db.memberLists.Where(x => x.UserId == UserId && x.CompanyId == CompanyId).FirstOrDefault().Price; // 1500

                var resDebt = Price;

             

                try
                {

                    if (memberPrice - resDebt >= 0)
                    {
                        var newMemberPrice = memberPrice - resDebt;

                        mem.Price = newMemberPrice;
                        res.PriceInf = true;


                        res.NickName = mem.NickName;
                        res.Court = court;
                        res.ResFinishTime = ResFinishTime;
                        res.ResStartTime = ResStartTime;
                        res.ResDate = ResDate;
                        res.ResEvent = ResEvent;
                        res.ResTime = ResTime;
                        res.UserId = UserId;
                        res.doResUserId = UserId;
                        res.ResNowDate = ResNowDate;
                        res.Price = Price;
                        res.PriceIds = PriceIds;
                        res.RoleId = RoleId;
                        res.RoleName = RoleName;
                        res.CompanyId = CompanyId;



                        db.memberLists.Update(mem);
                        db.reservations.Add(res);
                        db.SaveChanges();
                    }

                    else
                    {
                        if (canDebt == false)
                        {
                            return Json("false");
                        }

                        else
                        {
                            res.PriceInf = false;
                            res.NickName = mem.NickName;
                            res.Court = court;
                            res.ResFinishTime = ResFinishTime;
                            res.ResStartTime = ResStartTime;
                            res.ResDate = ResDate;
                            res.ResEvent = ResEvent;
                            res.ResTime = ResTime;
                            res.UserId = UserId;
                            res.doResUserId = UserId;
                            res.ResNowDate = ResNowDate;
                            res.Price = Price;
                            res.PriceIds = PriceIds;
                            res.RoleName = RoleName;
                            res.RoleId = RoleId;
                            res.CompanyId = CompanyId;



                            db.memberLists.Update(mem);
                            db.reservations.Add(res);
                            db.SaveChanges();
                        }
                      
                    }


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

        [HttpGet("GetResList2", Name = "GetResList2")]
        public JsonResult GetResList2(string date, string userId)

        {
            List<Reservation> model = new List<Reservation>();

            try
            {
                model = db.reservations.Where(x => x.UserId == userId && x.ResDate == date).ToList();
              
            }
            catch (Exception ex)
            {
                model = new List<Reservation>();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);

        }

        public class CourtPriceListViewModel
        {
            public List<CourtPriceList> courtPriceLists { get; set; } = new List<CourtPriceList>();
            public List<CourtPriceList> priceLists { get; set; } = new List<CourtPriceList>();
            public List<string> priceListsId { get; set; } = new List<string>();

        }


        [HttpGet("GetListPrice", Name = "GetListPrice")]
        public CourtPriceListViewModel GetListPrice(int id, string time, string day, string month)
        {
            CourtPriceListViewModel model = new CourtPriceListViewModel();

            var courtType = db.courts.Where(x => x.CourtId == id).FirstOrDefault().CourtType;

            var time2 = time.Split(":")[0].Trim();

            model.courtPriceLists = db.courtPriceLists.Where(x => x.RecipeTypeId == courtType && x.TimeInf.Contains(time2) && x.DayInf.Contains(day) && x.MonthInf.Contains(month)).ToList();

            model.priceLists = db.courtPriceLists.Where(x => x.RecipeTypeId == courtType).ToList();


            var ids = "";

            for (int i = 0; i < model.courtPriceLists.Count; i++)
            {
                var asd = model.courtPriceLists[i].CourtPriceListId;

                ids = Convert.ToString(asd);

                model.priceListsId.Add(ids);
            }


            foreach (var item in model.priceListsId)
            {
                if (model.priceLists.Where(x => x.CourtPriceListId == Convert.ToInt32(item)).Count() > 0)
                {
                    model.priceLists.Remove(model.priceLists.Where(x => x.CourtPriceListId == Convert.ToInt32(item)).FirstOrDefault());
                }
            }

            try
            {
                if (model.courtPriceLists.Count != 0)
                {
                    return model;
                }

            }

            catch (Exception ex)
            {
                model = new CourtPriceListViewModel();
                Mutuals.monitizer.AddException(ex);
            }


            return model;
        }

        [HttpGet("GetUserListModal", Name = "GetUserListModal")]
        public JsonResult GetUserListModal(string id)

        {
            ReservationListViewModel model = new ReservationListViewModel();


            try
            {
                var activeReservation = db.reservations.Where(x => x.UserId == id).Count();
                var x = db.reservations.Where(x => x.UserId == id && x.PriceInf == false).Count();
                var y = db.reservations.Where(x => x.UserId == id && x.PriceInf == true).Count();
                var xx = db.reservationCancels.Where(x => x.UserId == id && x.PriceInf == false).Count();
                var yy = db.reservationCancels.Where(x => x.UserId == id && x.PriceInf == true).Count();


                var yx = db.reservations.Where(x => x.UserId == id).ToList().OrderByDescending(x => x.ResDate).Select(x => x.ResDate.Split("-")[0]).Distinct().ToList();

                var dateCancel = db.reservationCancels.Where(x => x.UserId == id).ToList().OrderByDescending(x => x.ResDate).Select(x => x.ResDate.Split("-")[0]).Distinct().ToList();

                yx.AddRange(dateCancel);

                model.date = yx.Distinct().OrderByDescending(x => x).ToList();




                model.debtCount = x + xx;
                model.debtNotCount = y + yy;
                model.cancelResCount = db.reservationCancels.Where(x => x.UserId == id && x.CancelRes == true).Count();
                model.activeResCount = activeReservation;

                model.reservationCancels = db.reservationCancels.Where(x => x.UserId == id).ToList();
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
            CourtScaleList scaleList = new CourtScaleList();

            try
            {

                model.courts = db.courts.ToList();
                model.reservations = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                mem = db.memberLists.Where(x => x.UserId == model.reservations.UserId).FirstOrDefault();
                scaleList = db.courtScaleLists.FirstOrDefault(x => x.Code == model.reservations.NickName);

                var whoRes = db.memberLists.Where(x => x.UserId == model.reservations.doResUserId).FirstOrDefault().FullName;

                model2.courtPriceLists = db.courtPriceLists.ToList();

                if (mem == null)
                {
                    model2.resSchemaModal.NickName = model.reservations.NickName;
                    model2.resSchemaModal.FullName = scaleList.Name;
                }

                else
                {
                    model2.resSchemaModal.FullName = mem.FullName;
                    model2.resSchemaModal.NickName = mem.NickName;
                }

                model2.resSchemaModal.UserId = model.reservations.UserId;
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
                model2.resSchemaModal.DoResInf = whoRes;


            }
            catch (Exception ex)
            {
                model = new ReservationCourtViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(model2);

        }

        [HttpGet("CancelRes", Name = "CancelRes")]
        public JsonResult CancelRes(int id, string userId, bool procedure, string cancelReasons , string compId)

        {
            Reservation model = new Reservation();
            ReservationCancel model2 = new ReservationCancel();
            List<Court> model3 = new List<Court>();
            ReservationSettings set = new ReservationSettings();
            MemberList mem = new MemberList();

            try
            {
                set = db.reservationSettings.Where(x => x.ReservationSettingsInf == "Rezervasyon İptal Süresi (Saat)").FirstOrDefault();
                model = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                model3 = db.courts.ToList();

                if (model.PriceInf == true && procedure == true){

                    mem = db.memberLists.Where(x => x.UserId == model.UserId).FirstOrDefault();

                    mem.Price = mem.Price + model.Price;

                    db.Update(mem);
                    db.SaveChanges();
                }

                if (model != null)
                {

                    model2.CancelRes = true;
                    model2.CancelResUserId = userId;
                    model2.CourtId = model.Court.CourtId;
                    model2.NickName = model.NickName;
                    model2.Price = model.Price;
                    model2.PriceIds = model.PriceIds;
                    model2.PriceInf = model.PriceInf;
                    model2.Procedure = procedure;
                    model2.ResDate = model.ResDate;
                    model2.ResEvent = model.ResEvent;
                    model2.ResFinishTime = model.ResFinishTime;
                    model2.ResId = model.ResId;
                    model2.ResNowDate = model.ResNowDate;
                    model2.ResStartTime = model.ResStartTime;
                    model2.ResTime = model.ResTime;
                    model2.UserId = model.UserId;
                    model2.CancelReasons = cancelReasons;
                    model2.CompanyId = compId;



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

        [HttpGet("CancelResProcedure", Name = "CancelResProcedure")]
        public JsonResult CancelResProcedure(int id, string userId, bool procedure, string cancelReasons)

        {
            Reservation model = new Reservation();
            ReservationCancel model2 = new ReservationCancel();
            List<Court> model3 = new List<Court>();
            ReservationSettings set = new ReservationSettings();

            try
            {
                set = db.reservationSettings.Where(x => x.ReservationSettingsInf == "Rezervasyon İptal Süresi (Saat)").FirstOrDefault();
                model = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                model3 = db.courts.ToList();


                var strDate = (model.ResDate + " " + model.ResStartTime + ":" + "00");

                DateTime myDate = DateTime.ParseExact(strDate, "yyyy-MM-dd HH:mm:ss",
                                       CultureInfo.InvariantCulture);

                var dateTimeNow = (myDate - DateTime.Now).TotalHours;

                if (dateTimeNow < Convert.ToInt16(set.ReservationValue))
                {
                    return Json(false);
                }

                else if (dateTimeNow < 0)
                {
                    return Json(false);
                }

                else
                {
                    return Json(model);
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
        public double Period { get; set; }
    }

    public class res_time
    {
        public int TimesId { get; set; }
        public string Times { get; set; }
        public double Period { get; set; }

    }

}