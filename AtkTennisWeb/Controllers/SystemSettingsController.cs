using Helpers.Dto;
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



        public JsonResult AddNewCourt(string courtName , string courtType , string courtCondition , string courtWebCondition)
        {
            CourtDto model = new CourtDto();
            try
            {
                model = Helpers.Serializers.DeserializeJson<CourtDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/NewCourt?courtName=" + courtName + "&courtType=" + courtType + "&courtCondition=" + courtCondition + "&courtWebCondition=" + courtWebCondition));

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

        public JsonResult UpdateCourt(int id , string courtName, string courtType, string courtCondition, string courtWebCondition)
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

        public IActionResult EducationSchoolSettings()
        {

            EducationSettingsViewDto model = new EducationSettingsViewDto();

            try
            {
                model = Helpers.Serializers.DeserializeJson<EducationSettingsViewDto>(Helpers.Request.Get(Mutuals.AppUrl + "SystemSettings/GetSchoolSettings"));

                if (model == null)

                    model = new EducationSettingsViewDto();
            }
            catch (Exception)
            {
                model = new EducationSettingsViewDto();
            }
            return View(model);
        }

        #endregion
    }
}




