using AtkTennisApp.Security;
using AtkTennisApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtkTennisApp.Models;
using AtkTennis.Models;
using Microsoft.AspNetCore.Http;

namespace AtkTennisApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminHomeController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public AdminHomeController(UserManager<AppIdentityUser> userManager,
            RoleManager<AppIdentityRole> roleManager,
            SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        Context db = new Context();

        [HttpGet("GetHome", Name = "GetHome")]
        public HomeModelView GetHome()
        {
            DateTime date1 = DateTime.Now;
            var today = date1.ToString("yyyy-MM-dd");

            HomeModelView model = new HomeModelView();
          

            try
            {
                model.TotalUserCount = userManager.Users.Count();
                model.TotalRoleCount = roleManager.Roles.Count();
                var b = db.reservations.Where(x => x.ResDate == today).ToList();
                var a = db.reservations.ToList();
                model.TodayResCount = b.Count();
                model.TotalResCount = a.Count();
                model.toDoLists = db.toDoLists.ToList();
                model.reservations = db.reservations.ToList();
                model.courts = db.courts.ToList();

                
            }
            catch (Exception ex)
            {
                model = new HomeModelView();
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
        public AppIdentityUser NewRegister(string name, string nickName, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role)
        {
            MemberList model2 = new MemberList();

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
                user.BirthDate = birthdate;
                user.PhoneNumber = phone;
                Role.Name = role;

                var result = userManager.CreateAsync(user, password).Result;

                var id = user.Id;

                model2.UserId = id;
                model2.FullName = name;
                model2.NickName = nickName;
                model2.Gender = gender;
                model2.UserName = username;
                model2.StartDate = startDate;
                model2.FinishDate = finishDate;
                model2.Role = role;
                model2.Condition = condition;
                model2.IdentityNumber = identificationNumber;
                model2.WebReservation = webReservation;
                model2.Phone = phone;
                model2.PhoneExp = phoneExp;
                model2.Phone2 = phone2;
                model2.Phone2Exp = phone2Exp;
                model2.Email = email;
                model2.EmailExp = emailExp;
                model2.BirthDate = birthdate;
                model2.BirthPlace = birthPlace;
                model2.MotherName = motherName;
                model2.FatherName = fatherName;
                model2.City = city;
                model2.District = district;
                model2.Job = job;
                model2.Note = note;
                model2.Password = password;

               
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                    db.Add(model2);
                    db.SaveChanges();
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

        [HttpGet("GetUser", Name = "GetUser")]
        public IdentityPartialClass GetUser()

        {
            IdentityPartialClass model = new IdentityPartialClass();

            try
            {
                model.AppIdentityUsers = (List<AppIdentityUser>)userManager.Users.ToList();
                model.AppIdentityRoles = (List<AppIdentityRole>)roleManager.Roles.ToList();
                model.memberLists = db.memberLists.ToList();

            }
            catch (Exception ex)
            {
                model.AppIdentityRoles = new List<AppIdentityRole>();
                model.AppIdentityUsers = new List<AppIdentityUser>();

                Mutuals.monitizer.AddException(ex);
            }

            return model;
        }

        [HttpGet("UpdateMemberList", Name = "UpdateMemberList")]
        public async Task<JsonResult> UpdateMemberList(string id, string checkpass, string name, string username, string startDate, string finishDate, string condition, string identificationNumber, string webReservation, string phoneExp, string phone2, string phone2Exp, string email, string emailExp, string birthPlace, string motherName, string fatherName, string city, string district, string job, string note, string phone, string password, string birthdate, string gender, string role)
        {
            AppIdentityUser model = new AppIdentityUser();
            MemberList model2 = new MemberList();


            try
            {


                model = await userManager.FindByIdAsync(id);

                model2 = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();


                if (model != null)
                {
                    model.UserName = username;
                    model.Email = email;
                    model.FullName = name;
                    model.BirthDate = birthdate;
                    model.PhoneNumber = phone;

                }


                model2.BirthDate = birthdate;
                model2.BirthPlace = birthPlace;
                model2.City = city;
                model2.Condition = condition;
                model2.District = district;
                model2.Email = email;
                model2.EmailExp = emailExp;
                model2.FatherName = fatherName;
                model2.FinishDate = finishDate;
                model2.FullName = name;
                model2.Gender = gender;
                model2.IdentityNumber = identificationNumber;
                model2.Job = job;
                model2.MotherName = motherName;
                model2.Note = note;
                model2.Password = password;
                model2.Phone = phone;
                model2.Phone2 = phone2;
                model2.Phone2Exp = phone2Exp;
                model2.PhoneExp = phoneExp;
                model2.StartDate = startDate;
                model2.UserName = username;
                model2.WebReservation = webReservation;
                model2.Role = role;



                var user = await userManager.FindByIdAsync(id);
                var role_to_remove = await userManager.GetRolesAsync(user);
                var result = await userManager.RemoveFromRoleAsync(user, role_to_remove[0]);

                var newRole = await userManager.AddToRoleAsync(user, role);

                if (model2.Password != checkpass)
                {
                    var res = await userManager.ChangePasswordAsync(user, checkpass, password);
                    if (res.Succeeded == false)
                    {
                        return Json(false);
                    }
                    await signInManager.RefreshSignInAsync(user);
                }

                var result2 = userManager.UpdateAsync(model).Result;
                db.Update(model2);
                db.SaveChanges();


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);

            }

            return Json(model);
        }

        [HttpGet("GetMemberListInf", Name = "GetMemberListInf")]
        public JsonResult GetMemberListInf(string id)

        { 
            MemberList model = new MemberList();

            try
            {
                model = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                model = new MemberList();
                Mutuals.monitizer.AddException(ex);
            }

            return Json(model);
        }

        [HttpGet("DeleteUser", Name = "DeleteUser")]
        public async Task<JsonResult> DeleteUser(string id)
        {
            AppIdentityUser model = new AppIdentityUser();
            var user = await userManager.FindByIdAsync(id);

            MemberList user2 = new MemberList();
            user2 = db.memberLists.Where(x => x.UserId == id).FirstOrDefault();

            if (user == null || user2 == null)
            {
                return Json(false);
            }

            else
            {
                try
                {
                    var result = await userManager.DeleteAsync(user);


                    if (result.Succeeded)
                    {
                        db.Remove(user2);
                        db.SaveChanges();

                        return Json(user2);
                    }
                }

                catch (Exception ex)
                {
                    Mutuals.monitizer.AddException(ex);

                }
                return Json(true);
            }
        }

        [HttpGet("AddToDo", Name = "AddToDo")]
        public JsonResult AddToDo(string toDo , string today)
        {
            ToDoList model = new ToDoList();
           

            if (toDo == null || today == null)
            {
                return Json(false);
            }

            else
            {
                try
                {
                    model.Date = today;
                    model.ToDo = toDo;


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
                return Json(true);
            }
        }


    }

}
