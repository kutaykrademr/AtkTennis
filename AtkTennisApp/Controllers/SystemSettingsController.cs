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
        public AppIdentityRole NewRole( string roleName)
        {

            var Role = new AppIdentityRole();
            var Role2 = new UserSettings();

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
                    Role2.System = false;
                    Role2.DebtandPayment = false;

                    db.Add(Role2);
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
            var Role2 = new UserSettings();
            try
            {
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";       
                }

                else
                {

                    var result = await roleManager.DeleteAsync(role);
                    Role2 = db.userSettings.Where(x => x.RoleId == role.Id ).FirstOrDefault();

                    if (Role2.RoleId != null)
                    {
                        db.Remove(Role2);
                        db.SaveChanges();

                    }


                    if (result.Succeeded)
                    {
                        return Json(role);
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

                model = await roleManager.FindByIdAsync(id);

                if (model != null)
                {                   
                    model.NormalizedName = roleName;
                    model.Name = roleName;
                }

                var result = await roleManager.UpdateAsync(model);

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
                        if(item == Convert.ToInt32(item2.Split("_")[1]))
                        {
                            activeAuth.Add(item2.Split("_")[0]);
                        }

                    }

                    UserSettings model2 = db.userSettings.SingleOrDefault(x => x.UserSettingsId == item);

                    if (activeAuth.Contains("System"))
                        model2.System = true;
                    else
                        model2.System = false;
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


        #endregion

        #region CourtSettings 

        [HttpGet("GetCourt", Name = "GetCourt")]
        public CourtSettingsViewModel GetCourt()

        {
           CourtSettingsViewModel model = new CourtSettingsViewModel();
         
           
            try
            {
                model.courtPriceLists = db.courtPriceLists.ToList();
                model.Courts = db.courts.ToList();

            }
            catch (Exception ex)
            {
                model = new CourtSettingsViewModel();
                
                Mutuals.monitizer.AddException(ex);
            }

            return model;
          
        }



        [HttpGet("NewCourt", Name = "NewCourt")]
        public Court NewCourt(string courtName, string courtType, string courtCondition, string courtWebCondition)
        {

            var Court = new Court();

            try
            {
                if (courtName != null || courtType != null || courtCondition != null || courtWebCondition != null)
                {
                    Court.CourtName = courtName;
                    Court.CourtType = courtType;
                    Court.CourtConditions = courtCondition;
                    Court.CourtWebConditions = courtWebCondition;


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
        public JsonResult UpdateCourt(int id , string courtName, string courtType, string courtCondition, string courtWebCondition)
        {
            Court model = new Court();

            try
            {

                model = db.courts.Where(x => x.CourtId == id).SingleOrDefault();

                model.CourtName = courtName;
                model.CourtType = courtType;
                model.CourtConditions = courtCondition;
                model.CourtWebConditions = courtWebCondition;

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
                if (recipeName != null ||  recipePriceType != null || courtRecipeType != null || recipeCondition != null)
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
        public JsonResult UpdateCourtPriceList(int id, string name, int courtPrice, string priceType, string recipeType , string condition)
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

        #endregion

        #region SchoolSettings

        [HttpGet("GetSchoolSettings", Name = "GetSchoolSettings")]
        public EducationSettingsViewModel GetSchoolSettings()

        {

            EducationSettingsViewModel model = new EducationSettingsViewModel();

            try
            {
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

        #endregion
    }
}
