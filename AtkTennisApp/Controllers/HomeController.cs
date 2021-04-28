﻿using AtkTennisApp.Security;
using AtkTennisApp.ViewModels;
using Helpers.Dto.ViewDtos;
using Helpers.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public HomeController(UserManager<AppIdentityUser> userManager,
            RoleManager<AppIdentityRole> roleManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [HttpGet("GetHome", Name = "GetHome")]
        public HomeModelDto GetHome()
        {
           
            HomeModelDto model = new HomeModelDto();
            try
            {   
                model.TotalUserCount = userManager.Users.Count();
                model.TotalRoleCount = roleManager.Roles.Count();
            }
            catch (Exception ex)
            {
                model = new HomeModelDto();
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


        [HttpGet("NewRegister", Name = "NewRegister")]
        public AppIdentityUser NewRegister(string name, string username, string phone, string password, string birthdate, string gender, string email, string role)
        {

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
                user.BirthDate = Convert.ToDateTime(birthdate);
                user.PhoneNumber = phone;
                Role.Name = role;

                var result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, role).Wait();

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


    }

}