using AtkTennisApp.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtkTennisApp.Models;
using AtkTennis.Models;
using AtkTennisApp.ViewModels;

namespace AtkTennisApp.Controllers
{


    [Route("[controller]")]
    [ApiController]
    public class SystemSettingsController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public SystemSettingsController(UserManager<AppIdentityUser> userManager,
            RoleManager<AppIdentityRole> roleManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        Context db = new Context();

        #region IdentityRoleSettings

        [HttpGet("NewRole", Name = "NewRole")]
        public AppIdentityRole NewRole(string roleName)
        {

            var Role = new AppIdentityRole();
            var Role2 = new UserSettings();
            CourtScaleList scale = new CourtScaleList();

            try
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {

                    Role.Name = roleName;
                    Role.Description = "Can Perform Crud Operations";
                    var roleResult = roleManager.CreateAsync(Role).Result;



                    Role2.RoleId = Role.Id;
                    Role2.RoleName = roleName;
                    Role2.Advisory = false;
                    Role2.Reservations = false;
                    Role2.SystemSettings = false;
                    Role2.DebtandPayment = false;

                    scale.Name = roleName;
                    scale.Code = roleName.Substring(0, 3).ToUpper();
                    scale.Color = "#000000";

                    db.Add(Role2);
                    db.Add(scale);
                    db.SaveChanges();

                }

            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return Role;
        }

        [HttpGet("DeleteRole", Name = "DeleteRole")]
        public async Task<JsonResult> DeleteRole(string id)
        {

            var role = await roleManager.FindByIdAsync(id);

            UserSettings Role2 = new UserSettings();
            CourtScaleList scale = new CourtScaleList();

            try
            {
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                }

                else
                {

                    var result = await roleManager.DeleteAsync(role);

                    Role2 = db.userSettings.Where(x => x.RoleId == role.Id).FirstOrDefault();
                    scale = db.courtScaleLists.Where(x => x.Name == Role2.RoleName).FirstOrDefault();

                    if (Role2.RoleId != null)
                    {
                        db.Remove(Role2);
                        db.Remove(scale);

                        db.SaveChanges();

                    }
                    else
                    {
                        return Json(false);
                    }


                    if (result.Succeeded)
                    {
                        return Json(Role2);
                    }
                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }
            return Json(role);
        }

        [HttpGet("GetRole", Name = "GetIdentityRole")]
        public IdentityRoleSettingsViewModel GetRole()

        {

            IdentityRoleSettingsViewModel model = new IdentityRoleSettingsViewModel();

            try
            {
                model.appIdentityRoles = roleManager.Roles.ToList();
                model.userSettings = db.userSettings.ToList();
            }
            catch (Exception ex)
            {
                model = new IdentityRoleSettingsViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetRoleInf", Name = "GetRoleInf")]
        public async Task<JsonResult> GetRoleInf(string ID)

        {
            AppIdentityRole model = new AppIdentityRole();

            try
            {
                model = await roleManager.FindByIdAsync(ID);
            }
            catch (Exception ex)
            {
                model = new AppIdentityRole();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);
        }

        [HttpGet("UpdateRole", Name = "UpdateRole")]
        public async Task<JsonResult> UpdateRole(string id, string roleName)
        {
            AppIdentityRole model = new AppIdentityRole();

            try
            {
                UserSettings Role2 = new UserSettings();

                var role = await roleManager.FindByIdAsync(id);

                Role2 = db.userSettings.Where(x => x.RoleId == role.Id).FirstOrDefault();

                model = await roleManager.FindByIdAsync(id);

                if (model != null)
                {
                    model.NormalizedName = roleName;
                    model.Name = roleName;
                }

                var result = await roleManager.UpdateAsync(model);

                Role2 = db.userSettings.Where(x => x.RoleId == role.Id).FirstOrDefault();

                if (Role2.RoleId != null)
                {
                    Role2.RoleName = roleName;


                    db.Update(Role2);
                    db.SaveChanges();
                }


                if (result.Succeeded)
                {
                    return Json(role);
                }

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("changeAuthority", Name = "changeAuthority")]
        public List<UserSettings> changeAuthority(string trueStr)
        {
            List<UserSettings> model = new List<UserSettings>();

            try
            {
                List<string> trueList = new List<string>(trueStr.Split("-").ToArray());



                model = db.userSettings.ToList();
                List<int> idList = new List<int>();
                List<string> activeAuth = new List<string>();
                foreach (var item in model)
                {
                    idList.Add(item.UserSettingsId);
                }

                foreach (var item in idList)
                {
                    activeAuth.Clear();
                    foreach (var item2 in trueList)
                    {
                        if (item == Convert.ToInt32(item2.Split("_")[1]))
                        {
                            activeAuth.Add(item2.Split("_")[0]);
                        }

                    }

                    UserSettings model2 = db.userSettings.SingleOrDefault(x => x.UserSettingsId == item);

                    if (activeAuth.Contains("System"))
                        model2.SystemSettings = true;
                    else
                        model2.SystemSettings = false;
                    if (activeAuth.Contains("Advisory"))
                        model2.Advisory = true;
                    else
                        model2.Advisory = false;

                    if (activeAuth.Contains("DebtandPayment"))
                        model2.DebtandPayment = true;
                    else
                        model2.DebtandPayment = false;

                    if (activeAuth.Contains("Reservations"))
                        model2.Reservations = true;
                    else
                        model2.Reservations = false;
                    
                    if (activeAuth.Contains("Dashboard"))
                        model2.Dashboard = true;
                    else
                        model2.Dashboard = false;

                    db.Update(model2);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);
                return new List<UserSettings>();
            }

            return model;
        }

        [HttpGet("getAuthority", Name = "getAuthority")]
        public UserSettings getAuthority(string RoleId)
        {
            UserSettings model = new UserSettings();

            try
            {
                model = db.userSettings.Where(x => x.RoleId == RoleId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);
                return new UserSettings();
            }

            return model;
        }

        #endregion

        #region CourtSettings 

        [HttpGet("GetCourt", Name = "GetCourt")]
        public CourtSettingsViewModel GetCourt()

        {
            CourtSettingsViewModel model = new CourtSettingsViewModel();


            try
            {
                model.courtPriceLists = db.courtPriceLists.ToList();
                model.courtRecipeTypes = db.courtRecipeTypes.ToList();
                model.Courts = db.courts.ToList();
                model.resTimes = db.resTimes.ToList();
                model.courtScales = db.courtScaleLists.ToList();
                model.performanceTypes = db.performanceTypes.ToList();
                model.schoolTypes = db.schoolTypes.ToList();
                model.memberLists = db.memberLists.ToList();


            }
            catch (Exception ex)
            {
                model = new CourtSettingsViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("NewCourtType", Name = "NewCourtTypeourt")]
        public JsonResult NewCourtType(string courtTypeName)
        {
            CourtRecipeType courtType = new CourtRecipeType();
            

            try
            {
                if (courtTypeName != null || courtType != null)
                {

                    courtType.CourtRecipeTypes = courtTypeName;

                    db.Add(courtType);
                    db.SaveChanges();

                    return Json(courtType);

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return Json(false);
        }

        [HttpGet("DeleteCourtType", Name = "DeleteCourtType")]
        public JsonResult DeleteCourtType(int id)
        {
            CourtRecipeType model = new CourtRecipeType();

            try
            {

                model = db.courtRecipeTypes.Where(x => x.CourtRecipeTypeId == id).SingleOrDefault();

                if (model != null)
                {
                    db.Remove(model);
                    db.SaveChanges();

                    return Json(model);
                }

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(true);
        }

        [HttpGet("GetCourtTypeInf", Name = "GetCourtTypeInf")]
        public JsonResult GetCourtTypeInf(int id)
        {


            CourtRecipeType model = new CourtRecipeType();

            try
            {
                model = db.courtRecipeTypes.Where(x => x.CourtRecipeTypeId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("UpdateCourtType", Name = "UpdateCourtType")]
        public JsonResult UpdateCourtType(int id, string courtTypeName)
        {
            CourtRecipeType model = new CourtRecipeType();

            try
            {

                model = db.courtRecipeTypes.Where(x => x.CourtRecipeTypeId == id).SingleOrDefault();
                if (model != null)
                {
                    model.CourtRecipeTypes = courtTypeName;

                    db.Update(model);
                    db.SaveChanges();

                    return Json(model);
                }
                
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(false);
        }

        

        [HttpGet("NewCourt", Name = "NewCourt")]
        public Court NewCourt(string courtName, string courtType, int courtCondition, int courtWebCondition , string courtTimePeriod , string courtStartTime , string courtFinishTime)
        {

            var Court = new Court();

            try
            {
                if (courtName != null || courtType != null )
                {
                    Court.CourtName = courtName;
                    Court.CourtType = courtType;
                    Court.CourtConditions = courtCondition;
                    Court.CourtWebConditions = courtWebCondition;
                    Court.CourtStartTime = courtStartTime;
                    Court.CourtFinishTime = courtFinishTime;
                    Court.CourtTimePeriod = courtTimePeriod;

                    db.Add(Court);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return Court;
        }

        [HttpGet("GetCourtInf", Name = "GetCourtInf")]
        public JsonResult GetCourtInf(int ID)
        {


            Court model = new Court();

            try
            {
                model = db.courts.Where(x => x.CourtId == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

      

        //kontrol eksiği var
        [HttpGet("UpdateCourt", Name = "UpdateCourt")]
        public JsonResult UpdateCourt(int id, string courtName, string courtType, int courtCondition, int courtWebCondition , string courtPeriodTime, string courtTimeStart, string courtTimeFinish)
        {
            Court model = new Court();

            try
            {

                model = db.courts.Where(x => x.CourtId == id).SingleOrDefault();
                model.CourtName = courtName;
                model.CourtType = courtType;
                model.CourtConditions = courtCondition;
                model.CourtWebConditions = courtWebCondition;
                model.CourtStartTime = courtTimeStart;
                model.CourtFinishTime = courtTimeFinish;
                model.CourtTimePeriod = courtPeriodTime;

                db.Update(model);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

       

        //Modal eksiği var
        [HttpGet("DeleteCourt", Name = "DeleteCourt")]
        public JsonResult DeleteCourt(int id)
        {
            Court model = new Court();

            try
            {

                model = db.courts.Where(x => x.CourtId == id).SingleOrDefault();

                if (model != null)
                {
                    db.Remove(model);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(true);
        }


        [HttpGet("NewCourtPriceList", Name = "NewCourtPriceList")]
        public CourtPriceList NewCourtPriceList(string recipeName, int recipePrice, string recipePriceType, string courtRecipeType, string recipeCondition)
        {

            var CourtPriceList = new CourtPriceList();

            try
            {
                if (recipeName != null || recipePriceType != null || courtRecipeType != null || recipeCondition != null)
                {
                    CourtPriceList.Name = recipeName;
                    CourtPriceList.CourtPrice = recipePrice;
                    CourtPriceList.PriceType = recipePriceType;
                    CourtPriceList.RecipeType = courtRecipeType;
                    CourtPriceList.Condition = recipeCondition;


                    db.Add(CourtPriceList);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return CourtPriceList;
        }

        [HttpGet("GetCourtPriceInf", Name = "GetCourtPriceInf")]
        public JsonResult GetCourtPriceInf(int ID)
        {


            CourtPriceList model = new CourtPriceList();

            try
            {
                model = db.courtPriceLists.Where(x => x.CourtPriceListId == ID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("UpdateCourtPriceList", Name = "UpdateCourtPriceList")]
        public JsonResult UpdateCourtPriceList(int id, string name, int courtPrice, string priceType, string recipeType, string condition)
        {
            CourtPriceList model = new CourtPriceList();

            try
            {

                model = db.courtPriceLists.Where(x => x.CourtPriceListId == id).SingleOrDefault();

                model.Name = name;
                model.CourtPrice = courtPrice;
                model.PriceType = priceType;
                model.RecipeType = recipeType;
                model.Condition = condition;

                db.Update(model);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("DeleteCourtPrice", Name = "DeleteCourtPrice")]
        public JsonResult DeleteCourtPrice(int id)
        {
            CourtPriceList model = new CourtPriceList();

            try
            {

                model = db.courtPriceLists.Where(x => x.CourtPriceListId == id).SingleOrDefault();

                if (model != null)
                {
                    db.Remove(model);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(true);
        }



        [HttpGet("GetCourtScaleInf", Name = "GetCourtScaleInf")]
        public JsonResult GetCourtScaleInf(int id)
        {


            CourtScaleList model = new CourtScaleList();

            try
            {
                model = db.courtScaleLists.Where(x => x.CourtScaleListId == id).SingleOrDefault();
               
                if (model != null)
                {

                    return Json(model);
                }
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(false);
        }

        [HttpGet("UpdateCourtScaleList", Name = "UpdateCourtScaleList")]
        public JsonResult UpdateCourtScaleList(int id, string name, string color, string code)
        {
            CourtScaleList model = new CourtScaleList();

            try
            {

                model = db.courtScaleLists.Where(x => x.CourtScaleListId == id).SingleOrDefault();

                if (model != null)
                {
                    model.Name = name;
                    model.Color = "#" + color;
                    model.Code = code;


                    db.Update(model);
                    db.SaveChanges();

                    return Json(model);
                }
               

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(false);
        }

        [HttpGet("AddNewCourtScale", Name = "AddNewCourtScale")]
        public JsonResult AddNewCourtScale(string scaleName, string scaleColor , string scaleCode)
        {

            CourtScaleList model = new CourtScaleList();

            try
            {
                if (scaleName != "" || scaleColor != "")
                {
                    model.Color = "#" + scaleColor;
                    model.Name = scaleName;
                    model.Code = scaleCode;

                    db.Add(model);
                    db.SaveChanges();

                    return Json(model);

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return Json(false);
        }

        [HttpGet("DeleteCourtScale", Name = "DeleteCourtScale")]
        public JsonResult DeleteCourtScale(int id)
        {
            CourtScaleList model = new CourtScaleList();

            try
            {

                model = db.courtScaleLists.Where(x => x.CourtScaleListId == id).SingleOrDefault();

                if (model != null)
                {
                    db.Remove(model);
                    db.SaveChanges();

                    return Json(model);
                }

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(false);
        }
        #endregion

        #region EducationSettings

        [HttpGet("GetSchoolSettings", Name = "GetSchoolSettings")]
        public EducationSettingsViewModel GetSchoolSettings()

        {

            EducationSettingsViewModel model = new EducationSettingsViewModel();

            try
            {
                model.schoolPriceTypes = db.schoolPriceTypes.ToList();
                model.schoolPrices = db.schoolPrices.ToList();
                model.schoolTypes = db.schoolTypes.ToList();
                model.schoolLevels = db.schoolLevels.ToList();
            }
            catch (Exception ex)
            {
                model = new EducationSettingsViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("NewSchoolType", Name = "NewSchoolType")]
        public SchoolType NewSchoolType(string schoolType, string schoolCode)
        {

            SchoolType model = new SchoolType();

            try
            {
                if (schoolCode != null || schoolType != null)
                {
                    model.Code = schoolCode;
                    model.Types = schoolType;


                    db.Add(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("DeleteSchoolType", Name = "DeleteSchoolType")]
        public SchoolType DeleteSchoolType(int id)
        {

            SchoolType model = new SchoolType();

            try
            {
                model = db.schoolTypes.Where(x => x.SchoolTypesId == id).SingleOrDefault();

                if (model != null)
                {

                    db.Remove(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetSchoolTypeInf", Name = "GetSchoolTypeInf")]
        public JsonResult GetSchoolTypeInf(int id)
        {

            SchoolType model = new SchoolType();

            try
            {
                model = db.schoolTypes.Where(x => x.SchoolTypesId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("GetPriceInf", Name = "GetPriceInf")]
        public JsonResult GetPriceInf(int id)
        {


            SchoolPrice model = new SchoolPrice();

            try
            {
                model = db.schoolPrices.Where(x => x.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("UpdateUpdateSchoolType", Name = "UpdateUpdateSchoolType")]
        public JsonResult UpdateUpdateSchoolType(int id, string code, string type)
        {
            SchoolType model = new SchoolType();

            try
            {

                model = db.schoolTypes.Where(x => x.SchoolTypesId == id).SingleOrDefault();

                model.Code = code;
                model.Types = type;


                db.Update(model);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }



        [HttpGet("NewSchoolLevel", Name = "NewSchoolLevel")]
        public SchoolLevel NewSchoolLevel(string levelName, int levelQuota)
        {

            SchoolLevel model = new SchoolLevel();

            try
            {
                if (levelName != null)
                {

                    model.Levels = levelName;


                    db.Add(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("DeleteSchoolLevel", Name = "DeleteSchoolLevel")]
        public SchoolLevel DeleteSchoolLevel(int id)
        {

            SchoolLevel model = new SchoolLevel();

            try
            {
                model = db.schoolLevels.Where(x => x.SchoolLevelId == id).SingleOrDefault();

                if (model != null)
                {

                    db.Remove(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetSchoolLevelInf", Name = "GetSchoolLevelInf")]
        public JsonResult GetSchoolLevelInf(int id)
        {


            SchoolLevel model = new SchoolLevel();

            try
            {
                model = db.schoolLevels.Where(x => x.SchoolLevelId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("UpdateUpdateSchoolLevel", Name = "UpdateUpdateSchoolLevel")]
        public JsonResult UpdateUpdateSchoolLevel(int id, string levelName)
        {
            SchoolLevel model = new SchoolLevel();

            try
            {

                model = db.schoolLevels.Where(x => x.SchoolLevelId == id).SingleOrDefault();


                model.Levels = levelName;


                db.Update(model);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }




        [HttpGet("GetPerformanceSettings", Name = "GetPerformanceSettings")]
        public EducationSettingsViewModel GetPerformanceSettings()

        {

            EducationSettingsViewModel model = new EducationSettingsViewModel();

            try
            {
                model.performanceTypes = db.performanceTypes.ToList();
                model.performanceLevels = db.performanceLevels.ToList();

            }
            catch (Exception ex)
            {
                model = new EducationSettingsViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }



        [HttpGet("NewPerformanceType", Name = "NewPerformanceType")]
        public PerformanceType NewPerformanceType(string code, string type)
        {

            PerformanceType model = new PerformanceType();

            try
            {
                if (code != null && type != null)
                {
                    model.PerformanceTypes = type;
                    model.PerformanceCode = code;


                    db.Add(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("DeletePerformanceType", Name = "DeletePerformanceType")]
        public PerformanceType DeletePerformanceType(int id)
        {

            PerformanceType model = new PerformanceType();

            try
            {
                model = db.performanceTypes.Where(x => x.PerformanceTypesId == id).SingleOrDefault();

                if (model != null)
                {

                    db.Remove(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetPerformanceTypeInf", Name = "GetPerformanceTypeInf")]
        public JsonResult GetPerformanceTypeInf(int id)
        {


            PerformanceType model = new PerformanceType();

            try
            {
                model = db.performanceTypes.Where(x => x.PerformanceTypesId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("UpdatePerfType", Name = "UpdatePerfType")]
        public JsonResult UpdatePerfType(int id, string code, string type)
        {
            PerformanceType model = new PerformanceType();

            try
            {

                model = db.performanceTypes.Where(x => x.PerformanceTypesId == id).SingleOrDefault();

                model.PerformanceCode = code;
                model.PerformanceTypes = type;


                db.Update(model);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }




        [HttpGet("NewPerformanceLevel", Name = "NewPerformanceLevel")]
        public PerformanceLevel NewPerformanceLevel(string level, int? quota)
        {

            PerformanceLevel model = new PerformanceLevel();

            try
            {
                if (level != null && quota != null)
                {
                    model.PerLevel = level;
                    model.PerQuotaInf = quota;


                    db.Add(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("DeletePerformanceLevel", Name = "DeletePerformanceLevel")]
        public PerformanceLevel DeletePerformanceLevel(int id)
        {

            PerformanceLevel model = new PerformanceLevel();

            try
            {
                model = db.performanceLevels.Where(x => x.PerLevelId == id).SingleOrDefault();

                if (model != null)
                {

                    db.Remove(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetPerformanceLevelInf", Name = "GetPerformanceLevelInf")]
        public JsonResult GetPerformanceLevelInf(int id)
        {


            PerformanceLevel model = new PerformanceLevel();

            try
            {
                model = db.performanceLevels.Where(x => x.PerLevelId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("UpdatePerfLevel", Name = "UpdatePerfLevel")]
        public JsonResult UpdatePerfLevel(int id, string level, int quota)
        {
            PerformanceLevel model = new PerformanceLevel();

            try
            {

                model = db.performanceLevels.Where(x => x.PerLevelId == id).SingleOrDefault();

                if (model.PerLevel != null && model.PerQuotaInf != null)
                {
                    model.PerLevel = level;
                    model.PerQuotaInf = quota;
                }


                db.Update(model);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }



        [HttpGet("GetPrivLessonSettings", Name = "GetPrivLessonSettings")]
        public EducationSettingsViewModel GetPrivLessonSettings()

        {

            EducationSettingsViewModel model = new EducationSettingsViewModel();

            try
            {
                model.privateLessons = db.privateLessons.ToList();

            }
            catch (Exception ex)
            {
                model = new EducationSettingsViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }



        [HttpGet("NewPrivLesson", Name = "NewPrivLesson")]
        public PrivateLesson NewPrivLesson(string inf, string type, int? price, int? teacherprice)
        {

            PrivateLesson model = new PrivateLesson();

            try
            {
                if (inf != null && type != null && type != null && type != null)
                {
                    model.TariffeInf = inf;
                    model.PrivateLessonType = type;
                    model.PrivateLessonPrice = price;
                    model.TeacherPrice = teacherprice;


                    db.Add(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("DeletePrivateLesson", Name = "DeletePrivateLesson")]
        public PrivateLesson DeletePrivateLesson(int id)
        {

            PrivateLesson model = new PrivateLesson();

            try
            {
                model = db.privateLessons.Where(x => x.PrivateLessonId == id).SingleOrDefault();

                if (model != null)
                {

                    db.Remove(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("GetPrivLessonInf", Name = "GetPrivLessonInf")]
        public JsonResult GetPrivLessonInf(int id)
        {

            PrivateLesson model = new PrivateLesson();

            try
            {
                model = db.privateLessons.Where(x => x.PrivateLessonId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("UpdatePrivLesson", Name = "UpdatePrivLesson")]
        public JsonResult UpdatePrivLesson(int id, string tariffeInf, string privLesType, int? privLesPrice, int? teacherPrice)
        {
            PrivateLesson model = new PrivateLesson();
            try
            {
                model = db.privateLessons.Where(x => x.PrivateLessonId == id).SingleOrDefault();
                if (model != null)
                {
                    model.TariffeInf = tariffeInf;
                    model.PrivateLessonType = privLesType;
                    model.PrivateLessonPrice = privLesPrice;
                    model.TeacherPrice = teacherPrice;
                }
                db.Update(model);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);
                return Json(new PrivateLesson());
            }

            return Json(model);
        }


        #endregion

        #region ReservationSettings

        [HttpGet("GetReservationSettings", Name = "GetReservationnSettings")]
        public ReservationSettingsViewModel GetReservationSettings()

        {

            ReservationSettingsViewModel model = new ReservationSettingsViewModel();

            try
            {
                model.reservationSettings = db.reservationSettings.ToList();

            }
            catch (Exception ex)
            {
                model = new ReservationSettingsViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }



        [HttpGet("NewResSet", Name = "NewResSet")]
        public ReservationSettings NewResSet(string setInf, string setVal)
        {

            ReservationSettings model = new ReservationSettings();

            try
            {
                if (setInf != null || setVal != null)
                {
                    model.ReservationSettingsInf = setInf;
                    model.ReservationValue = setVal;


                    db.Add(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("DeleteResSet", Name = "DeleteResSet")]
        public ReservationSettings DeleteResSet(int id)
        {

            ReservationSettings model = new ReservationSettings();

            try
            {
                model = db.reservationSettings.Where(x => x.ReservationSettingsId == id).SingleOrDefault();

                if (model != null)
                {

                    db.Remove(model);
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("UpdateResSet", Name = "UpdateResSet")]
        public ReservationSettings UpdateResSet(string updStr)
        {

            ReservationSettings model = new ReservationSettings();

            string[] updList = updStr.Split("-");


            try
            {
                foreach (var item in updList)
                {
                    var id = item.Split("_")[0];
                    var value = item.Split("_")[1];

                    model = db.reservationSettings.Where(x => x.ReservationSettingsId == Convert.ToInt32(id)).SingleOrDefault();

                    if (model != null)
                    {
                        model.ReservationValue = value;
                        db.Update(model);
                        db.SaveChanges();

                    }
                }
            }

            catch (Exception ex)
            {

                Mutuals.monitizer.AddException(ex);

                return new ReservationSettings();

            }

            return model;
        }

        #endregion

        #region MemberSettings

        [HttpGet("MemberSettings", Name = "MemberSettings")]
        public MemberSettingsViewModel MemberSettings()

        {

            MemberSettingsViewModel model = new MemberSettingsViewModel();

            try
            {
                model.cabinetOperations = db.cabinetOperations.ToList();
                model.cabinetTypes = db.cabinetTypes.ToList();

            }
            catch (Exception ex)
            {
                model = new MemberSettingsViewModel();
                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("AddCabinetType", Name = "AddCabinetType")]
        public JsonResult AddCabinetType(string type , int price)
        {

            CabinetType model = new CabinetType();

            try
            {
                model.CabinetTypes = type;
                model.CabinetTypesPrice = price;


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

            return Json(model);
        }

        [HttpGet("DeleteCabinetType", Name = "DeleteCabinetType")]
        public JsonResult DeleteCabinetType(int id)
        {

            CabinetType model = new CabinetType();

            try
            {
                model = db.cabinetTypes.Where(x => x.CabinetId == id).FirstOrDefault();
               

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

            return Json(model);
        }

        [HttpGet("MemberDuesSettings", Name = "MemberDuesSettings")]
        public JsonResult MMemberDuesSettings(int id)
        {

            List<MemberDuesType> model = new List<MemberDuesType>();

            try
            {
                model = db.memberDuesTypes.ToList();


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
                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);
        }


        [HttpGet("AddCabinets", Name = "AddCabinets")]
        public JsonResult AddCabinets(string code, string cabType)
        {

            CabinetOperations model = new CabinetOperations();

            model = db.cabinetOperations.FirstOrDefault(x => x.CabinetCode == code.Trim());

            if (model == null)
            {
                try
                {
                    model.CabinetCode = code;
                    model.CabinetOpTypes = cabType;


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
            }

            else
            {
                return Json(false);
            }

            return Json(model);
        }

        [HttpGet("DeleteCabinetSet", Name = "DeleteCabinetSet")]
        public JsonResult DeleteCabinetSet(int id)
        {
            CabinetOperations model = new CabinetOperations();


            if (id == null)
            {
                return Json(false);
            }

            else
            {
                try
                {

                    model = db.cabinetOperations.Where(x => x.CabinetOpId == id).FirstOrDefault();

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
        #endregion

    }
}
