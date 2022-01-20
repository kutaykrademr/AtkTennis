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
using Microsoft.AspNetCore.Authorization;
using static AtkTennisApp.Program;
using Helpers.Dto;
using Helpers;
using AtkTennisApp.AModels;

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
        ankarateniskulubudbContext atkcontext = new ankarateniskulubudbContext();

        [HttpGet("GetHome", Name = "GetHome")]
        public HomeModelView GetHome(string compId)
        {
            DateTime date1 = DateTime.Now;
            var today = date1.ToString("yyyy-MM-dd");

            HomeModelView model = new HomeModelView();


            try
            {
                model.TotalUserCount = userManager.Users.Count();
                model.TotalRoleCount = roleManager.Roles.Count();
                var b = db.reservations.Where(x => x.ResDate == today && x.CompanyId == compId).ToList();
                var a = db.reservations.Where(x => x.CompanyId == compId).ToList();
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
                model.memberDuesInf = db.memberDuesInfTables.ToList();
                model.reservationCancels = db.reservationCancels.ToList();



            }
            catch (Exception ex)
            {
                model = new HomeModelView();
                Mutuals.monitizer.AddException(ex);
            }


            return model;
        }

        [HttpGet("RegisterAll", Name = "RegisterAll")]
        public void RegisterAll()
        {
            foreach (var user in atkcontext.Uyes)
            {
                MemberList member =
                new MemberList
                {
                    FullName = user.Adi + " " + user.Soyadi,
                    MemberNumber = user.UyelikNumarasi,
                    Password = user.Sifre,
                    UserId = null,
                    Note = user.Aciklama,
                    BirthDate = Convert.ToString(user.DogumTarihi),
                    BirthPlace = user.DogumYeri,
                    ActPas = false,
                    whoPartner = false,
                    Role = "Üye",
                    NickName = user.Rumuz,
                    Job = user.Meslek,
                    City = "",
                    Condition = Convert.ToString(user.Durumu),
                    CompanyId = "192.168.250.12",
                    StartDate = Convert.ToString(user.UyelikBaslamaTarihi),
                    FinishDate = Convert.ToString(user.UyelikBitisTarihi),
                    FatherName = user.BabaAdi,
                    MotherName = user.AnneAdi,
                    Gender = "",
                    isPartner = false,
                    WebReservation = "1",
                    IdentityNumber = user.Tckimlik,
                    District = "",
                    memberType = user.Sekli,
                    Price = 0,
                    UserName = Convert.ToString(user.UyelikNumarasi),
                    DetailAddress = "",
                    Email = "",
                    EmailExp = "",
                    Phone = "",
                    PhoneExp = "",
                    Phone2 = "",
                    PartnerId = "",
                    Phone2Exp = "",
                    PrivRes = false,
                    ReferenceMember1 = "",
                    ReferenceMember2 = "",
                    Id = 1312,


                };


                if (member.memberType == 1)
                {
                    member.memberType = 0;
                }
                else
                {
                    member.memberType = 1;
                }


                if (user.Durumu == 1)
                {
                    member.ActPas = true;
                }


                NewRegister(member.Id, member.DetailAddress, member.FullName, member.UserName, member.StartDate.Split(" ")[0], member.FinishDate.Split(" ")[0], member.Condition, member.IdentityNumber, member.WebReservation, member.PhoneExp,
                    member.Phone2, member.Phone2Exp, member.Email, member.EmailExp, member.BirthPlace, member.ActPas, member.MotherName, member.FatherName, member.City, member.District, member.Job, member.Note, member.Phone, member.Password, member.BirthDate, member.Gender,
                    member.Role, member.NickName, member.MemberNumber, "", "", "", "", false, "", "", "", "", "", "", "", "", member.CompanyId, false, member.memberType);
            }
        }

        [HttpGet("TotalSystemUsers", Name = "TotalSystemUsers")]
        public List<MemberList> TotalSystemUsers()
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

            GeneralDebtViewModel model = new GeneralDebtViewModel();

            try
            {
                model.memberDebtTypes = db.memberDebtTypes.ToList();
                model.memberDuesInfTables = db.memberDuesInfTables.ToList();

                if (model.memberDebtTypes.Count != 0 || model.memberDuesInfTables.Count != 0)
                {
                    return Json(model);
                }

            }
            catch (Exception ex)
            {
                model = new GeneralDebtViewModel();
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
                model.cabinetOperations = db.cabinetOperations.ToList();
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
                model.resTimes = db.resTimes.OrderBy(x => x.ResTimes).ToList();
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

                if (model.memberLists != null)
                {
                    var userId = model.memberLists.UserId;

                    model.memberLists2 = db.memberLists.ToList();
                    model.AppIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();
                    model.AppIdentityRoles = (List<AppIdentityRole>)roleManager.Roles.ToList();
                    model.cabinetListUsers = db.cabinetListUsers.ToList();
                    model.cabinetTypes = db.cabinetTypes.ToList();
                    model.cabinetOperations = db.cabinetOperations.ToList();

                    model.memberDuesInfs = db.memberDuesInfTables.Where(x => x.MemberId == userId).ToList();
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



        [HttpGet("ReservationDebtList", Name = "ReservationDebtList")]
        public ReservationListViewModel ReservationDebtList()
        {

            ReservationListViewModel model = new ReservationListViewModel();

            try
            {
                model.reservations = db.reservations.ToList();
                model.reservationCancels = db.reservationCancels.ToList();
                model.memberLists = db.memberLists.ToList();
                model.courts = db.courts.ToList();

            }
            catch (Exception ex)
            {
                model = new ReservationListViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        public class CourtPriceListViewModel
        {
            public List<CourtPriceList> courtPriceLists { get; set; } = new List<CourtPriceList>();
            public List<CourtPriceList> priceLists { get; set; } = new List<CourtPriceList>();
            public List<string> priceListsId { get; set; } = new List<string>();

        }


        [HttpGet("GetPriceList", Name = "GetPriceList")]
        public CourtPriceListViewModel GetPriceList(int id, string time, string day, string month)
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

        public AppIdentityUser NewRegister(int Id, string detailAddress, string name, string username, string startDate, string finishDate, string condition,
            string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email,
            string emailExp, string birthPlace, bool ActPas, string motherName, string fatherName, string city, string district, string job,
            string note, string phone, string password, string birthdate, string gender, string role, string nickName,
            int memberNumber, string partnerBirthdate, string partnerIdNumber, string partnerPhone, string partnerName,
            bool isPartner, string refmem1, string refmem2, string nickName2, string username2, string startDate2,
            string finishDate2, string memberNumber2, string password2, string compId, bool boss, int memType)
        {
            MemberList model2 = new MemberList();
            MemberList model3 = new MemberList();

            var Role = new AppIdentityRole();
            var user = new AppIdentityUser();
            var user2 = new AppIdentityUser();
            var isUser = db.memberLists.Where(x => x.UserName == username).FirstOrDefault();
            var isUser2 = db.memberLists.Where(x => x.NickName == nickName).FirstOrDefault();
            try
            {
                if (isUser != null)
                {
                    user.FullName = "Mn";

                    return user;
                }

                else if (isUser2 != null)
                {
                    user.FullName = "Nn";
                    return user;
                }

                var roles = role.Split(",");

                if (roles.Length > 1)
                {
                    for (int i = 0; i < roles.Length; i++)
                    {
                        if (roles[i] != "")
                        {
                            if (!roleManager.RoleExistsAsync(roles[i]).Result)
                            {

                                Role.Name = roles[i];
                                Role.Description = "Can Perform Crud Operations";
                                var roleResult = roleManager.CreateAsync(Role).Result;
                            }
                        }

                    }
                }

                user.UserName = username;
                user.Email = email;
                user.FullName = name;
                user.BirthDate = birthdate;
                user.PhoneNumber = phone;

                var result = userManager.CreateAsync(user, password).Result;


                if (isPartner && result.Succeeded)
                {
                    user2.UserName = username2;
                    user2.FullName = partnerName;
                    user2.BirthDate = partnerBirthdate;
                    user2.PhoneNumber = partnerPhone;
                    //Role.Name = role;

                    var result2 = userManager.CreateAsync(user2, password).Result;

                    if (result2.Succeeded)
                    {
                        model3.memberType = 2;
                        model3.CompanyId = compId;
                        model3.UserId = user2.Id;
                        model3.IdentityNumber = partnerIdNumber;
                        model3.NickName = nickName2;
                        model3.UserName = username2;
                        model3.FullName = partnerName;
                        model3.StartDate = startDate2;
                        model3.FinishDate = finishDate2;
                        model3.whoPartner = true;
                        model3.Phone = partnerPhone;
                        model3.PhoneExp = "Kendi";
                        model3.BirthDate = partnerBirthdate;
                        model3.Role = role;
                        if (role.Contains(","))
                        {
                            model3.Role = role.Remove(role.Length - 1);
                        }
                        model3.MemberNumber = Convert.ToInt32(memberNumber2);
                        model3.WebReservation = webReservation;
                        model3.Password = password2;
                        model3.isPartner = false;
                        model3.PartnerId = user.Id;
                        model3.ActPas = true;


                        userManager.AddToRoleAsync(user2, role).Wait();
                        db.Add(model3);
                        db.SaveChanges();
                    }

                }

                var id = user.Id;

                if (result.Succeeded)
                {
                    if (isPartner == true)
                    {
                        model2.isPartner = isPartner;
                        model2.PartnerId = user2.Id;
                    }


                    model2.memberType = memType;
                    model2.CompanyId = compId;
                    model2.DetailAddress = detailAddress;
                    model2.ReferenceMember1 = refmem1;
                    model2.ReferenceMember2 = refmem2;
                    model2.MemberNumber = memberNumber;
                    model2.UserId = id;
                    model2.FullName = name;
                    model2.NickName = nickName;
                    model2.Gender = gender;
                    model2.UserName = username;
                    model2.StartDate = startDate;
                    model2.FinishDate = finishDate;
                    model2.Role = role;
                    if (role.Contains(","))
                    {
                        model2.Role = role.Remove(role.Length - 1);
                    }
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

                    if (Id == 1312)
                    {
                        model2.ActPas = ActPas;
                    }
                    else
                        model2.ActPas = true;
                    model2.Password = password;

                    if (roles.Length > 1)
                    {
                        for (int i = 0; i < roles.Length; i++)
                        {
                            if (roles[i] != "")
                            {
                                userManager.AddToRoleAsync(user, roles[i]).Wait();
                            }

                        }
                    }
                    else
                    {
                        userManager.AddToRoleAsync(user, role).Wait();
                    }

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
        public JsonResult NewReservationAdmin(string ResDate, string CompanyId, string ResTime, string ResStartTime, string ResFinishTime, string ResEvent, string UserId, int CourtId, string ResNowDate, int Price, string PriceIds, string UserName, bool PrivRes)
        {

            var model = new Reservation();
            var scale = new CourtScaleList();

            Reservation res = new Reservation();
            Court court = new Court();
            MemberList mem = new MemberList();
            ReservationTotal model4 = new ReservationTotal();
            MemberCanDebt canDebt = new MemberCanDebt();

            court.CourtTimePeriod = db.courts.SingleOrDefault(x => x.CourtId == CourtId && x.CompanyId == CompanyId).CourtTimePeriod;
            canDebt = db.memberCanDebts.Where(x => x.CompanyId == CompanyId).FirstOrDefault();

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
                    if (m == 00)
                    {
                        ResFinishTime = h + ":" + m + "0";
                    }
                    else
                    {
                        ResFinishTime = h + ":" + m;
                    }

                }

            }

            var splitTime = Convert.ToInt32(ResStartTime.Split(":")[1]);
            var splitTime2 = Convert.ToInt32(ResFinishTime.Split(":")[1]);
            var timeX = splitTime2 - splitTime;

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
                    mem = db.memberLists.FirstOrDefault(x => x.NickName == UserName.Trim() && x.CompanyId == CompanyId);
                    scale = db.courtScaleLists.FirstOrDefault(x => x.Code == UserName && x.CompanyId == CompanyId);

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
                            res.RoleName = "Üye";
                            //res.RoleName = mem.Role.Trim();
                            res.CompanyId = CompanyId;

                            if (db.memberLists.Where(x => x.UserId == UserId && x.CompanyId == CompanyId).FirstOrDefault().Role == "Sekreterya")
                            {
                                SecretaryOp sop = new SecretaryOp();

                                sop.AdminId = UserId;
                                sop.CompId = CompanyId;
                                sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                                sop.Text = mem.MemberNumber + mem.NickName + mem.FullName + " " + "Rezervasyon Eklendi.";

                                db.Add(sop);

                            }

                            db.memberLists.Update(mem);
                            db.reservations.Add(res);
                            db.SaveChanges();

                        }

                        else
                        {
                            if (canDebt.CanDebt == false)
                            {
                                return Json(false);
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
                                res.RoleName = "Üye";
                                //res.RoleName = mem.Role.Trim();
                                res.CompanyId = CompanyId;

                                if (db.memberLists.Where(x=>x.UserId == UserId && x.CompanyId == CompanyId).FirstOrDefault().Role == "Sekreterya")
                                {
                                    SecretaryOp sop = new SecretaryOp();

                                    sop.AdminId = UserId;
                                    sop.CompId = CompanyId;
                                    sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                                    sop.Text = mem.MemberNumber + mem.NickName + mem.FullName + " " +"Rezervasyon Eklendi.";

                                    db.Add(sop);
                                    
                                }

                                db.reservations.Add(res);
                                db.SaveChanges();

                            }

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
                            res.CompanyId = CompanyId;


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
                    if (mem == null)
                    {
                        model2.resSchemaModal.FullName = model.reservations.NickName;
                        model2.resSchemaModal.NickName = model.reservations.NickName;
                    }

                    else
                    {
                        model2.resSchemaModal.FullName = mem.FullName;
                        model2.resSchemaModal.NickName = mem.NickName;
                    }

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
        public JsonResult CancelRes(int id, string userId, bool procedure, string cancelReasons, string compId)

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

                if (mem != null && model != null)
                {
                    if (procedure == true && model.PriceInf == true)
                    {
                        var memberPrice = mem.Price;
                        var newPrice = memberPrice + model.Price;

                        mem.Price = newPrice;

                        db.Update(mem);
                        db.SaveChanges();
                    }
                }


                if (model != null)
                {
                    model2.CompanyId = compId;
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

                    if (db.memberLists.Where(x => x.UserId == userId && x.CompanyId == compId).FirstOrDefault().Role == "Sekreterya")
                    {
                        SecretaryOp sop = new SecretaryOp();

                        sop.AdminId = userId;
                        sop.CompId = compId;
                        sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                        sop.Text = mem.MemberNumber + mem.NickName + mem.FullName + " " + "Rezervasyon İptal Edildi.";

                        db.Add(sop);

                    }

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
        public JsonResult UpdateResAdmin(int id, string startTime, string finishTime, string time, int cId , string drg)

        {
            Reservation model = new Reservation();
            Court court = new Court();
            SecretaryOp sop = new SecretaryOp();
            try
            {
                model = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
                court = db.courts.SingleOrDefault(x => x.CourtId == cId);
                court.CourtTimePeriod = db.courts.SingleOrDefault(x => x.CourtId == cId).CourtTimePeriod;


                var x = finishTime.Split(":");
                var h = Convert.ToInt32(x[0]);
                var m = Convert.ToInt32(x[1]);
                var per = Convert.ToInt16(court.CourtTimePeriod);
               
                if (drg != "drg")
                {
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
                }
                else
                {
              
                    h = h + 1;

                    if (h < 10)
                    {
                        if (m == 0)
                        {
                            finishTime = "0" + h + ":" + m + "0";
                        }
                        else
                        {
                            finishTime = "0" + h + ":" + m ;
                        }
                        
                    }
                    else
                    {
                        if (m == 0)
                        {
                            finishTime = h + ":" + m + "0";
                        }
                        else
                        {
                            finishTime = h + ":" + m;
                        }
                       
                    }
                }

                sop.Text = model.NickName + model.ResStartTime + model.ResFinishTime + " " + "Rezervasyon Güncellendi.";
              
                model.Court = court;
                model.ResStartTime = startTime;
                model.ResFinishTime = finishTime;
                model.ResDate = time;
             
                if (db.memberLists.Where(x => x.UserId == model.doResUserId && x.CompanyId == model.CompanyId).FirstOrDefault().Role == "Sekreterya")
                {
                    

                    sop.AdminId = model.doResUserId;
                    sop.CompId = model.CompanyId;
                    sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
              
                    db.Add(sop);

                }

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
        public async Task<JsonResult> UpdateMemberList(string id, string detailAddress, string actPass, string checkpass, string name, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role)
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

                if (model2 != null)
                {
                    model2.BirthDate = birthdate;
                    model2.BirthPlace = birthPlace;
                    model2.City = city;
                    model2.Condition = condition;
                    model2.District = district;
                    model2.Email = email;
                    model2.ActPas = false;
                    if (actPass == "true")
                    {
                        model2.ActPas = true;
                    }
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
                    model2.Role = role.Remove(role.Length - 1);
                    model2.DetailAddress = detailAddress;
                }


                //Ağlama 

                var user = await userManager.FindByIdAsync(id);
                var role_to_remove = await userManager.GetRolesAsync(user);
                var result = await userManager.RemoveFromRoleAsync(user, role_to_remove[0]);
                var newRoles = role.Split(",");
                for (int i = 0; i < newRoles.Length; i++)
                {
                    if (newRoles[i] != "")
                    {
                        var newRole = await userManager.AddToRoleAsync(user, newRoles[i]);
                    }

                }


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


                    //if (user2 != null)
                    //{
                    //    user2.ActPas = true;

                    db.Remove(user2);
                    db.SaveChanges();

                    return Json(user2);
                    //}
                }

                catch (Exception ex)
                {
                    Mutuals.monitizer.AddException(ex);

                }
                return Json(true);
            }
        }

        [HttpGet("AddPrice", Name = "AddPrice")]
        public JsonResult AddPrice(string id, int money ,string adminId , string compId)
        {
            MemberList model = new MemberList();
            BalanceOpModel model2 = new BalanceOpModel();

            model = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();
            
            if (model != null)
            {
                try
                {
                    var currentPrice = model.Price;
                    var newPrice = currentPrice + money;

                    model.Price = newPrice;


                    db.Update(model);

                    model2.Date = Convert.ToString(DateTime.Now);
                    model2.MemberId = id;
                    model2.Price = Convert.ToString(money);
                    model2.AdminId = adminId;
                    model2.CompanyId = compId;

                    if (model2.Price == "0")
                    {
                        model2.Price = Convert.ToString(money);
                    }
                    else
                    {
                        model2.Price = model2.Price +  Convert.ToString(money);
                    }

                    db.Add(model2);

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

        public class CabinetandDuesTable
        {
            public CabinetListUser cabinetListUser { get; set; } = new CabinetListUser();
            public MemberDuesInfTable memberDuesInfTable { get; set; } = new MemberDuesInfTable();
            public MemberList memberList { get; set; } = new MemberList();

        }

        [HttpGet("AddCabinet", Name = "AddCabinet")]
        public JsonResult AddCabinet(int price, string code, string who, string type, string userId , string compId)
        {
            CabinetandDuesTable model = new CabinetandDuesTable();

            var date = DateTime.Now.ToString("dd-MM-yyyy");
            try
            {
                model.cabinetListUser.CabinetCode = code;
                model.cabinetListUser.CabinetOpPrice = price;
                model.cabinetListUser.CabinetOpTypes = type;
                model.cabinetListUser.CabinetWho = who;
                model.cabinetListUser.CabinetUserId = userId;
                model.cabinetListUser.Date = date;
                model.cabinetListUser.CabinetCondition = true;
                model.cabinetListUser.CompanyId = compId;

                model.memberDuesInfTable.DuesInfType = true;
                model.memberDuesInfTable.DuesPrice = price;
                model.memberDuesInfTable.RemainingPrice = price;
                model.memberDuesInfTable.DuesType = "Dolap Tahsilat Ücreti";
                model.memberDuesInfTable.Explain = "Dolap Tahsilat Ücreti";
                model.memberDuesInfTable.MemberId = userId;
                model.memberDuesInfTable.MemberFullName = db.memberLists.Where(x => x.UserId == model.memberDuesInfTable.MemberId).FirstOrDefault().FullName;
                model.memberDuesInfTable.Date = date;
                model.memberDuesInfTable.DuesYear = Convert.ToInt16(date.Split("-")[2]);
                model.memberDuesInfTable.CompanyId = compId;

                if (price != 0 && code != null && who != null && type != null)
                {
                    db.Add(model.memberDuesInfTable);
                    db.Add(model.cabinetListUser);
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
        public JsonResult AddMultiRes(int CourtId, string compId, string DateInf, string Date2, string ResStartTime, string ResFinishTime, string userId, string UserName, string day)
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
                    model.CompanyId = compId;


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
            List<Court> model2 = new List<Court>();
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
                    model2 = db.courts.ToList();
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
                            if (ids[i] != "")
                            {
                                model = db.reservations.Where(x => x.ResId == Convert.ToInt32(ids[i])).First();

                                if (model != null)
                                {
                                    db.Remove(model);
                                    db.SaveChanges();
                                }
                                else
                                {

                                }
                            }

                        }

                        return Json(model);
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
        public AddDuesViewModel AddDues(int duesYear, string duesType, int duesPrice, string explain, string compId)
        {
            AddDuesViewModel model = new AddDuesViewModel();

            model.memberLists = db.memberLists.Where(x => x.CompanyId == compId && x.Role.Contains("Üye")).ToList();
            model.memberDuesInfTable = db.memberDuesInfTables.Where(x => x.DuesType == duesType.Trim() && x.DuesYear == duesYear && x.CompanyId == compId).FirstOrDefault();

            try
            {
                if (model.memberDuesInfTable != null)
                {
                    return new AddDuesViewModel();
                }
                else
                {

                    for (int i = 0; i < model.memberLists.Count; i++)
                    {
                        if (duesType == "Yıllık Eş Aidat Ücreti")
                        {
                            if (model.memberLists[i].isPartner == true && model.memberLists[i].whoPartner == false && model.memberLists[i].ActPas == true)
                            {
                                model.memberDuesInfTable = new MemberDuesInfTable();
                                model.memberDuesInfTable.CompanyId = compId;
                                model.memberDuesInfTable.MemberId = model.memberLists[i].UserId;
                                model.memberDuesInfTable.MemberFullName = model.memberLists[i].FullName;
                                model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                                model.memberDuesInfTable.DuesType = duesType;
                                model.memberDuesInfTable.DuesPrice = duesPrice;
                                model.memberDuesInfTable.RemainingPrice = duesPrice;
                                model.memberDuesInfTable.DuesYear = duesYear;
                                model.memberDuesInfTable.Explain = explain;

                                db.Add(model.memberDuesInfTable);

                            }
                        }

                        else if (duesType == "Yıllık Aidat Ücreti")
                        {

                            if (model.memberLists[i].whoPartner == false && model.memberLists[i].ActPas == true && model.memberLists[i].memberType == 0)
                            {

                                model.memberDuesInfTable = new MemberDuesInfTable();
                                model.memberDuesInfTable.CompanyId = compId;
                                model.memberDuesInfTable.MemberId = model.memberLists[i].UserId;
                                model.memberDuesInfTable.MemberFullName = model.memberLists[i].FullName;
                                model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                                model.memberDuesInfTable.DuesType = duesType;
                                model.memberDuesInfTable.DuesPrice = duesPrice;
                                model.memberDuesInfTable.RemainingPrice = duesPrice;
                                model.memberDuesInfTable.DuesYear = duesYear;
                                model.memberDuesInfTable.Explain = explain;

                                db.Add(model.memberDuesInfTable);

                            }
                        }
                        else if (duesType == "Geçici Üye Ücreti")
                        {
                            if (model.memberLists[i].whoPartner == false && model.memberLists[i].ActPas == true && model.memberLists[i].memberType == 1)
                            {

                                model.memberDuesInfTable = new MemberDuesInfTable();
                                model.memberDuesInfTable.CompanyId = compId;
                                model.memberDuesInfTable.MemberId = model.memberLists[i].UserId;
                                model.memberDuesInfTable.MemberFullName = model.memberLists[i].FullName;
                                model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                                model.memberDuesInfTable.DuesType = duesType;
                                model.memberDuesInfTable.DuesPrice = duesPrice;
                                model.memberDuesInfTable.RemainingPrice = duesPrice;
                                model.memberDuesInfTable.DuesYear = duesYear;
                                model.memberDuesInfTable.Explain = explain;

                                db.Add(model.memberDuesInfTable);

                            }
                        }
                        else if (duesType == "Ek Ücret")
                        {
                            if (model.memberLists[i].whoPartner == false && model.memberLists[i].ActPas == true && model.memberLists[i].memberType == 0)
                            {

                                model.memberDuesInfTable = new MemberDuesInfTable();
                                model.memberDuesInfTable.CompanyId = compId;
                                model.memberDuesInfTable.MemberId = model.memberLists[i].UserId;
                                model.memberDuesInfTable.MemberFullName = model.memberLists[i].FullName;
                                model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                                model.memberDuesInfTable.DuesType = duesType;
                                model.memberDuesInfTable.DuesPrice = duesPrice;
                                model.memberDuesInfTable.RemainingPrice = duesPrice;
                                model.memberDuesInfTable.DuesYear = duesYear;
                                model.memberDuesInfTable.Explain = explain;

                                db.Add(model.memberDuesInfTable);

                            }
                        }
                        else
                        {
                            return new AddDuesViewModel(); ;
                        }

                    }
                    db.SaveChanges();
                    return model;
                }

            }

            catch (Exception ex)
            {
                model = new AddDuesViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return new AddDuesViewModel();
        }

        [HttpGet("AddDuesSingle", Name = "AddDuesSingle")]
        public AddDuesViewModel AddDuesSingle(int duesYear, string compId, string duesType, int duesPrice, string explain, int memNum)
        {
            AddDuesViewModel model = new AddDuesViewModel();

            model.memberLists = db.memberLists.Where(x => x.MemberNumber == memNum && x.CompanyId == compId).ToList();
            model.memberDuesInfTable = db.memberDuesInfTables.Where(x => x.DuesType == duesType.Trim() && x.DuesYear == duesYear && x.CompanyId == compId).FirstOrDefault();

            try
            {

                if (duesType == "Yıllık Eş Aidat Ücreti")
                {
                    if (model.memberLists[0].isPartner == true && model.memberLists[0].ActPas == true && model.memberLists[0].whoPartner == false)
                    {
                        model.memberDuesInfTable = new MemberDuesInfTable();
                        model.memberDuesInfTable.CompanyId = compId;
                        model.memberDuesInfTable.MemberId = model.memberLists[0].UserId;
                        model.memberDuesInfTable.MemberFullName = model.memberLists[0].FullName;
                        model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                        model.memberDuesInfTable.DuesType = duesType;
                        model.memberDuesInfTable.DuesPrice = duesPrice;
                        model.memberDuesInfTable.RemainingPrice = duesPrice;
                        model.memberDuesInfTable.DuesYear = duesYear;
                        model.memberDuesInfTable.Explain = explain;



                    }
                }

                else if (duesType == "Yıllık Aidat Ücreti")

                {
                    if (model.memberLists[0].whoPartner == false && model.memberLists[0].ActPas == true && model.memberLists[0].memberType == 0)
                    {
                        model.memberDuesInfTable = new MemberDuesInfTable();
                        model.memberDuesInfTable.MemberId = model.memberLists[0].UserId;
                        model.memberDuesInfTable.MemberFullName = model.memberLists[0].FullName;
                        model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                        model.memberDuesInfTable.DuesType = duesType;
                        model.memberDuesInfTable.DuesPrice = duesPrice;
                        model.memberDuesInfTable.RemainingPrice = duesPrice;
                        model.memberDuesInfTable.DuesYear = duesYear;
                        model.memberDuesInfTable.Explain = explain;
                        model.memberDuesInfTable.CompanyId = compId;

                    }
                }

                else if (duesType == "Geçici Üye Ücreti")
                {
                    if (model.memberLists[0].whoPartner == false && model.memberLists[0].ActPas == true )
                    {

                        model.memberDuesInfTable = new MemberDuesInfTable();
                        model.memberDuesInfTable.MemberId = model.memberLists[0].UserId;
                        model.memberDuesInfTable.MemberFullName = model.memberLists[0].FullName;
                        model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                        model.memberDuesInfTable.DuesType = duesType;
                        model.memberDuesInfTable.DuesPrice = duesPrice;
                        model.memberDuesInfTable.RemainingPrice = duesPrice;
                        model.memberDuesInfTable.DuesYear = duesYear;
                        model.memberDuesInfTable.Explain = explain;
                        model.memberDuesInfTable.CompanyId = compId;

                    }
                }

                else if (duesType == "Giriş Ücreti")
                {
                    if (model.memberLists[0].whoPartner == false && model.memberLists[0].ActPas == true && model.memberLists[0].memberType == 0)
                    {

                        model.memberDuesInfTable = new MemberDuesInfTable();
                        model.memberDuesInfTable.MemberId = model.memberLists[0].UserId;
                        model.memberDuesInfTable.MemberFullName = model.memberLists[0].FullName;
                        model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                        model.memberDuesInfTable.DuesType = duesType;
                        model.memberDuesInfTable.DuesPrice = duesPrice;
                        model.memberDuesInfTable.RemainingPrice = duesPrice;
                        model.memberDuesInfTable.DuesYear = duesYear;
                        model.memberDuesInfTable.Explain = explain;
                        model.memberDuesInfTable.CompanyId = compId;

                    }
                }

                else
                {
                    return new AddDuesViewModel();
                }

                if (model != null)
                {
                    db.Add(model.memberDuesInfTable);
                    db.SaveChanges();
                }

                return model;
            }

            catch (Exception ex)
            {
                model = new AddDuesViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return new AddDuesViewModel();
        }

        [HttpGet("AddGenCabinetDebt", Name = "AddGenCabinetDebt")]
        public AddDuesViewModel AddGenCabinetDebt(int cabinetDuesYear, string cabinetType, string cabinetExplain, string compId)
        {
            AddDuesViewModel model = new AddDuesViewModel();

            model.memberLists = db.memberLists.ToList();
            var cabinetList = db.cabinetListUsers.ToList();
            model.memberDuesInfTable = db.memberDuesInfTables.Where(x => x.DuesYear == cabinetDuesYear && x.DuesType == cabinetType.Trim()).FirstOrDefault();

            try
            {
                if (model.memberDuesInfTable != null)
                {
                    return new AddDuesViewModel();
                }

                for (int i = 0; i < cabinetList.Count(); i++)
                {
                    var mem = db.memberLists.Where(x => x.UserId == cabinetList[i].CabinetUserId).FirstOrDefault();
                    var typePrice = db.cabinetTypes.FirstOrDefault(x => x.CabinetTypes == cabinetList[i].CabinetOpTypes).CabinetTypesPrice;

                    if (mem != null)
                    {
                        model.memberDuesInfTable = new MemberDuesInfTable();

                        model.memberDuesInfTable.CompanyId = compId;
                        model.memberDuesInfTable.MemberId = cabinetList[i].CabinetUserId;
                        model.memberDuesInfTable.DuesYear = cabinetDuesYear;
                        model.memberDuesInfTable.DuesPrice = typePrice;
                        model.memberDuesInfTable.RemainingPrice = typePrice;
                        model.memberDuesInfTable.DuesType = cabinetType;
                        model.memberDuesInfTable.Explain = cabinetExplain;
                        model.memberDuesInfTable.MemberFullName = mem.FullName;
                        model.memberDuesInfTable.Date = DateTime.Now.ToString("dd-MM-yyyy");
                        model.memberDuesInfTable.DuesInfType = true;

                        db.Add(model.memberDuesInfTable);
                        db.SaveChanges();
                    }
                    else
                    {
                        return new AddDuesViewModel();
                    }

                }
                return model;
            }

            catch (Exception ex)
            {
                model = new AddDuesViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return new AddDuesViewModel();
        }

        [HttpGet("GetMemberCabinetDetail", Name = "GetMemberCabinetDetail")]
        public AddDuesViewModel GetMemberCabinetDetail(string id)
        {
            AddDuesViewModel model = new AddDuesViewModel();


            model.cabinetListUsers = db.cabinetListUsers.Where(x => x.CabinetUserId == id).ToList();
            model.memberDuesInfs = db.memberDuesInfTables.Where(x => x.MemberId == id).ToList();


            try
            {
                return model;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new AddDuesViewModel();
        }

        [HttpGet("DuesDebtList", Name = "DuesDebtList")]
        public GeneralDebtViewModel DuesDebtList()
        {
            GeneralDebtViewModel model = new GeneralDebtViewModel();

            model.memberDuesInfTables = db.memberDuesInfTables.ToList();
            model.memberLists = db.memberLists.ToList();

            try
            {
                return model;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new GeneralDebtViewModel();
        }

        [HttpGet("GetDuesDebtMember", Name = "GetDuesDebtMember")]
        public GeneralDebtViewModel GetDuesDebtMember(string id)
        {
            GeneralDebtViewModel model = new GeneralDebtViewModel();

            model.memberDuesInfTables = db.memberDuesInfTables.Where(x => x.MemberId == id).ToList();
            model.memberLists = db.memberLists.Where(x => x.UserId == id).ToList();
            model.cabinetListUsers = db.cabinetListUsers.Where(x => x.CabinetUserId == id).ToList();


            try
            {
                return model;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new GeneralDebtViewModel();
        }

        [HttpGet("GetResUser", Name = "GetResUser")]
        public HomeModelView GetResUser(string id)
        {
            HomeModelView model = new HomeModelView();

            model.reservations = db.reservations.Where(x => x.UserId == id).ToList();
            model.reservationCancels = db.reservationCancels.Where(x => x.UserId == id).ToList();
            model.memberLists = db.memberLists.Where(x => x.UserId == id).ToList();
            model.courts = db.courts.ToList();

            try
            {
                return model;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new HomeModelView();
        }

        [HttpGet("GetReserInf", Name = "GetReserInf")]
        public ResandResCancelViewModel GetReserInf(int id)
        {
            ResandResCancelViewModel model = new ResandResCancelViewModel();

            model.reservation = db.reservations.Where(x => x.ResId == id).FirstOrDefault();
            model.reservationCancel = db.reservationCancels.Where(x => x.ResId == id).FirstOrDefault();

            try
            {
                return model;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new ResandResCancelViewModel();
        }

        public class GetPaidDuesViewModel
        {
            public MemberDuesInfTable memberDuesInf { get; set; }
            public List<AllGetPaidLogs> AllGetPaidLogs { get; set; } = new List<AllGetPaidLogs>();
        }

        [HttpGet("GetDuesInf", Name = "GetDuesInf")]
        public GetPaidDuesViewModel GetDuesInf(int id)
        {
            GetPaidDuesViewModel model = new GetPaidDuesViewModel();

            model.memberDuesInf = db.memberDuesInfTables.Where(x => x.MemberDuesInfTableId == id).FirstOrDefault();
            model.AllGetPaidLogs = db.allGetPaidLogs.Where(x => x.RefId == id).ToList();


            try
            {
                return model;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new GetPaidDuesViewModel();
        }

        [HttpGet("GetCabinetInf", Name = "GetCabinetInf")]
        public GetPaidDuesViewModel GetCabinetInf(int id)
        {
            GetPaidDuesViewModel model = new GetPaidDuesViewModel();



            model.memberDuesInf = db.memberDuesInfTables.Where(x => x.MemberDuesInfTableId == id).FirstOrDefault();
            model.AllGetPaidLogs = db.allGetPaidLogs.Where(x => x.RefId == id).ToList();


            try
            {
                return model;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new GetPaidDuesViewModel();
        }

        [HttpGet("GetResCancelList", Name = "GetResCancelList")]
        public ReservationListViewModel GetResCancelList(string date)
        {
            ReservationListViewModel model = new ReservationListViewModel();


            model.reservations = db.reservations.Where(x => x.ResDate == date).ToList();
            model.reservationCancels = db.reservationCancels.Where(x => x.ResDate == date).ToList();
            model.memberLists = db.memberLists.ToList();
            model.courts = db.courts.ToList();


            try
            {
                return model;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new ReservationListViewModel();
        }

        [HttpGet("AddPartner", Name = "AddPartner")]
        public AppIdentityUser AddPartner(string id, string partnerBirthdate, string partnerIdNumber, string partnerPhone, string partnerName,
          bool isPartner, string nickName2, string username2, string startDate2,
          string finishDate2, string memberNumber2, string password2, string webReservation)
        {
            MemberList model2 = new MemberList();
            var x = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();
            var Role = new AppIdentityRole();
            var user = new AppIdentityUser();


            try
            {
                user.UserName = username2;
                user.Email = "@gmail.com";
                user.FullName = partnerName;
                user.BirthDate = partnerBirthdate;
                user.PhoneNumber = partnerPhone;
                Role.Name = "Üye";

                var result = userManager.CreateAsync(user, password2).Result;

                if (result.Succeeded)
                {
                    model2.Role = Role.Name;
                    model2.UserId = user.Id;
                    model2.PartnerId = id;
                    model2.FullName = partnerName;
                    model2.NickName = nickName2;
                    model2.UserName = username2;
                    model2.StartDate = startDate2;
                    model2.FinishDate = finishDate2;
                    model2.MemberNumber = Convert.ToInt32(memberNumber2);
                    model2.WebReservation = "1";
                    model2.IdentityNumber = partnerIdNumber;
                    model2.Phone = partnerPhone;
                    model2.PhoneExp = "Kendi";
                    model2.BirthDate = partnerBirthdate;
                    model2.Password = password2;

                    x.PartnerId = user.Id;
                    x.isPartner = true;

                    userManager.AddToRoleAsync(user, Role.Name).Wait();
                    db.Add(model2);
                    db.Update(x);

                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);
            }

            return user;
        }

        [HttpGet("GetPaid", Name = "GetPaid")]
        public AllGetPaidLogs GetPaid(string userId, int refId, int refType,
            string doUserId, int price, int paidPrice, int remainingPrice,
            int paymentType, int receiptNo, string receiptDate, string explain, string compId)
        {
            AllPaidLogsViewModel model = new AllPaidLogsViewModel();
            SecretaryOp sop = new SecretaryOp();
            var mem = db.memberLists.Where(x => x.UserId == userId).FirstOrDefault();

            if (refType == 1)
            {
                model.reservation = db.reservations.Where(x => x.ResId == refId).FirstOrDefault();

                if (model.reservation != null)
                {
                    if (db.memberLists.Where(x => x.UserId == doUserId && x.CompanyId == compId).FirstOrDefault().Role == "Sekreterya")
                    {
                      

                        sop.AdminId = doUserId;
                        sop.CompId = compId;
                        sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                        sop.Text = mem.FullName + mem.MemberNumber + "," + paidPrice + "tl rezervasyon ödemesi alındı. " + remainingPrice + "tl kaldı.";

                        db.Add(sop);

                    }

                    model.reservation.Price = 0;
                    model.reservation.PriceInf = true;
                    model.reservation.CompanyId = compId;

                    db.Update(model.reservation);
                }

                else
                {
                    model.reservationCancel = db.reservationCancels.Where(x => x.ResId == refId).FirstOrDefault();
                    model.reservationCancel.Price = 0;
                    model.reservationCancel.PriceInf = true;

                    if (db.memberLists.Where(x => x.UserId == doUserId && x.CompanyId == compId).FirstOrDefault().Role == "Sekreterya")
                    {


                        sop.AdminId = doUserId;
                        sop.CompId = compId;
                        sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                        sop.Text = mem.FullName + mem.MemberNumber + "," + paidPrice + "tl rezervasyon iptal ödemesi alındı. " + remainingPrice + "tl kaldı.";

                        db.Add(sop);

                    }

                    db.Update(model.reservationCancel);
                }

            }

            else if (refType == 2)

            {
                model.memberDuesInf = db.memberDuesInfTables.Where(x => x.MemberDuesInfTableId == refId).FirstOrDefault();

                if (model.memberDuesInf != null)
                {

                    if (model.memberDuesInf.RemainingPrice - paidPrice == 0)
                    {
                        model.memberDuesInf.PaidPrice = model.memberDuesInf.PaidPrice + paidPrice;
                        model.memberDuesInf.RemainingPrice = remainingPrice;
                        model.memberDuesInf.PriceCondition = true;

                        if (db.memberLists.Where(x => x.UserId == doUserId && x.CompanyId == compId).FirstOrDefault().Role == "Sekreterya")
                        {


                            sop.AdminId = doUserId;
                            sop.CompId = compId;
                            sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                            sop.Text = mem.FullName + mem.MemberNumber + "," + paidPrice + "tl aidat ödemesi alındı. " + remainingPrice + "tl kaldı.";

                            db.Add(sop);

                        }


                    }

                    else
                    {
                        model.memberDuesInf.PaidPrice = model.memberDuesInf.PaidPrice + paidPrice;
                        model.memberDuesInf.RemainingPrice = remainingPrice;

                        if (db.memberLists.Where(x => x.UserId == doUserId && x.CompanyId == compId).FirstOrDefault().Role == "Sekreterya")
                        {


                            sop.AdminId = doUserId;
                            sop.CompId = compId;
                            sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                            sop.Text = mem.FullName + mem.MemberNumber + "," + paidPrice + "tl aidat ödemesi alındı. " + remainingPrice + "tl kaldı.";

                            db.Add(sop);

                        }

                    }

                    db.Update(model.memberDuesInf);
                }
            }

            else
            {
                model.memberDuesInf = db.memberDuesInfTables.Where(x => x.MemberDuesInfTableId == refId).FirstOrDefault();

                if (model.memberDuesInf != null)
                {

                    if (price - paidPrice == 0)
                    {

                        model.memberDuesInf.PriceCondition = true;
                        model.memberDuesInf.RemainingPrice = remainingPrice;
                        model.memberDuesInf.PaidPrice = model.memberDuesInf.PaidPrice + paidPrice;
                        model.memberDuesInf.CompanyId = compId;

                        if (db.memberLists.Where(x => x.UserId == doUserId && x.CompanyId == compId).FirstOrDefault().Role == "Sekreterya")
                        {


                            sop.AdminId = doUserId;
                            sop.CompId = compId;
                            sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                            sop.Text = mem.FullName + mem.MemberNumber + "," + paidPrice + "tl dolap ödemesi alındı. " + remainingPrice + "tl kaldı.";

                            db.Add(sop);

                        }

                    }
                    else
                    {
                        model.memberDuesInf.RemainingPrice = remainingPrice;
                        model.memberDuesInf.PaidPrice = model.memberDuesInf.PaidPrice + paidPrice;
                        model.memberDuesInf.CompanyId = compId;

                        if (db.memberLists.Where(x => x.UserId == doUserId && x.CompanyId == compId).FirstOrDefault().Role == "Sekreterya")
                        {


                            sop.AdminId = doUserId;
                            sop.CompId = compId;
                            sop.Date = DateTime.Now.ToString("dd/MM/yyyy");
                            sop.Text = mem.FullName + mem.MemberNumber + "," + paidPrice + "tl dolap ödemesi alındı. " + remainingPrice + "tl kaldı.";

                            db.Add(sop);

                        }
                    }

                    db.Update(model.memberDuesInf);
                }
            }

            model.allGetPaid.UserId = userId;
            model.allGetPaid.Date = DateTime.Now.ToString("dd-MM-yyyy");
            model.allGetPaid.RefId = refId;
            model.allGetPaid.RefType = refType;
            model.allGetPaid.DoOpUserId = doUserId;
            model.allGetPaid.Price = price;
            model.allGetPaid.PaidPrice = paidPrice;
            model.allGetPaid.RemainingPrice = remainingPrice;
            model.allGetPaid.PaymentType = paymentType;
            model.allGetPaid.ReceiptNo = receiptNo;
            model.allGetPaid.ReceiptDate = receiptDate;
            model.allGetPaid.Explain = explain;
            model.allGetPaid.CompanyId = compId;

            db.Add(model.allGetPaid);
            db.SaveChanges();

            try
            {
                return model.allGetPaid;
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return new AllGetPaidLogs();
        }

        [HttpGet("GetPaidMulti", Name = "GetPaidMulti")]
        public ReservationViewModel GetPaidMulti(string idLists, string idLists2)
        {


            ReservationViewModel model = new ReservationViewModel();

            if (idLists != null)
            {

                var resList = idLists.Split(",");
                
                

                for (int i = 0; i < resList.Count(); i++)
                {
                    if (resList[i] != "")
                    {
                        var x = resList[i].Split("r_");
                        var y = x[1];
                        model.reservations = db.reservations.Where(x => x.ResId == Convert.ToInt32(y)).ToList();
                    }

                }
            }

            if (idLists2 != null)
            {
                var resCanList = idLists2.Split(",");

                for (int i = 0; i < resCanList.Count(); i++)
                {
                    if (resCanList[i] != "")
                    {
                        var x = resCanList[i].Split("ri_");
                        var y = x[1];
                        model.reservationCancels = db.reservationCancels.Where(x => x.ResId == Convert.ToInt32(y)).ToList();
                    }

                }
            }

            return model;



        }


        [HttpGet("GetPaidMultiOp", Name = "GetPaidMultiOp")]
        public AllGetPaidLogs GetPaidMultiOp(string doUserId, int paymentType, int receiptNo, string idLists, string idLists2, string receiptDate, string explain, string compId)
        {
            AllPaidLogsViewModel model = new AllPaidLogsViewModel();

            if (idLists != null)
            {
                var resList = idLists.Split(",");

                for (int i = 0; i < resList.Count(); i++)
                {
                    if (resList[i] != "")
                    {
                        model = new AllPaidLogsViewModel();

                        model.reservation = db.reservations.Where(x => x.ResId == Convert.ToInt32(resList[i])).FirstOrDefault();

                        if (model.reservation != null)
                        {



                            model.allGetPaid.UserId = model.reservation.UserId;
                            model.allGetPaid.Date = DateTime.Now.ToString("dd-MM-yyyy");
                            model.allGetPaid.RefId = Convert.ToInt32(resList[i]);
                            model.allGetPaid.RefType = 1;
                            model.allGetPaid.DoOpUserId = doUserId;
                            model.allGetPaid.Price = model.reservation.Price;
                            model.allGetPaid.PaidPrice = model.reservation.Price;
                            model.allGetPaid.RemainingPrice = 0;
                            model.allGetPaid.PaymentType = paymentType;
                            model.allGetPaid.ReceiptNo = receiptNo;
                            model.allGetPaid.ReceiptDate = receiptDate;
                            model.allGetPaid.Explain = explain;
                            model.allGetPaid.CompanyId = compId;

                            model.reservation.Price = 0;
                            model.reservation.PriceInf = true;



                            db.Update(model.reservation);
                            db.Add(model.allGetPaid);
                            db.SaveChanges();
                        }
                    }

                }
            }

            if (idLists2 != null)
            {
                var resCanList = idLists2.Split(",");

                for (int a = 0; a < resCanList.Count(); a++)
                {
                    if (resCanList[a] != "")
                    {
                        model = new AllPaidLogsViewModel();

                        if (model.reservationCancel != null)
                        {

                            model.reservationCancel = db.reservationCancels.Where(x => x.ResId == Convert.ToInt32(resCanList[a])).FirstOrDefault();



                            model.allGetPaid.UserId = model.reservationCancel.UserId;
                            model.allGetPaid.Date = DateTime.Now.ToString("dd-MM-yyyy");
                            model.allGetPaid.RefId = Convert.ToInt32(resCanList[a]);
                            model.allGetPaid.RefType = 1;
                            model.allGetPaid.DoOpUserId = doUserId;
                            model.allGetPaid.Price = model.reservationCancel.Price;
                            model.allGetPaid.PaidPrice = model.reservationCancel.Price;
                            model.allGetPaid.RemainingPrice = 0;
                            model.allGetPaid.PaymentType = paymentType;
                            model.allGetPaid.ReceiptNo = receiptNo;
                            model.allGetPaid.ReceiptDate = receiptDate;
                            model.allGetPaid.Explain = explain;
                            model.allGetPaid.CompanyId = compId;

                            model.reservationCancel.Price = 0;
                            model.reservationCancel.PriceInf = true;

                            db.Update(model.reservationCancel);
                            db.Add(model.allGetPaid);
                            db.SaveChanges();
                        }
                    }

                }
            }

            return model.allGetPaid;
        }

    }
}


