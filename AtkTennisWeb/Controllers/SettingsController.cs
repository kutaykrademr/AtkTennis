using Helpers.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisWeb.Controllers
{
    public class SettingsController : Controller
    {
        [HttpGet]
        public JsonResult GetSettings(string companyId)
        {

            try
            {
                
              var model = Helpers.Serializers.DeserializeJson<MutualsConstantsDto>(Helpers.Request.Get(Mutuals.AppUrl + "Settings/GetMySettings2?companyId=" + companyId));

                if (model != null)
                {
                    Mutuals.CompName = model.CompanyName;
                    Mutuals.M1 = model.M1;
                    Mutuals.M2 = model.M2;
                    Mutuals.M3 = model.M3;
                    Mutuals.M4 = model.M4;
                    Mutuals.M5 = model.M5;
                    Mutuals.M6 = model.M6;
                }
                else
                {
                    return Json("false");
                }

                foreach (var item in model.UserSettingsList)
                {
                    if (Mutuals.UserSettings.ContainsKey(item.RoleId))
                        Mutuals.UserSettings[item.RoleId] = item;
                    else
                        Mutuals.UserSettings.Add(item.RoleId, item);
                }

            }
            catch (Exception ex)
            {
                return Json("false");
            }

            return Json("true");

        }
    }
}
