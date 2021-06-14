using Helpers.Dto;
using Helpers.Dto.PartialViewDtos;
using Helpers.Dto.ViewDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisWeb.Controllers
{
    public class SystemSettingsController : Controller
    {
        #region IdentityRoleSettings


        public IActionResult IdentityRoleSettings()
        {
            IdentityRoleSettingsViewDto model = new IdentityRoleSettingsViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<IdentityRoleSettingsViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetRole"));

                if (model == null)

                    model = new IdentityRoleSettingsViewDto();
            }
            catch (Exception)
            {
                model = new IdentityRoleSettingsViewDto();
            }
            return View(model);
        }

        public JsonResult DeleteRole(string id)
        {
            AppIdentityRoleDto model = new AppIdentityRoleDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AppIdentityRoleDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeleteRole?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new AppIdentityUserDto());
            }

            return Json(true);
        }

        public JsonResult AddNewRole(string roleName)
        {
            AppIdentityRoleDto model = new AppIdentityRoleDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AppIdentityRoleDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewRole?roleName=" + roleName));

                if (model.NormalizedName == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new AppIdentityUserDto());
            }

            return Json(true);         
        }

        public JsonResult GetRoleInf(string ID)
        {
            AppIdentityRoleDto model = new AppIdentityRoleDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AppIdentityRoleDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetRoleInf?id=" + ID));

                if (model.NormalizedName == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new AppIdentityRoleDto());
            }

            return Json(model);

        }

        public JsonResult UpdateRole(string roleName, string id)
        {
            AppIdentityRoleDto model = new AppIdentityRoleDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<AppIdentityRoleDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdateRole?roleName=" + roleName + "&id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);

        }

        public JsonResult changeAuthority(List<string> trueList)
        {
            if (trueList.Count == 0)
                return Json(false);
            else
            {
                string trueStr = "";
                foreach (var item in trueList)
                {
                    trueStr += item + "-";
                }
                trueStr = trueStr.Remove(trueStr.Length - 1);

                List<UserSettingsDto> model = new List<UserSettingsDto>();
                try
                {
                    model = Helpers.Serializers.DeserializeJson<List<UserSettingsDto>>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/changeAuthority?trueStr=" + trueStr));

                    if (model == null)
                        return Json(false);
                }
                catch (Exception)
                {
                    return Json(false);
                }
            }


            return Json(true);
        }

        #endregion

        #region CourtSettings

        
        public IActionResult CourtSettings()
        {
            CourtSettingsViewDto model = new CourtSettingsViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtSettingsViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetCourt"));

                if (model == null)
                {
                    model.Courts = new List<CourtDto>();
                    model.courtPriceLists = new List<CourtPriceListDto>();
                }

            }
            catch (Exception)
            {
                model = new CourtSettingsViewDto();

            }
            return View(model);

        }



        //Kort Ayarları
        public JsonResult AddNewCourt(string courtName , string courtType , int AddcourtCondition, int AddcourtWebCondition)
        {
            CourtDto model = new CourtDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewCourt?courtName=" + courtName + "&courtType=" + courtType + "&courtCondition=" + AddcourtCondition + "&courtWebCondition=" + AddcourtWebCondition));

                if (model.CourtName == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);


        }

        public JsonResult GetCourtInf(string ID)
        {
            CourtDto model = new CourtDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetCourtInf?id=" + ID));

                if (model.CourtName == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(model);

        }

        public JsonResult UpdateCourt(int id , string courtName, string courtType, int courtCondition, int courtWebCondition)
        {
            CourtDto model = new CourtDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdateCourt?courtName=" + courtName + "&courtType=" + courtType + "&courtCondition=" + courtCondition + "&courtWebCondition=" + courtWebCondition + "&id=" + id));

                if (model.CourtName == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);

        }

        public JsonResult deleteCourt(int id)
        {
            CourtDto model = new CourtDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeleteCourt?id=" + id));

                if (model != null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);

        }



        //Kort Ücret Ayarları
        public JsonResult AddNewCourtPriceList(string recipeName, int recipePrice, string recipePriceType, string courtRecipeType , string recipeCondition)
        {
            CourtPriceListDto model = new CourtPriceListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtPriceListDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewCourtPriceList?recipeName=" + recipeName + "&recipePrice=" + recipePrice + "&recipePriceType=" + recipePriceType + "&courtRecipeType=" + courtRecipeType + "&recipeCondition=" + recipeCondition));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);


        }

        public JsonResult GetCourtPriceInf(string ID)
        {
            CourtPriceListDto model = new CourtPriceListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtPriceListDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetCourtPriceInf?id=" + ID));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(model);

        }

        public JsonResult UpdateCourtPriceList(int id, string name, int courtPrice, string priceType, string recipeType, string condition)
        {
            CourtPriceListDto model = new CourtPriceListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtPriceListDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdateCourtPriceList?Name=" + name + "&courtPrice=" + courtPrice + "&priceType=" + priceType + "&recipeType=" + recipeType + "&condition=" + condition + "&id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);

        }

        public JsonResult deleteCourtPrice(int id)
        {
            CourtPriceListDto model = new CourtPriceListDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtPriceListDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeleteCourtPrice?id=" + id));

                if (model != null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);

        }

        #endregion

        #region EducationSettings


        //Okul Türü Ayarları
        public IActionResult EducationSchoolSettings()
        {

            EducationSettingsViewDto model = new EducationSettingsViewDto();

            try
            {
                var getResult = Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetSchoolSettings");
                model = Helpers.Serializers.DeserializeJson<EducationSettingsViewDto>(getResult);

                if (model == null)
                    
                    model = new EducationSettingsViewDto();
            }
            catch (Exception)
            {
                model = new EducationSettingsViewDto();
            }
            return View(model);
        }



        public JsonResult AddNewSchoolType(string schoolType, string schoolCode)
        {
            SchoolTypeDto model = new SchoolTypeDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolTypeDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewSchoolType?schoolType=" + schoolType + "&schoolCode=" + schoolCode ));

                if (model.Code == null && model.Types == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);


        }

        public JsonResult DeleteSchoolType(int id)
        {
            SchoolTypeDto model = new SchoolTypeDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolTypeDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeleteSchoolType?id=" + id));

                if (model.Code == null && model.Types == null && model.SchoolTypesId == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);
        }

        public JsonResult GetSchoolTypeInf(string id)
        {
            SchoolTypeDto model = new SchoolTypeDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolTypeDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetSchoolTypeInf?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new SchoolTypeDto());
            }

            return Json(model);

        }

        public JsonResult GetSchoolPriceInf(string id)
        {
            SchoolPriceDto model = new SchoolPriceDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolPriceDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetSchoolPriceInf?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new SchoolTypeDto());
            }

            return Json(model);

        }

        public JsonResult UpdateSchoolType(int id, string code, string type)
        {
            SchoolTypeDto model = new SchoolTypeDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolTypeDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdateUpdateSchoolType?code=" + code + "&type=" + type + "&id=" + id));

                if ( model.Code == null && model.Types == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);

        }



        //Okul Seviyesi Ayarları
        public JsonResult AddNewSchoolLevel(string levelName, int levelQuota)
        {
            SchoolLevelDto model = new SchoolLevelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolLevelDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewSchoolLevel?levelName=" + levelName + "&levelQuota=" + levelQuota));

                if ( model.Levels == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);


        }

        public JsonResult DeleteSchoolLevel(int id)
        {
            SchoolLevelDto model = new SchoolLevelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolLevelDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeleteSchoolLevel?id=" + id));

                if (model.Levels == null )

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);
        }

        public JsonResult GetSchoolLevelInf(string id)
        {
            SchoolLevelDto model = new SchoolLevelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolLevelDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetSchoolLevelInf?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new SchoolTypeDto());
            }

            return Json(model);

        }

        public JsonResult UpdateSchoolLevel(int id, string levelName, int levelquota)
        {
            SchoolLevelDto model = new SchoolLevelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<SchoolLevelDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdateUpdateSchoolLevel?levelName=" + levelName + "&quota=" + levelquota + "&id=" + id));

                if (model.Levels == null )

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);

        }



        //Performans Türü Ayarları
        public IActionResult EducationPerformanceSettings()
        {

            EducationSettingsViewDto model = new EducationSettingsViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<EducationSettingsViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetPerformanceSettings"));

                if (model == null)

                    model = new EducationSettingsViewDto();
            }
            catch (Exception)
            {
                model = new EducationSettingsViewDto();
            }
            return View(model);
        }



        public JsonResult AddNewPerformanceType(string code, string type)
        {
            PerformanceTypeDto model = new PerformanceTypeDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PerformanceTypeDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewPerformanceType?code=" + code + "&type=" + type));

                if (model.PerformanceTypes == null && model.PerformanceCode == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new CourtDto());
            }

            return Json(true);


        }

        public JsonResult DeletePerformanceType(int id)
        {
            PerformanceTypeDto model = new PerformanceTypeDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PerformanceTypeDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeletePerformanceType?id=" + id));

                if (model.PerformanceCode == null && model.PerformanceCode == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PerformanceTypeDto());
            }

            return Json(true);
        }

        public JsonResult GetPerformanceTypeInf(string id)
        {
            PerformanceTypeDto model = new PerformanceTypeDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PerformanceTypeDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetPerformanceTypeInf?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new SchoolTypeDto());
            }

            return Json(model);

        }

        public JsonResult UpdatePerformanceType(int id, string code, string type)
        {
            PerformanceTypeDto model = new PerformanceTypeDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PerformanceTypeDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdatePerfType?code=" + code + "&type=" + type + "&id=" + id));

                if (model.PerformanceTypes == null && model.PerformanceCode == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PerformanceTypeDto());
            }

            return Json(true);

        }


        //Performans Seviyesi Ayarları

        public JsonResult AddNewPerformanceLevel(string level)
        {
            PerformanceLevelDto model = new PerformanceLevelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PerformanceLevelDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewPerformanceLevel?level=" + level ));

                if (model.PerLevel == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PerformanceLevelDto());
            }

            return Json(true);


        }

        public JsonResult DeletePerformanceLevel(int id)
        {
            PerformanceLevelDto model = new PerformanceLevelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PerformanceLevelDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeletePerformanceLevel?id=" + id));

                if (model.PerLevel == null && model.PerQuotaInf == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PerformanceTypeDto());
            }

            return Json(true);
        }

        public JsonResult GetPerformanceLevelInf(string id)
        {
            PerformanceLevelDto model = new PerformanceLevelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PerformanceLevelDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetPerformanceLevelInf?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PerformanceLevelDto());
            }

            return Json(model);

        }

        public JsonResult UpdatePerformanceLevel(int id, string level)
        {
            PerformanceLevelDto model = new PerformanceLevelDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PerformanceLevelDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdatePerfLevel?level=" + level + "&id=" + id));

                if (model.PerLevel == null )

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PerformanceLevelDto());
            }

            return Json(true);

        }


        //ÖzelDers Ayarları

        public IActionResult EducationPrivateLessonSettings()
        {

            EducationSettingsViewDto model = new EducationSettingsViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<EducationSettingsViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetPrivLessonSettings"));

                if (model == null)

                    model = new EducationSettingsViewDto();
            }
            catch (Exception)
            {
                model = new EducationSettingsViewDto();
            }
            return View(model);
        }


        public JsonResult AddPrivLesson(string inf, string type , int? price , int? teacherprice)
        {
            PrivateLessonDto model = new PrivateLessonDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PrivateLessonDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewPrivLesson?inf=" + inf + "&type=" + type + "&price=" + price + "&teacherprice=" + teacherprice));

                if (model.PrivateLessonPrice == null && model.PrivateLessonType == null && model.TeacherPrice == null && model.TariffeInf == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PrivateLessonDto());
            }

            return Json(true);


        }

        public JsonResult DeletePrivLesson(int id)
        {
            PrivateLessonDto model = new PrivateLessonDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PrivateLessonDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeletePrivateLesson?id=" + id));

                if (model.TariffeInf == null && model.PrivateLessonPrice == null && model.PrivateLessonType == null && model.TeacherPrice == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PrivateLessonDto());
            }

            return Json(true);
        }

        public JsonResult GetPrivLessonInf(string id)
        {
            PrivateLessonDto model = new PrivateLessonDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PrivateLessonDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetPrivLessonInf?id=" + id));

                if (model == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new PrivateLessonDto());
            }

            return Json(model);

        }

        public JsonResult UpdatePrivLesson(int id, string privLesType, string tariffeInf , int? privLesPrice , int? teacherPrice)
        {
            PrivateLessonDto model = new PrivateLessonDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<PrivateLessonDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdatePrivLesson?tariffeInf=" + tariffeInf + "&privLesType=" + privLesType + "&id=" + id + "&privLesPrice=" + privLesPrice + "&teacherPrice=" + teacherPrice));

                if (model.TariffeInf == null && model.PrivateLessonType == null && model.PrivateLessonPrice == null && model.TeacherPrice == null)
                    return Json(false);
            }
            catch (Exception)
            {
                return Json(false);
            }

            return Json(true);

        }

        #endregion

        #region ReservationSettings

        public IActionResult ReservationSettings()
        {

            ReservationSettingsViewDto model = new ReservationSettingsViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationSettingsViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetReservationSettings"));

                if (model == null)

                    model = new ReservationSettingsViewDto();
            }
            catch (Exception)
            {
                model = new ReservationSettingsViewDto();
            }
            return View(model);
        }


        public JsonResult AddResSet(string setInf, int? setVal)
        {
            ReservationSettingsDto model = new ReservationSettingsDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationSettingsDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewResSet?setInf=" + setInf + "&setVal=" + setVal));

                if (model.ReservationSettingsInf == null && model.ReservationValue == null)

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new ReservationSettingsDto());
            }

            return Json(true);


        }

        public JsonResult DeleteResSet(int id)
        {
            ReservationSettingsDto model = new ReservationSettingsDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationSettingsDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/DeleteResSet?id=" + id));

                if (model.ReservationSettingsInf == null && model.ReservationValue == null )

                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new ReservationSettingsDto());
            }

            return Json(true);
        }

        public JsonResult UpdateResSet(string updStr )
        {
            ReservationSettingsDto model = new ReservationSettingsDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<ReservationSettingsDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/UpdateResSet?updStr=" + updStr ));

                if (model.ReservationSettingsInf == null && model.ReservationValue == null)
                    return Json(false);
            }
            catch (Exception)
            {
                return Json(new ReservationSettingsDto());
            }

            return Json(true);
        }

        #endregion
    }
}




