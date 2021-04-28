using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtkTennis.Models;
using Microsoft.AspNetCore.Authorization;
using AtkTennis.ViewModels;
using Microsoft.AspNetCore.Identity;
using AtkTennis.Security;

[Authorize]
public class AdminController : Controller
{

    private readonly UserManager<AppIdentityUser> userManager;
    private readonly RoleManager<AppIdentityRole> roleManager;
    private readonly SignInManager<AppIdentityUser> signInManager;

    public AdminController(UserManager<AppIdentityUser> userManager,
        RoleManager<AppIdentityRole> roleManager,
        SignInManager<AppIdentityUser> signInManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.signInManager = signInManager;
    }


    Context db = new Context();

    public IActionResult AdminHome()
    {
        var model = new AdminHomeModel();

        model.TotalUserCount = userManager.Users.Count();
        model.TotalRoleCount = roleManager.Roles.Count();


        return View(model);
    }

    public IActionResult CourtSettings()
    {
        var model = new CourtSettingsViewModel();

        model.courtPriceLists = db.courtPriceLists.ToList();
        model.Courts = db.courts.ToList();

        return View(model);
    }

    public IActionResult Reservation()
    {
        var model = new AdminViewModel();

        model.Res = db.reservations.ToList();
        model.Courts = db.courts.ToList();
        model.Times = db.resTimes.ToList();
        model.AppIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();

        return View(model);

    }

    
    public IActionResult ReservationTable()
    {
        var model = new AdminViewModel();

        model.Res = db.reservations.ToList();
        model.Courts = db.courts.ToList();
        model.Times = db.resTimes.ToList();

        return View(model);
    }

    [HttpPost]
    public JsonResult NewReservation(Reservation res, int CId)
    {

        var model = new Reservation();

        try
        {
            res.courts = db.courts.Where(x => x.CourtId == CId).SingleOrDefault();
            model = db.reservations.Where(x => x.ResStartTime == res.ResStartTime && x.ResFinishTime == res.ResFinishTime && x.courts.CourtId == CId).FirstOrDefault();
            
        }

        catch (Exception e)
        {
            return Json("false");

        }


        if (model == null)
        {
            try
            {
                db.reservations.Add(res);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return Json("false");

            }

            return Json("true");
        }
        else
            return Json("false");




    }

    [HttpGet]
    public JsonResult GetCourtInf(int ID)
    {


        Court model = new Court();

        model = db.courts.Where(x => x.CourtId == ID).SingleOrDefault();



        return Json(model);
    }

    [HttpPost]
    public JsonResult UpdateCourtInf(int id, string courtName, string courtType, string courtConditions, string courtWebConditions)
    {


        Court model = new Court();
        try
        {
            model = db.courts.Where(x => x.CourtId == id).SingleOrDefault();

            model.CourtName = courtName;
            model.CourtType = courtType;
            model.CourtConditions = courtConditions;
            model.CourtWebConditions = courtWebConditions;

            db.courts.Update(model);
            db.SaveChanges();
        }
        catch (Exception)
        {


        }
        return Json(model);
    }

    [HttpPost]
    public JsonResult addCourt(string courtName, string courtType, string courtConditions, string courtWebConditions)
    {
        Court model = new Court();
        try
        {
            model.CourtName = courtName;
            model.CourtType = courtType;
            model.CourtConditions = courtConditions;
            model.CourtWebConditions = courtWebConditions;

            db.courts.Add(model);
            db.SaveChanges();
        }
        catch (Exception)
        {
            return Json("false");
        }
        return Json("true");
    }

    public JsonResult CourtDelete(int ID)

    {
        Court model = new Court();
        List<Reservation> model2 = new List<Reservation>();

        try
        {
            model2 = db.reservations.Where(x => x.courts.CourtId == ID).ToList();

            if (model2.Count == 0)
            {
                model = db.courts.Where(x => x.CourtId == ID).SingleOrDefault();

                db.courts.Remove(model);
                db.SaveChanges();
            }
            else
            {
                return Json("false");
            }
        }
        catch (Exception ex)
        {
        }

        return Json("true");
    }

    [HttpGet]
    public JsonResult CourtForceDelete(int ID)

    {
        Court model = new Court();
        List<Reservation> model2 = new List<Reservation>();

        try
        {
            model2 = db.reservations.Where(x => x.courts.CourtId == ID).ToList();

            db.reservations.RemoveRange(model2);
            db.SaveChanges();

            model = db.courts.Where(x => x.CourtId == ID).SingleOrDefault();

            db.courts.Remove(model);
            db.SaveChanges();

        }
        catch (Exception ex)
        {
            return Json("false");
        }

        return Json("true");


    }

    [HttpGet]
    public JsonResult GetCourtOperations(int ID)
    {


        CourtPriceList model = new CourtPriceList();

        model = db.courtPriceLists.Where(x => x.CourtPriceListId == ID).SingleOrDefault();



        return Json(model);

    }

    [HttpPost]
    public JsonResult PostCourtOperations(int ID, string name, int courtPrice, string priceType, string recipeType, string condition)
    {

        CourtPriceList model = new CourtPriceList();

        model = db.courtPriceLists.Where(x => x.CourtPriceListId == ID).SingleOrDefault();

        model.Name = name;
        model.CourtPrice = courtPrice;
        model.PriceType = priceType;
        model.RecipeType = recipeType;
        model.Condition = condition;

        db.courtPriceLists.Update(model);
        db.SaveChanges();

        return Json(model);

    }

    public JsonResult CourtOperationsDelete(int ID)

    {
        CourtPriceList model = new CourtPriceList();

        try
        {
            if (model != null)
            {
                model = db.courtPriceLists.Where(x => x.CourtPriceListId == ID).SingleOrDefault();

                db.courtPriceLists.Remove(model);
                db.SaveChanges();

            }

            else
            {
                return Json("false");
            }

        }

        catch (Exception Ex)
        {

        }
        return Json("true");

    }
}




