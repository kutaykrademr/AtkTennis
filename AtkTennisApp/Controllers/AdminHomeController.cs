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
        public HomeModelView GetHome(string date)
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
                model.courts = db.courts.ToList();
                model.courtPriceLists = db.courtPriceLists.ToList();
                model.reservations = db.reservations.Where(x => x.ResDate == date).ToList();
                model.reservationCancels = db.reservationCancels.Where(x => x.ResDate == date).ToList();
                model.reservationSettings = db.reservationSettings.ToList();
                model.memberLists = db.memberLists.ToList();
             


            }
            catch (Exception ex)
            {
                model = new HomeModelView();
                Mutuals.monitizer.AddException(ex);
            }


            return model;
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

        [HttpGet("NewRegister", Name = "NewRegister")]
        public AppIdentityUser NewRegister(string name, string nickName, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role)
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

        [HttpGet("NewReservationAdmin", Name = "NewReservationAdmin")]
        public JsonResult NewReservationAdmin(string ResDate, string ResTime, string ResStartTime, string ResFinishTime, string ResEvent, string UserId, int CourtId, string ResNowDate, int Price, string PriceIds, string UserName)
        {

            var model = new Reservation();
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
                        ResFinishTime = h + ":" + "00";
                }

            }
            else
            {
                h = h + 1;
                if (h < 10)
                {
                    ResFinishTime = "0" + h + ":" + m;
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
                    mem = db.memberLists.FirstOrDefault(x => x.UserName == UserName.Trim());

                }

                catch (Exception e)
                {
                    return Json("false");

                }
            }

            if (model == null)
            {
                //var memberPrice = db.memberLists.Where(x => x.UserId == UserId).FirstOrDefault().Price; // 1500

                //var resDebt = Price;

                try
                {
                    //if (memberPrice - resDebt >= 0)
                    //{
                    //    var newMemberPrice = memberPrice - resDebt;

                    //    mem.Price = newMemberPrice;
                    //    res.PriceInf = true;


                    res.NickName = mem.NickName;
                    res.Court = court;
                    res.ResFinishTime = ResFinishTime;
                    res.ResStartTime = ResStartTime;
                    res.ResDate = ResDate;
                    res.ResEvent = ResEvent;
                    res.ResTime = ResTime;
                    res.UserId = mem.UserId;
                    res.doResUserId = UserId;
                    res.ResNowDate = ResNowDate;
                    res.Price = Price;
                    res.PriceIds = PriceIds;



                    db.memberLists.Update(mem);
                    db.reservations.Add(res);
                    db.SaveChanges();
                    //}
                    //else
                    //{
                    //    return Json(false);
                    //}


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
        public JsonResult UpdateResAdmin(int id, string startTime, string finishTime, string time , int cId)

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
                            finishTime = h + ":" + "00";
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
    }
}


