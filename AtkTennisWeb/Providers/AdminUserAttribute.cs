using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisWeb.Providers
{
    public class AdminUserAttribute : ActionFilterAttribute
    {
        public AdminUserAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            try
            {
                bool control = false;

                var role = context.HttpContext.Session.GetString("Role");

                if ( role == "Yönetici" || role == "Sekreterya")
                {
                    control = true;
                }
           

                if (!control)
                {
                    context.Result = new RedirectResult("../Public/Error403");
                }
            }
            catch
            {
                context.Result = new RedirectResult("../Public/SignIn");
            }

        }
    }
}
