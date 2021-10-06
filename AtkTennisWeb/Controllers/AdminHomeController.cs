using AtkTennisWeb.Models;
using AtkTennisWeb.Providers;
using Helpers.Dto;
using Helpers.Dto.PartialViewDtos;
using Helpers.Dto.ViewDtos;
using Microsoft.AspNetCore.Authorization;
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
    [AdminUser]
    public class AdminHomeController : Controller
    {
        
        public IActionResult Index()
        {

            HomeModelDto model = new HomeModelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<HomeModelDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetHome"));
                if (model == null)
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

        public IActionResult MemberDetailPage(int memberNum)
        {
            GetMemberDetailViewDto model = new GetMemberDetailViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<GetMemberDetailViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetMemberDetail?memberNum=" + memberNum));

                if (model == null)

                    model = new GetMemberDetailViewDto();
            }
            catch (Exception)
            {
                model = new GetMemberDetailViewDto();
            }

            return View(model);


        }

        public IActionResult CabinetListUser()
        {

            CabinetListUserViewDto model = new CabinetListUserViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CabinetListUserViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetCabinetListUser"));
                if (model == null)
                    model = new CabinetListUserViewDto();
            }
            catch (Exception)
            {
                model = new CabinetListUserViewDto();
            }

            return View(model);
        }

        public IActionResult MultiReservations()
        {

            List<CourtDto> model = new List<CourtDto>();
            try
            {
                model = Helpers.Serializers.DeserializeJson<List<CourtDto>>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetMultiReservation"));
                if (model == null)
                    model = new List<CourtDto>();
            }
            catch (Exception)
            {
                model = new List<CourtDto>();
            }

            return View(model);


        }

        public IActionResult MultiReservationCancel()
        {
            return View();
        }

        public IActionResult GeneralDebtMember()
        {
            GeneralDebtViewDto model = new GeneralDebtViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<GeneralDebtViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetGeneralDebtMember"));
                if (model == null)

                    model = new GeneralDebtViewDto();
            }
            catch (Exception)
            {
                model = new GeneralDebtViewDto();
            }

            return View(model);
        }

        public IActionResult DuesDebtList()
        {

            GeneralDebtViewDto model = new GeneralDebtViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<GeneralDebtViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/DuesDebtList"));
                if (model == null)

                    model = new GeneralDebtViewDto();
            }
            catch (Exception)
            {
                model = new GeneralDebtViewDto();
            }

            return View(model);
        }

        public IActionResult TotalSystemUsers()
        {

            List<MemberListDto> model = new List<MemberListDto>();

            try
            {
                model = Helpers.Serializers.DeserializeJson<List<MemberListDto>>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/TotalSystemUsers"));

                if (model == null)

                    model = new List<MemberListDto>();
            }
            catch (Exception)
            {
                model = new List<MemberListDto>();
            }

            return View(model);
        }

        public IActionResult DuesDebtOperations()
        {

            return View();
        }

        public IActionResult CabinetDebtOperations()
        {
            return View();
        }

        public IActionResult ReservationDebtOperations()
        {
            return View();
        }

        public IActionResult AllReservationCancelList()
        {
            return View();
        }

        public IActionResult AllReservationList()
        {
            return View();
        }

        //public IActionResult RegisterStudent()
        //{

        //    RegisterStudentViewDto model = new RegisterStudentViewDto();

        //    try
        //    {
        //        model = Helpers.Serializers.DeserializeJson<RegisterStudentViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetStudentRegister"));

        //        if (model == null)

        //            model = new RegisterStudentViewDto();
        //    }
        //    catch (Exception)
        //    {
        //        model = new RegisterStudentViewDto();
        //    }
        //    return View(model);
        //}


        public JsonResult GetCabinet(string code)
        {
            MemberSettingsViewDto model = new MemberSettingsViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<MemberSettingsViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetCabinet?code=" + code));
                if (model == null)
                    model = new MemberSettingsViewDto();
            }
            catch (Exception)
            {
                model = new MemberSettingsViewDto();
            }

            return Json(model);
        }

        public JsonResult GetUserSchoolList()
        {
            MemberSchoolPerViewDto model = new MemberSchoolPerViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<MemberSchoolPerViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetUserSchoolList"));
                if (model == null)
                    model = new MemberSchoolPerViewDto();
            }
            catch (Exception)
            {
                model = new MemberSchoolPerViewDto();
            }

            return Json(model);
        }

        public JsonResult DeleteCabinets(int id)
        {
            CabinetListUserDto model = new CabinetListUserDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<CabinetListUserDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/DeleteCabinet?id=" + id));
                if (model == null)
                    model = new CabinetListUserDto();
            }
            catch (Exception)
            {
                model = new CabinetListUserDto();
            }

            return Json(model);
        }

        public JsonResult GetResTable(string date)
        {

            HomeModelDto model = new HomeModelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<HomeModelDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetResTable?date=" + date));
                if (model == null)
                    model = new HomeModelDto();
            }
            catch (Exception)
            {
                model = new HomeModelDto();
            }

            ViewBag.date = date;

            return Json(model);
        }

        public JsonResult Register(string detailAddress ,string name, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role, string nickName, int memberNumber, string partnerBirthdate , string partnerIdNumber , string partnerPhone , string partnerName , bool isPartner , string refmem1 , string refmem2)
        {
            AppIdentityUserDto model = new AppIdentityUserDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AppIdentityUserDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/NewRegister?name=" + name + "&username=" + username + "&phone=" + phone + "&password=" + password + "&birthdate=" + birthdate + "&gender=" + gender + "&email=" + email + "&role=" + role +
                    "&startDate=" + startDate + "&finishDate=" + finishDate + "&condition=" + condition + "&identificationNumber=" + identificationNumber + "&webReservation=" + webReservation +
                    "&phoneExp=" + phoneExp + "&phone2=" + phone2 + "&detailAddress=" + detailAddress + "&refmem1=" + refmem1 + "&refmem2=" + refmem2 + "&phone2Exp=" + phone2Exp + "&emailExp=" + emailExp + "&birthPlace=" + birthPlace + "&motherName=" + motherName + "&fatherName=" + fatherName + "&city=" + city + "&district=" + district + "&job=" + job + "&note=" + note + "&nickName=" + nickName + "&memberNumber=" + memberNumber + "&partnerBirthdate=" + partnerBirthdate + "&partnerIdNumber=" + partnerIdNumber + "&partnerPhone=" + partnerPhone + "&partnerName=" + partnerName + "&isPartner=" + isPartner));

                if (model == null)
                    model = new AppIdentityUserDto();
            }
            catch (Exception)
            {
                return Json(new AppIdentityUserDto());
            }

            return Json(model);
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

        public JsonResult GetResUpdTime(int courtId, string dateInf, int resId)
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
                model = Helpers.Serializers.DeserializeJson<ReservationCourtViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetUpdateResAdmin?id=" + id));

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

        public JsonResult UpdateResAdmin(int id, string startTime, string finishTime, string time, int cId)
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

        public JsonResult UpdateMemberList(string id, string name, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role, string checkpass)
        {
            AppIdentityRoleDto model = new AppIdentityRoleDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AppIdentityRoleDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/UpdateMemberList?name=" + name + "&username=" + username + "&id=" + id + "&phone=" + phone + "&password=" + password + "&birthdate=" + birthdate + "&gender=" + gender + "&email=" + email + "&role=" + role +
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

        public JsonResult AddCabinet(int price, string code, string who, string type, string userId)
        {
            CabinetListUserDto model = new CabinetListUserDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CabinetListUserDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/AddCabinet?price=" + price + "&code=" + code + "&who=" + who + "&type=" + type + "&userId=" + userId));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CabinetListUserDto());
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

        public JsonResult AddToDo(string toDo, string today)
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

        public JsonResult GetResTimeMulti(int courtId, string dateInf , string date2 , string day)
        {
            List<court_reserved> model = new List<court_reserved>();
            try

            {
                model = Helpers.Serializers.DeserializeJson<List<court_reserved>>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetResTimeMulti?courtId=" + courtId + "&dateInf=" + dateInf + "&date2=" + date2 + "&day=" + day));

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

        public JsonResult AddMultiRes(int CourtId, string DateInf, string Date2, string ResStartTime, string ResFinishTime, string userId, string UserName , string day)
        {
            var model = new ReservationViewDto();
            try

            {
                model = Helpers.Serializers.DeserializeJson<ReservationViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/AddMultiRes?CourtId=" + CourtId + "&DateInf=" + DateInf + "&Date2=" + Date2 + "&ResStartTime=" + ResStartTime + "&ResFinishTime=" + ResFinishTime + "&userId=" + userId + "&UserName=" + UserName + "&day=" + day));

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

        public JsonResult GetResDetailSearch(string whoRes , string startDate , string finishDate)
        {
            List<ReservationDto> model = new List<ReservationDto>();
            try
            {
                model = Helpers.Serializers.DeserializeJson<List<ReservationDto>>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetResDetailSearch?whoRes=" + whoRes + "&startDate=" + startDate + "&finishDate=" + finishDate));

                if (model == null)

                    return Json("false");
            }

            catch (Exception)
            {
                return Json(new List<ReservationDto>());
            }

            return Json(model);

        }

        public JsonResult CancelAllRes( string idLists)
        {
            ReservationDto model = new  ReservationDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/CancelAllRes?idLists=" + idLists));

                if (model != null)

                    return Json("true");
            }

            catch (Exception)
            {
                return Json(new ReservationDto ());
            }

            return Json(false);

        }

        public JsonResult AddDues(int duesYear, string duesType, int duesPrice , string explain)
        {
            AddDuesViewDto model = new AddDuesViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AddDuesViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/AddDues?duesYear=" + duesYear + "&duesType=" + duesType + "&duesPrice=" + duesPrice + "&explain=" + explain ));

                if (model.memberLists.Count != 0 )

                    return Json(model);
            }

            catch (Exception)
            {
                return Json(new ReservationDto());
            }

            return Json(false);

        }

        public JsonResult AddGenCabinetDebt(int cabinetDuesYear, string cabinetType, string cabinetExplain)
        {
            AddDuesViewDto model = new AddDuesViewDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AddDuesViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/AddGenCabinetDebt?cabinetDuesYear=" + cabinetDuesYear + "&cabinetType=" + cabinetType + "&cabinetExplain=" + cabinetExplain));

                if (model.memberLists.Count != 0)

                    return Json(model);
            }

            catch (Exception)
            {
                return Json(new ReservationDto());
            }

            return Json(false);

        }

        public JsonResult GetMemberCabinetDetail(string id)
        {
            AddDuesViewDto model = new AddDuesViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<AddDuesViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetMemberCabinetDetail?id=" + id ));
            }

            catch (Exception)
            {
                return Json(new ReservationDto());
            }

            return Json(model);

        }

        public JsonResult GetDuesDebtMember(string id)
        {
            GeneralDebtViewDto model = new GeneralDebtViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<GeneralDebtViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetDuesDebtMember?id=" + id));
            }

            catch (Exception)
            {
                return Json(new GeneralDebtViewDto());
            }

            return Json(model);

        }

        public JsonResult GetResUser(string id)
        {
            HomeModelDto model = new HomeModelDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<HomeModelDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetResUser?id=" + id));
            }

            catch (Exception)
            {
                return Json(new GeneralDebtViewDto());
            }

            return Json(model);

        }

        public JsonResult GetReserInf(int id)
        {
            ResandResCancelViewDto model = new ResandResCancelViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<ResandResCancelViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetReserInf?id=" + id));
            }

            catch (Exception)
            {
                return Json(new ResandResCancelViewDto());
            }

            return Json(model);

        }

        public JsonResult GetCabinetInf(int id)
        {
            GetPaidDuesModel model = new GetPaidDuesModel();

            try
            {
                model = Helpers.Serializers.DeserializeJson<GetPaidDuesModel>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetCabinetInf?id=" + id));
            }

            catch (Exception)
            {
                return Json(new GetPaidDuesModel());
            }

            return Json(model);

        }

        public JsonResult GetResCancelList(string date)
        {
            ReservationListViewDto model = new ReservationListViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationListViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetResCancelList?date=" + date));
            }

            catch (Exception)
            {
                return Json(new ReservationListViewDto());
            }

            return Json(model);

        }

        public class GetPaidDuesModel
        {
            public MemberDuesInfTableDto memberDuesInf { get; set; }
            public List<AllGetPaidLogsDto> AllGetPaidLogs { get; set; } = new List<AllGetPaidLogsDto>();
        }

        public JsonResult GetDuesInf(int id)
        {

            GetPaidDuesModel model = new GetPaidDuesModel();

            try
            {
                model = Helpers.Serializers.DeserializeJson<GetPaidDuesModel>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetDuesInf?id=" + id));
            }

            catch (Exception)
            {
                return Json(new ResandResCancelViewDto());
            }

            return Json(model);

        }

        public JsonResult GetPaid(string userId , int refId , int refType , 
            string doUserId , int price , int paidPrice , int remainingPrice , 
            int paymentType , int receiptNo , string receiptDate , string explain)
        {
            AllGetPaidLogsDto model = new AllGetPaidLogsDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<AllGetPaidLogsDto>(Helpers.Request.Get(Mutuals.AppUrl + "AdminHome/GetPaid?userId=" + userId + "&refId=" + refId + "&refType=" + 
                    refType + "&doUserId=" + doUserId + "&price=" + price + "&paidPrice=" + paidPrice
                    + "&remainingPrice=" + remainingPrice + "&paymentType=" + paymentType + "&receiptNo=" + receiptNo
                    + "&receiptDate=" + receiptDate + "&explain=" +explain
                    ));
            }

            catch (Exception)
            {
                return Json(new AllGetPaidLogsDto());
            }

            return Json(model);

        }



     

    }
}
