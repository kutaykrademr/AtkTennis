using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtkTennis.Models;
using Microsoft.AspNetCore.Authorization;




[Authorize]
public class AdminController : Controller
{
    Context db = new Context();

    public IActionResult AdminHome()
    {
        var model = new AtkTennis.ViewModels.AdminViewModel();

        model.Res = db.reservations.ToList();
        model.Courts = db.courts.ToList();
        model.Times = db.resTimes.ToList();

        return View(model);
    }

   

    public IActionResult Reservation()
    {
        var model = new AtkTennis.ViewModels.AdminViewModel();

        model.Res = db.reservations.ToList();
        model.Courts = db.courts.ToList();
        model.Times = db.resTimes.ToList();

     


        return View(model);
      
    }
    
    public IActionResult Main()
    {
        var model = new AtkTennis.ViewModels.AdminViewModel();

        model.Res = db.reservations.ToList();
        model.Courts = db.courts.ToList();
        model.Times = db.resTimes.ToList();

        return View(model);
    }


    [HttpPost]
   

    public JsonResult NewReservation(Reservation res , int CId)
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


}




