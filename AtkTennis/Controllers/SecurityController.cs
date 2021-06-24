using AtkTennis.Models;
using AtkTennis.Security;
using AtkTennis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace AtkTennis.Controllers
{   
   
    public class SecurityController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public SecurityController(UserManager<AppIdentityUser> userManager,
            RoleManager<AppIdentityRole> roleManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }



        Context db = new Context();


        #region Views

        [Authorize]
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
    

        [Authorize]
        [HttpGet]
        public IActionResult RegisterMember()
        {

            return View();
        }
        
     

        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel register)
        {

            if (ModelState.IsValid)
            {

                var role = new AppIdentityRole();

                if (!roleManager.RoleExistsAsync(register.Registers.Role).Result)
                {
                    
                    role.Name = register.Registers.Role;
                    role.Description = "Can Perform Crud Operations";
                    var roleResult = roleManager.CreateAsync(role).Result;
                }

                var user = new AppIdentityUser();


                user.UserName = register.Registers.UserName;
                user.Email = register.Registers.Email;
                user.FullName = register.Registers.FullName;
                user.BirthDate = register.Registers.BirthDate;
                user.PhoneNumber = register.AppIdentityUsers.PhoneNumber;
                role.Name = register.Registers.Role;

              

                var result = userManager.CreateAsync(user, register.Registers.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, role.Name).Wait();
                    return RedirectToAction("AdminHome", "Admin");

                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Details");
                }
            }
            return View(register);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]       
        public IActionResult RegisterMember(RegisterViewModel register)
        {


            if (ModelState.IsValid)
            {
                if (!roleManager.RoleExistsAsync("Member").Result)
                {
                    var role = new AppIdentityRole();
                    role.Name = "Member";
                    role.Description = "Can Perform Crud Operations";
                    var roleResult = roleManager.CreateAsync(role).Result;
                }

                var user = new AppIdentityUser();
                user.UserName = register.Registers.UserName;
                user.Email = register.Registers.Email;
                user.FullName = register.Registers.FullName;
                user.BirthDate = register.Registers.BirthDate;

                user.PhoneNumber = register.AppIdentityUsers.PhoneNumber;


                var result = userManager.CreateAsync(user, register.Registers.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                    return RedirectToAction("AdminHome", "Admin");

                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Details");
                }
            }
            return View(register);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(signIn.UserName, signIn.Password, signIn.RememberMe, false).Result;

                if (result.Succeeded)
                    return RedirectToAction("AdminHome", "Admin");
                else
                    ModelState.AddModelError("", "Invalid User Details");
            }

            return View(signIn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public IActionResult SignOut()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("SignIn", "Security");
        }

        [Authorize]
        public IActionResult ListUsers()
        {


            var model = new AtkTennis.ViewModels.IdentityPartialClass();

            model.AppIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();
            model.AppIdentityRoles = (List<AppIdentityRole>)roleManager.Roles.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task< IActionResult> DeleteUsers(string id)

        {
            var user = await userManager.FindByIdAsync(id);
            var roles = await userManager.GetRolesAsync(user);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("Not Found");
            }
            else
            {
               
               var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> UpdateUser(string id, string userName, string fullName, string phoneNumber, string email)
        {
            var user = await userManager.FindByIdAsync(id);
            var roles = await userManager.GetRolesAsync(user);

            AppIdentityUser model = new AppIdentityUser();

            try
            {
                model = userManager.Users.SingleOrDefault(x => x.Id == id);

                model.UserName = userName;
                model.FullName = fullName;
                model.PhoneNumber = phoneNumber;
                model.Email = email;

                var result = await userManager.UpdateAsync(model);
            }
            catch (Exception)
            {
                
            }

            var model2 = new AtkTennis.ViewModels.IdentityPartialClass();

            try
            {
                model2.AppIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();
            }
            catch (Exception)
            {
            }
            return Json(model2);
        }

        [HttpGet]
        public JsonResult GetUser(string ID)
        {
            AppIdentityUser model = new AppIdentityUser();

            try
            {
                model = userManager.Users.SingleOrDefault(x => x.Id == ID);
            }
            catch (Exception)
            {
                return Json(model);
            }
            
            return Json(model);
        }


    


    }
}

