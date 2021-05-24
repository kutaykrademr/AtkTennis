using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers.Dto;
using AtkTennisApp.Models;
using AtkTennisApp.Security;
using Microsoft.AspNetCore.Identity;
using AtkTennis.Models;
using AtkTennisApp.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AtkTennisApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublicController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;
     
       

        public PublicController(UserManager<AppIdentityUser> userManager,
            RoleManager<AppIdentityRole> roleManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;

        }

        

        Context db = new Context();

        [HttpGet("GetMySettings", Name = "GetMySettings")]
        public MutualsConstantsDto GetMySettings()
        {
            MutualsConstantsDto model = new MutualsConstantsDto();

            model.M1 = MutualConstants.M1;
            model.M2 = MutualConstants.M2;
            model.M3 = MutualConstants.M3;
            model.M4 = MutualConstants.M4;
            model.M5 = MutualConstants.M5;
            model.M6 = MutualConstants.M6;
            model.PhotoUrl = MutualConstants.PhotoUrl;
            model.SunucuIp = MutualConstants.SunucuIp;
            model.CompanyName = MutualConstants.CompanyName;
            model.ExpirationDate = MutualConstants.ExpirationDate;

            return model;
        }

       


        [HttpGet("SignIn", Name = "SignIn")]
        public SignIn SignIn(string UserName, string Password)
        {

            SignIn Model2 = new SignIn();

            Model2.UserName = UserName;
            Model2.Password = Password;

            SignIn model = new SignIn();
            if (ModelState.IsValid)
            {
                
                try
                {
                    var result = signInManager.PasswordSignInAsync(Model2.UserName, Model2.Password, Model2.RememberMe, false).Result;
                    
                    if (!result.Succeeded)
                        return new SignIn();
                    
                }
                catch (Exception ex )
                {

                    Mutuals.monitizer.AddException(ex);
                    return new SignIn();
                }

                model.UserName = Model2.UserName;
                model.Password = Model2.Password;
                model.custom_userid = signInManager.UserManager.Users.SingleOrDefault(x => x.UserName == UserName).Id;
            }

            return model;
        }

        [HttpGet("GetRes", Name = "GetRes")]
        public ReservationViewModel GetRes()

        {
            ReservationViewModel model = new ReservationViewModel();
            


            try
            {
                model.resTimes = db.resTimes.ToList();
                model.courts = db.courts.ToList();
                model.reservations = db.reservations.ToList();
                model.appIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();
            }
            catch (Exception ex)
            {
                model = new ReservationViewModel();

                Mutuals.monitizer.AddException(ex);
            }

            return model;

        }
    }
}
