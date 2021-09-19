using AtkTennisApp.Security;
using AtkTennisApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtkTennisApp.Models;
using AtkTennis.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Collections;

namespace AtkTennisApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminHomeController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public AdminHomeController(UserManager<AppIdentityUser> userManager,
            RoleManager<AppIdentityRole> roleManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        Context db = new Context();

        [HttpGet("GetHome", Name = "GetHome")]
        public HomeModelView GetHome()
        {
            DateTime date1 = DateTime.Now;
            var today = date1.ToString("yyyy-MM-dd");

            HomeModelView model = new HomeModelView();


            try
            {
                model.TotalUserCount = userManager.Users.Count();
                model.TotalRoleCount = roleManager.Roles.Count();
                var b = db.reservations.Where(x => x.ResDate == today).ToList();
                var a = db.reservations.ToList();
                model.TodayResCount = b.Count();
                model.TotalResCount = a.Count();
                model.toDoLists = db.toDoLists.ToList();
                model.reservations = db.reservations.ToList();
                model.courts = db.courts.ToList();
                model.resTimes = db.resTimes.ToList();
                model.courtPriceLists = db.courtPriceLists.ToList();
                model.reservationSettings = db.reservationSettings.ToList();
                model.memberLists = db.memberLists.ToList();
                model.courtScaleLists = db.courtScaleLists.ToList();



            }
            catch (Exception ex)
            {
                model = new HomeModelView();
                Mutuals.monitizer.AddException(ex);
            }


            return model;
        }

        [HttpGet("GetUserSchoolList", Name = "GetUserSchoolList")]
        public JsonResult GetUserSchoolList()
        {


            MemberSchoolPerViewModel model = new MemberSchoolPerViewModel();


            try
            {
                model.schoolTypes = db.schoolTypes.ToList();
                model.memberLists = db.memberLists.ToList();
                model.performanceTypes = db.performanceTypes.ToList();
                model.courtScales = db.courtScaleLists.ToList();



            }
            catch (Exception ex)
            {
                model = new MemberSchoolPerViewModel();
                Mutuals.monitizer.AddException(ex);
            }


            return Json(model);
        }

        [HttpGet("GetMultiReservation", Name = "GetMultiReservation")]
        public List<Court> GetMultiReservation()
        {

            List<Court> model = new List<Court>();

            try
            {
                model = db.courts.ToList();

            }
            catch (Exception ex)
            {
                model = new List<Court>();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }


        [HttpGet("GetGeneralDebtMember", Name = "GetGeneralDebtMember")]
        public JsonResult GetGeneralDebtMember()
        {

            List<MemberDebtType> model = new List<MemberDebtType>();

            try
            {
                model = db.memberDebtTypes.ToList();
             
                if (model.Count != 0)
                {
                    return Json(model);
                }
              
            }
            catch (Exception ex)
            {
                model = new List<MemberDebtType>();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(true);
        }

        [HttpGet("GetCabinetListUser", Name = "GetCabinetListUser")]
        public CabinetListUserViewModel GetCabinetListUser(string date)
        {

            CabinetListUserViewModel model = new CabinetListUserViewModel();


            try
            {
                model.cabinetListUsers = db.cabinetListUsers.ToList();
                model.memberLists = db.memberLists.ToList();

            }
            catch (Exception ex)
            {
                model = new CabinetListUserViewModel();
                Mutuals.monitizer.AddException(ex);
            }


            return model;
        }

        [HttpGet("GetResTable", Name = "GetResTable")]
        public JsonResult GetResTable(string date)
        {
            HomeModelView model = new HomeModelView();

            try
            {
                model.courts = db.courts.ToList();
                model.resTimes = db.resTimes.ToList();
                model.reservations = db.reservations.Where(x => x.ResDate == date).ToList();
                model.reservationCancels = db.reservationCancels.Where(x => x.ResDate == date).ToList();
                model.memberLists = db.memberLists.ToList();
                model.courtScaleLists = db.courtScaleLists.ToList();

            }
            catch (Exception ex)
            {
                model = new HomeModelView();
                Mutuals.monitizer.AddException(ex);
            }


            return Json(model);
        }

        [HttpGet("GetMemberDetail", Name = "GetMemberDetail")]
        public JsonResult GetMemberDetail(int memberNum)
        {
            GetMemberDetailViewModel model = new GetMemberDetailViewModel();


            try
            {
                var totalPriceResInf = 0;
                var totalPriceResCancelInf = 0;

                model.memberLists = db.memberLists.Where(x => x.MemberNumber == memberNum).FirstOrDefault();
                var userId = model.memberLists.UserId;
                model.cabinetListUsers = db.cabinetListUsers.ToList();
                model.cabinetTypes = db.cabinetTypes.ToList();
                model.cabinetOperations = db.cabinetOperations.ToList();
                model.reservations = db.reservations.Where(x => x.UserId == userId).ToList();
                model.reservationCancels = db.reservationCancels.Where(x => x.UserId == userId).ToList();

                for (int i = 0; i < model.reservations.Count; i++)
                {
                    if (model.reservations[i].PriceInf == false)
                    {
                        var x = model.reservations[i].Price;
                        totalPriceResInf = totalPriceResInf + x;
                    }
                }
                for (int i = 0; i < model.reservationCancels.Count; i++)
                {
                    if (model.reservationCancels[i].PriceInf == false && model.reservationCancels[i].Procedure == false)
                    {
                        var y = model.reservationCancels[i].Price;
                        totalPriceResCancelInf = totalPriceResCancelInf + y;
                    }
                }

                model.totalPrice = totalPriceResInf + totalPriceResCancelInf;

            }

            catch (Exception ex)
            {
                model = new GetMemberDetailViewModel();
                Mutuals.monitizer.AddException(ex);
            }


            return Json(model);
        }

        [HttpGet("GetResSchemaDetail", Name = "GetResSchemaDetail")]
        public JsonResult GetResSchemaDetail(string date)
        {
            DateTime date1 = DateTime.Now;
            var today = date1.ToString("yyyy-MM-dd");

            ResSchemaViewModel model = new ResSchemaViewModel();

            try
            {
                model.reservations = db.reservations.Where(x => x.ResDate == date).ToList();
                model.memberLists = db.memberLists.ToList();
                model.courts = db.courts.ToList();
                model.courtScales = db.courtScaleLists.ToList();


            }
            catch (Exception ex)
            {
                model = new ResSchemaViewModel();
                Mutuals.monitizer.AddException(ex);
            }


            return Json(model);
        }

        [HttpGet("GetRole", Name = "GetRole")]
        public List<AppIdentityRole> GetRole()

        {

            List<AppIdentityRole> model = new List<AppIdentityRole>();

            try
            {
                model = (List<AppIdentityRole>)roleManager.Roles.ToList();
            }
            catch (Exception ex)
            {
                model = new List<AppIdentityRole>();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetStudentRegister", Name = "GetStudentRegister")]
        public RegisterStudentViewModel GetStudentRegister()

        {
            RegisterStudentViewModel model = new RegisterStudentViewModel();

            try
            {
                model.performanceTypes = db.performanceTypes.ToList();
                model.performanceLevels = db.performanceLevels.ToList();
                model.schoolLevels = db.schoolLevels.ToList();
                model.schoolTypes = db.schoolTypes.ToList();

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("NewRegister", Name = "NewRegister")]
        public AppIdentityUser NewRegister(string name, string nickName, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role, int memberNumber)
        {
            MemberList model2 = new MemberList();

            var Role = new AppIdentityRole();
            var user = new AppIdentityUser();
            try
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {

                    Role.Name = role;
                    Role.Description = "Can Perform Crud Operations";
                    var roleResult = roleManager.CreateAsync(Role).Result;
                }

                user.UserName = username;
                user.Email = email;
                user.FullName = name;
                user.BirthDate = birthdate;
                user.PhoneNumber = phone;
                Role.Name = role;

                var result = userManager.CreateAsync(user, password).Result;

                var id = user.Id;

                model2.MemberNumber = memberNumber;
                model2.UserId = id;
                model2.FullName = name;
                model2.NickName = nickName;
                model2.Gender = gender;
                model2.UserName = username;
                model2.StartDate = startDate;
                model2.FinishDate = finishDate;
                model2.Role = role;
                model2.Condition = condition;
                model2.IdentityNumber = identificationNumber;
                model2.WebReservation = webReservation;
                model2.Phone = phone;
                model2.PhoneExp = phoneExp;
                model2.Phone2 = phone2;
                model2.Phone2Exp = phone2Exp;
                model2.Email = email;
                model2.EmailExp = emailExp;
                model2.BirthDate = birthdate;
                model2.BirthPlace = birthPlace;
                model2.MotherName = motherName;
                model2.FatherName = fatherName;
                model2.City = city;
                model2.District = district;
                model2.Job = job;
                model2.Note = note;
                model2.Password = password;


                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                    db.Add(model2);
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Details");
                }
            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }


            return user;
        }

        [HttpGet("GetUser", Name = "GetUser")]
        public IdentityPartialClass GetUser()

        {
            IdentityPartialClass model = new IdentityPartialClass();

            try
            {
                model.AppIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();
                model.AppIdentityRoles = (List<AppIdentityRole>)roleManager.Roles.ToList();
                model.memberLists = db.memberLists.Where(x => x.Role != "Üye").ToList();

            }
            catch (Exception ex)
            {
                model.AppIdentityRoles = new List<AppIdentityRole>();
                model.AppIdentityUsers = new List<AppIdentityUser>();

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetMember", Name = "GetMember")]
        public IdentityPartialClass GetMember()

        {
            IdentityPartialClass model = new IdentityPartialClass();

            try
            {
                model.AppIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();
                model.AppIdentityRoles = (List<AppIdentityRole>)roleManager.Roles.ToList();
                model.memberLists = db.memberLists.Where(x => x.Role == "ÜYE").ToList();

            }
            catch (Exception ex)
            {
                model.AppIdentityRoles = new List<AppIdentityRole>();
                model.AppIdentityUsers = new List<AppIdentityUser>();

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("NewReservationAdmin", Name = "NewReservationAdmin")]
        public JsonResult NewReservationAdmin(string ResDate, string ResTime, string ResStartTime, string ResFinishTime, string ResEvent, string UserId, int CourtId, string ResNowDate, int Price, string PriceIds, string UserName, bool PrivRes)
        {

            var model = new Reservation();
            var scale = new CourtScaleList();


            Reservation res = new Reservation();
            Court court = new Court();
            MemberList mem = new MemberList();

            ReservationTotal model4 = new ReservationTotal();

            court.CourtTimePeriod = db.courts.SingleOrDefault(x => x.CourtId == CourtId).CourtTimePeriod;

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
                        ResFinishTime = "0" + h + ":" + m + "0";
                    }
                    else
                    {
                        ResFinishTime = "0" + h + ":" + m;
                    }

                }
                else
                {
                    ResFinishTime = h + ":" + "00";
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
                    model = db.reservations.Where(x => x.Court.CourtId == CourtId && x.ResStartTime == ResStartTime && x.ResDate == ResDate && x.CancelRes == false).FirstOrDefault();
                    court = db.courts.SingleOrDefault(x => x.CourtId == CourtId);
                    mem = db.memberLists.FirstOrDefault(x => x.NickName == UserName.Trim());
                    scale = db.courtScaleLists.FirstOrDefault(x => x.Code == UserName);

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

                    if (mem != null)
                    {
                        var memberPrice = mem.Price;
                        var resDebt = Price;

                        if (memberPrice - resDebt >= 0)
                        {
                            res.PrivRes = PrivRes;
                            res.NickName = mem.NickName;
                            res.UserId = mem.UserId;

                            var newMemberPrice = memberPrice - resDebt;

                            mem.Price = newMemberPrice;
                            res.PriceInf = true;

                            res.Court = court;
                            res.ResFinishTime = ResFinishTime;
                            res.ResStartTime = ResStartTime;
                            res.ResDate = ResDate;
                            res.ResEvent = ResEvent;
                            res.ResTime = ResTime;
                            res.doResUserId = UserId;
                            res.ResNowDate = ResNowDate;
                            res.Price = Price;
                            res.PriceIds = PriceIds;

                            db.memberLists.Update(mem);
                            db.reservations.Add(res);
                            db.SaveChanges();

                        }

                        else
                        {
                            res.PrivRes = PrivRes;
                            res.NickName = mem.NickName;
                            res.UserId = mem.UserId;
                            res.PriceInf = false;
                            res.Court = court;
                            res.ResFinishTime = ResFinishTime;
                            res.ResStartTime = ResStartTime;
                            res.ResDate = ResDate;
                            res.ResEvent = ResEvent;
                            res.ResTime = ResTime;
                            res.doResUserId = UserId;
                            res.ResNowDate = ResNowDate;
                            res.Price = Price;
                            res.PriceIds = PriceIds;


                            db.reservations.Add(res);
                            db.SaveChanges();

                        }
                    }

                    else if (scale != null)
                    {
                        {

                            res.PrivRes = PrivRes;
                            res.NickName = UserName.Trim();
                            res.UserId = null;
                            res.PriceInf = true;
                            res.Court = court;
                            res.ResFinishTime = ResFinishTime;
                            res.ResStartTime = ResStartTime;
                            res.ResDate = ResDate;
                            res.ResEvent = ResEvent;
                            res.ResTime = ResTime;
                            res.doResUserId = UserId;
                            res.ResNowDate = ResNowDate;
                            res.Price = Price;
                            res.PriceIds = PriceIds;


                            db.reservations.Add(res);
                            db.SaveChanges();

                        }
                    }

                    else
                    {
                        return Json(false);
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





        [HttpGet("GetResTimeUpd", Name = "GetResTimeUpd")]
        public JsonResult GetResTimeUpd(int courtId, string dateInf, int resId)
        {
            var res = db.reservations.Where(x => x.ResId == resId).FirstOrDefault();
            var court = db.courts.Where(x => x.CourtId == courtId).FirstOrDefault();
            var model = db.reservations.Where(x => x.Court.CourtId == court.CourtId && x.ResDate == dateInf && x.CancelRes == false).ToList();

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
                        if (day_routine[i].Times == res.ResStartTime) _isTaken = false;
                        else if (day_routine[i].Times == item.ResStartTime) _isTaken = true;
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

        [HttpGet("CancelResProcedureModal", Name = "CancelResProcedureModal")]
        public JsonResult CancelResProcedureModal(int id)

        {

            MemberList mem = new MemberList();
            ReservationCourtViewModel model = new ReservationCourtViewModel();
            ResModalViewModel model2 = new ResModalViewModel();
            ReservationSettings set = new ReservationSettings();

            try
            {


                model.reservations = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                mem = db.memberLists.Where(x => x.UserId == model.reservations.UserId).FirstOrDefault();
                model.courts = db.courts.ToList();

                set = db.reservationSettings.Where(x => x.ReservationSettingsInf == "Rezervasyon İptal Süresi (Saat)").FirstOrDefault();


                if (model != null && set != null)
                {
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


                    var strDate = (model.reservations.ResDate + " " + model.reservations.ResStartTime + ":" + "00");

                    DateTime myDate = DateTime.ParseExact(strDate, "yyyy-MM-dd HH:mm:ss",
                                           CultureInfo.InvariantCulture);

                    var dateTimeNow = (myDate - DateTime.Now).TotalHours;

                    if (dateTimeNow > Convert.ToInt16(set.ReservationValue))
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json(model2);
                    }
                }
                else
                {
                    return Json(false);
                }

            }
            catch (Exception ex)
            {
                model = new ReservationCourtViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);

        }

        [HttpGet("CancelResAdmin", Name = "CancelResAdmin")]
        public JsonResult CancelRes(int id, string userId, bool procedure, string cancelReasons)

        {
            MemberList mem = new MemberList();
            Reservation model = new Reservation();
            ReservationCancel model2 = new ReservationCancel();
            List<Court> model3 = new List<Court>();


            try
            {

                model = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                mem = db.memberLists.Where(x => x.UserId == model.UserId).FirstOrDefault();
                model3 = db.courts.ToList();

                if (procedure == true)
                {
                    var memberPrice = mem.Price;
                    var newPrice = memberPrice + model.Price;

                    mem.Price = newPrice;

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

        [HttpGet("GetUpdateResAdmin", Name = "GetUpdateResAdmin")]
        public JsonResult GetUpdateResAdmin(int id)

        {
            ReservationCourtViewModel model = new ReservationCourtViewModel();

            try
            {

                model.reservations = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                model.courts = db.courts.ToList();


                if (model != null)
                {
                    return Json(model);
                }

                else
                {
                    return Json(false);
                }

            }
            catch (Exception ex)
            {
                model = new ReservationCourtViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);

        }

        [HttpGet("UpdateResAdmin", Name = "UpdateResAdmin")]
        public JsonResult UpdateResAdmin(int id, string startTime, string finishTime, string time, int cId)

        {
            Reservation model = new Reservation();
            Court court = new Court();

            try
            {
                model = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                court = db.courts.SingleOrDefault(x => x.CourtId == cId);
                court.CourtTimePeriod = db.courts.SingleOrDefault(x => x.CourtId == cId).CourtTimePeriod;


                var x = finishTime.Split(":");
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
                            finishTime = "0" + h + ":" + "00";
                        }
                        else
                            finishTime = h + ":" + "00";
                    }
                    else
                    {

                        m = m + 15;
                        if (h < 10)
                        {
                            finishTime = "0" + h + ":" + m;
                        }
                        else
                            finishTime = h + ":" + m;
                    }
                }
                else if (per == 30)
                {
                    if (m == 30)
                    {
                        h = h + 1;
                        if (h < 10)
                        {
                            finishTime = "0" + h + ":" + "00";
                        }
                        else
                            finishTime = h + ":" + "00";
                    }
                    else
                    {
                        m = m + 30;
                        if (h < 10)
                        {
                            finishTime = "0" + h + ":" + m;
                        }
                        else
                            finishTime = h + ":" + m;
                    }

                }
                else
                {
                    h = h + 1;

                    if (h < 10)
                    {
                        finishTime = "0" + h + ":" + "00";
                    }
                    else
                    {
                        finishTime = h + ":" + "00";
                    }

                }

                model.Court = court;
                model.ResStartTime = startTime;
                model.ResFinishTime = finishTime;
                model.ResDate = time;

                db.Update(model);
                db.SaveChanges();


                if (model != null)
                {
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

        [HttpGet("UpdateMemberList", Name = "UpdateMemberList")]
        public async Task<JsonResult> UpdateMemberList(string id, string checkpass, string name, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role)
        {
            AppIdentityUser model = new AppIdentityUser();
            MemberList model2 = new MemberList();


            try
            {


                model = await userManager.FindByIdAsync(id);

                model2 = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();


                if (model != null)
                {
                    model.UserName = username;
                    model.Email = email;
                    model.FullName = name;
                    model.BirthDate = birthdate;
                    model.PhoneNumber = phone;

                }


                model2.BirthDate = birthdate;
                model2.BirthPlace = birthPlace;
                model2.City = city;
                model2.Condition = condition;
                model2.District = district;
                model2.Email = email;
                model2.EmailExp = emailExp;
                model2.FatherName = fatherName;
                model2.FinishDate = finishDate;
                model2.FullName = name;
                model2.Gender = gender;
                model2.IdentityNumber = identificationNumber;
                model2.Job = job;
                model2.MotherName = motherName;
                model2.Note = note;
                model2.Password = password;
                model2.Phone = phone;
                model2.Phone2 = phone2;
                model2.Phone2Exp = phone2Exp;
                model2.PhoneExp = phoneExp;
                model2.StartDate = startDate;
                model2.UserName = username;
                model2.WebReservation = webReservation;
                model2.Role = role;



                var user = await userManager.FindByIdAsync(id);
                var role_to_remove = await userManager.GetRolesAsync(user);
                var result = await userManager.RemoveFromRoleAsync(user, role_to_remove[0]);

                var newRole = await userManager.AddToRoleAsync(user, role);

                if (model2.Password != checkpass)
                {
                    var res = await userManager.ChangePasswordAsync(user, checkpass, password);
                    if (res.Succeeded == false)
                    {
                        return Json(false);
                    }
                    await signInManager.RefreshSignInAsync(user);
                }

                var result2 = userManager.UpdateAsync(model).Result;
                db.Update(model2);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("GetMemberListInf", Name = "GetMemberListInf")]
        public JsonResult GetMemberListInf(string id)

        {
            MemberList model = new MemberList();

            try
            {
                model = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                model = new MemberList();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);
        }

        [HttpGet("DeleteUser", Name = "DeleteUser")]
        public async Task<JsonResult> DeleteUser(string id)
        {
            AppIdentityUser model = new AppIdentityUser();
            var user = await userManager.FindByIdAsync(id);

            MemberList user2 = new MemberList();
            user2 = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();

            if (user == null || user2 == null)
            {
                return Json(false);
            }

            else
            {
                try
                {
                    var result = await userManager.DeleteAsync(user);


                    if (result.Succeeded)
                    {
                        db.Remove(user2);
                        db.SaveChanges();

                        return Json(user2);
                    }
                }

                catch (Exception ex)
                {
                    Mutuals.monitizer.AddException(ex);

                }
                return Json(true);
            }
        }

        [HttpGet("AddPrice", Name = "AddPrice")]
        public JsonResult AddPrice(int id, int money)
        {
            MemberList model = new MemberList();

            model = db.memberLists.Where(x => x.Id == id).FirstOrDefault();

            if (model != null)
            {
                try
                {

                    var currentPrice = model.Price;
                    var newPrice = currentPrice + money;

                    model.Price = newPrice;

                    db.Update(model);
                    db.SaveChanges();

                }

                catch (Exception ex)
                {
                    Mutuals.monitizer.AddException(ex);

                }
                return Json(model);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpGet("AddToDo", Name = "AddToDo")]
        public JsonResult AddToDo(string toDo, string today)
        {
            ToDoList model = new ToDoList();


            if (toDo == null || today == null)
            {
                return Json(false);
            }

            else
            {
                try
                {
                    model.Date = today;
                    model.ToDo = toDo;


                    if (model != null)
                    {
                        db.Add(model);
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
                    Mutuals.monitizer.AddException(ex);

                }
                return Json(true);
            }
        }

        [HttpGet("DeleteCabinet", Name = "DeleteCabinet")]
        public JsonResult DeleteCabinet(int id)
        {
            CabinetListUser model = new CabinetListUser();


            if (id == null)
            {
                return Json(false);
            }

            else
            {
                try
                {

                    model = db.cabinetListUsers.Where(x => x.CabinetOpId == id).FirstOrDefault();

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
                    Mutuals.monitizer.AddException(ex);

                }
                return Json(true);
            }
        }




        [HttpGet("AddCabinet", Name = "AddCabinet")]
        public JsonResult AddCabinet(int price, string code, string who, string type, string userId)
        {
            CabinetListUser model = new CabinetListUser();

            var date = DateTime.Now.ToString("dd-MM-yyyy");
            try
            {

                model.CabinetCode = code;
                model.CabinetOpPrice = price;
                model.CabinetOpTypes = type;
                model.CabinetWho = who;
                model.CabinetUserId = userId;
                model.Date = date;


                if (price != null && code != null && who != null && type != null)
                {
                    db.Add(model);
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
                Mutuals.monitizer.AddException(ex);

            }
            return Json(true);
        }

        [HttpGet("GetCabinet", Name = "GetCabinet")]
        public JsonResult GetCabinet(string code)
        {
            MemberSettingsViewModel model = new MemberSettingsViewModel();

            try
            {
                model.cabinetOperations = db.cabinetOperations.Where(x => x.CabinetCode == code).ToList();
                model.cabinetTypes = db.cabinetTypes.Where(x => x.CabinetTypes == (model.cabinetOperations[0].CabinetOpTypes).Trim()).ToList();
            }
            catch (Exception ex)
            {
                model = new MemberSettingsViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);
        }

        [HttpGet("ControlNickName", Name = "ControlNickName")]
        public JsonResult ControlNickName(string nickName)
        {
            MemberList model = new MemberList();

            try
            {
                if (nickName != "")
                {
                    model = db.memberLists.Where(x => x.NickName == nickName).FirstOrDefault();

                    if (model == null)
                    {
                        return Json(true);
                    }

                    else
                    {
                        return Json(model);
                    }
                }

                else
                {
                    return Json(false);
                }

            }

            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(false);

        }

        [HttpGet("ControlUserName", Name = "ControlUserName")]
        public JsonResult ControlUserName(string userName)
        {
            MemberList model = new MemberList();

            try
            {
                if (userName != "")
                {
                    model = db.memberLists.Where(x => x.UserName == userName).FirstOrDefault();

                    if (model == null)
                    {
                        return Json(true);
                    }

                    else
                    {
                        return Json(model);
                    }
                }

                else
                {
                    return Json(false);
                }

            }

            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(false);

        }

        [HttpGet("ControlMemberNumber", Name = "ControlMemberNumber")]
        public JsonResult ControlMemberNumber(int memberNumber)
        {
            MemberList model = new MemberList();

            try
            {
                if (memberNumber != null)
                {
                    model = db.memberLists.Where(x => x.MemberNumber == memberNumber).FirstOrDefault();

                    if (model == null)
                    {
                        return Json(true);
                    }

                    else
                    {
                        return Json(model);
                    }
                }

                else
                {
                    return Json(false);
                }

            }

            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(false);

        }

        [HttpGet("GetResTimeMulti", Name = "GetResTimeMulti")]
        public JsonResult GetResTimeMulti(int courtId, string dateInf, string date2, string day)
        {



            var court = db.courts.FirstOrDefault(x => x.CourtId == courtId);
            var startTime = Convert.ToDateTime(court.CourtStartTime);
            var finishTime = Convert.ToDateTime(court.CourtFinishTime);
            string period = court.CourtTimePeriod;
            var periodTime = Convert.ToDouble(period);
            var sTime = startTime.AddMinutes(-periodTime);
            var miles = (finishTime - sTime).TotalHours;

            DateTime startDate = Convert.ToDateTime(dateInf);
            DateTime finishDate = Convert.ToDateTime(date2);
            var days = day.Split(",");
            string dayy = "";



            List<string> dateList = new List<string>();
            List<string> dateList2 = new List<string>();

            for (DateTime date = startDate; date <= finishDate; date = date.AddDays(1))
            {
                int i = (int)date.DayOfWeek;


                switch (i)
                {
                    case 0:
                        dayy = "Pazar";
                        break;
                    case 1:
                        dayy = "Pazartesi";
                        break;
                    case 2:
                        dayy = "Salı";
                        break;
                    case 3:
                        dayy = "Çarşamba";
                        break;
                    case 4:
                        dayy = "Perşembe";
                        break;
                    case 5:
                        dayy = "Cuma";
                        break;
                    case 6:
                        dayy = "Cumartesi";
                        break;

                }

                dateList.Add(date.ToString("yyyy-MM-dd") + "," + dayy);

            }


            for (int z = 0; z < days.Count(); z++)
            {
                for (int d = 0; d < dateList.Count(); d++)
                {

                    if (dateList[d].Split(",")[1] == days[z])
                    {
                        dateList2.Add(dateList[d]);
                    }

                }
            }



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






            List<court_reserve> daily_reservations = new List<court_reserve>();
            List<int> asa = new List<int>();
            var daily = 0;


            for (int a = 0; a < dateList2.Count; a++)
            {
                var dateList2Split = dateList2[a].Split(",")[0];

                var model = db.reservations.Where(x => x.Court.CourtId == court.CourtId && x.ResDate == dateList2Split && x.CancelRes == false).ToList();

                var day_routine = res_Times;

                daily = Convert.ToInt32(day_routine.Count());

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
                        if (_isTaken == true)
                        {
                            asa.Add(day_routine[i].TimesId);
                        }


                        daily_reservations.Add(new court_reserve
                        {
                            start = day_routine[i].Times,
                            Period = day_routine[i].Period,
                            isTaken = _isTaken,
                            timeId = day_routine[i].TimesId
                        });


                    }


                }



                catch (Exception ex)
                {
                    model = new List<Reservation>();
                    Mutuals.monitizer.AddException(ex);
                }


            }

            for (int x = 0; x < daily_reservations.Count(); x++)
            {
                for (int y = 0; y < asa.Count(); y++)
                {
                    if (daily_reservations[x].timeId == asa[y])
                    {
                        daily_reservations[x].isTaken = true;

                    }
                }
            }
            var aasa = daily_reservations.Take(daily).ToList();


            return Json(aasa);

        }


        [HttpGet("AddMultiRes", Name = "AddMultiRes")]
        public JsonResult AddMultiRes(int CourtId, string DateInf, string Date2, string ResStartTime, string ResFinishTime, string userId, string UserName, string day)
        {
            Reservation model = new Reservation();
            CourtScaleList scale = new CourtScaleList();

            scale = db.courtScaleLists.FirstOrDefault(x => x.Code == UserName);

            if (scale == null)
            {
                return Json(false);
            }

            DateTime startDate = Convert.ToDateTime(DateInf);
            DateTime finishDate = Convert.ToDateTime(Date2);
            List<string> totalDate = new List<string>();


            string ResNowDate = DateTime.Now.ToString("yyyy-MM-dd");
            string ResTime = DateTime.Now.ToString("HH:mm:ss");

            Court court = new Court();
            court.CourtTimePeriod = db.courts.SingleOrDefault(x => x.CourtId == CourtId).CourtTimePeriod;
            court = db.courts.SingleOrDefault(x => x.CourtId == CourtId);


            var days = day.Split(",");
            string dayy = "";

            List<string> dateList = new List<string>();
            List<string> dateList2 = new List<string>();

            for (DateTime date = startDate; date <= finishDate; date = date.AddDays(1))
            {
                int i = (int)date.DayOfWeek;


                switch (i)
                {
                    case 0:
                        dayy = "Pazar";
                        break;
                    case 1:
                        dayy = "Pazartesi";
                        break;
                    case 2:
                        dayy = "Salı";
                        break;
                    case 3:
                        dayy = "Çarşamba";
                        break;
                    case 4:
                        dayy = "Perşembe";
                        break;
                    case 5:
                        dayy = "Cuma";
                        break;
                    case 6:
                        dayy = "Cumartesi";
                        break;

                }

                dateList.Add(date.ToString("yyyy-MM-dd") + "," + dayy);

            }


            for (int z = 0; z < days.Count(); z++)
            {
                for (int d = 0; d < dateList.Count(); d++)
                {

                    if (dateList[d].Split(",")[1] == days[z])
                    {
                        dateList2.Add(dateList[d].Split(",")[0]);
                    }

                }
            }



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
                        ResFinishTime = "0" + h + ":" + m + "0";
                    }
                    else
                    {
                        ResFinishTime = "0" + h + ":" + m;
                    }

                }
                else
                {
                    ResFinishTime = h + ":" + "00";
                }

            }

            try
            {

                for (int i = 0; i < dateList2.Count; i++)
                {
                    model = new Reservation();

                    model.ResDate = dateList2[i];
                    model.Court = court;
                    model.ResStartTime = ResStartTime;
                    model.ResFinishTime = ResFinishTime;
                    model.ResTime = ResTime;
                    model.ResNowDate = ResNowDate;
                    model.Price = 0;
                    model.PriceIds = "7";
                    model.doResUserId = userId;
                    model.NickName = UserName.Trim();


                    db.Add(model);
                    db.SaveChanges();

                }

                return Json(model);

            }

            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(false);

        }


        [HttpGet("GetResDetailSearch", Name = "GetResDetailSearch")]
        public JsonResult GetResDetailSearch(string whoRes, string startDate, string finishDate)
        {
            List<Reservation> model = new List<Reservation>();
            List<string> dateList = new List<string>();
            ArrayList resList = new ArrayList();

            DateTime startDate2 = Convert.ToDateTime(startDate);
            DateTime finishDate2 = Convert.ToDateTime(finishDate);

            try
            {
                for (DateTime date = startDate2; date <= finishDate2; date = date.AddDays(1))
                {

                    dateList.Add(date.ToString("yyyy-MM-dd"));

                }

                for (int i = 0; i < dateList.Count(); i++)
                {
                    model = db.reservations.Where(x => x.ResDate == dateList[i] && x.NickName == whoRes.Trim()).ToList();

                    if (model != null)
                    {
                        foreach (var item in model)
                        {
                            resList.Add(item);
                        }

                    }
                }

                if (resList.Count != 0)
                {
                    return Json(resList);
                }
            }
            catch (Exception ex)
            {
                model = new List<Reservation>();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(false);
        }

        [HttpGet("CancelAllRes", Name = "CancelAllRes")]
        public JsonResult CancelAllRes(string idLists)
        {
            Reservation model = new Reservation();

            try
            {
                if (idLists != null)
                {
                    var ids = idLists.Split(",");

                    if (ids == null)
                    {
                        return Json(false);

                    }

                    else
                    {
                        for (int i = 0; i < ids.Count(); i++)
                        {
                            model = db.reservations.Where(x => x.ResId == Convert.ToInt32(ids[i])).First();

                            if (model != null)
                            {
                                db.Remove(model);
                                db.SaveChanges();
                            }

                            return Json(model);
                        }
                    }
                }

                

            }

            catch (Exception ex)
            {
                model = new Reservation();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(false);
        }


        [HttpGet("AddDues", Name = "AddDues")]
        public JsonResult AddDues(int duesYear , string duesType , int duesPrice ,string explain)
        {
            AddDuesViewModel model = new AddDuesViewModel();

            model.memberLists = db.memberLists.Where(x=>x.Role == "ÜYE").ToList();

            try
            {
                if (duesType == "Yıllık Aidat Ücreti")
                {
                    if (model.memberLists != null)
                    {
                        for (int i = 0; i < model.memberLists.Count; i++)
                        {

                            model.memberDuesInfTable = new MemberDuesInfTable();

                            model.memberDuesInfTable.MemberId = model.memberLists[i].UserId;
                            model.memberDuesInfTable.MemberFullName = model.memberLists[i].FullName;
                            model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                            model.memberDuesInfTable.DuesType = duesType;
                            model.memberDuesInfTable.DuesPrice = duesPrice;
                            model.memberDuesInfTable.DuesYear = duesYear;
                            model.memberDuesInfTable.Explain = explain;

                            db.Add(model.memberDuesInfTable);
                            db.SaveChanges();

                        }

                        return Json(model.memberLists);
                    }
                }
          
            }

            catch (Exception ex)
            {
                model = new AddDuesViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(false);
        }

    }
}


