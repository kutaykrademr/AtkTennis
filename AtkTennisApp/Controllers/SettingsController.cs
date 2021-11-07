using AtkTennis.Models;
using Helpers;
using Helpers.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        Context db = new Context();

        [HttpGet("GetMySettings2", Name = "GetMySettings2")]
        public JsonResult GetMySettings2(string companyId)
        {
            MutualConstants mut = new MutualConstants();
            MutualsConstantsDto appLogList = new MutualsConstantsDto();

            try
            {



                appLogList = Serializers.DeserializeJson<MutualsConstantsDto>(Helpers.Request.Get(Mutuals.AdminUrl + "Product/GetMySettings?MyIp=" + companyId));
                appLogList.UserSettingsList = new List<Helpers.Dto.ViewDtos.UserSettingsDto>();
                var a = db.userSettings.ToList();
                foreach (var item in a)
                {
                    appLogList.UserSettingsList.Add(new Helpers.Dto.ViewDtos.UserSettingsDto() { Advisory = item.Advisory, Dashboard = item.Dashboard, DebtandPayment = item.DebtandPayment, MemberDebtList = item.MemberDebtList, Reports = item.Reports, Reservations = item.Reservations, RoleId = item.RoleId, RoleName = item.RoleName, SystemSettings = item.SystemSettings, UserSettingsId = item.UserSettingsId });
                }


                if (appLogList != null)

                    mut.CompanyName = appLogList.CompanyName;
                mut.SunucuIp = appLogList.SunucuIp;

                if (appLogList == null)
                {
                    mut.M1 = false;
                    mut.M2 = false;
                    mut.M3 = false;
                    mut.M4 = false;
                    mut.M5 = false;
                    mut.M6 = false;
                }

                else
                {
                    if (appLogList.M1 != null)
                        mut.M1 = appLogList.M1;
                    else
                        mut.M1 = false;

                    if (appLogList.M2 != null)
                        mut.M2 = appLogList.M2;
                    else
                        mut.M2 = false;

                    if (appLogList.M3 != null)
                        mut.M3 = appLogList.M3;
                    else
                        mut.M3 = false;

                    if (appLogList.M4 != null)
                        mut.M4 = appLogList.M4;
                    else
                        mut.M4 = false;

                    if (appLogList.M5 != null)
                        mut.M5 = appLogList.M5;
                    else
                        mut.M5 = false;

                    if (appLogList.M6 != null)
                        mut.M6 = appLogList.M6;
                    else
                        mut.M6 = false;
                }


            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex);
            }

            return Json(appLogList);
        }


    }
}
