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

                if (context.HttpContext.Session.GetString("Role") == "Yönetici")
                {
                    control = true;
                }
           

                if (!control)
                {
                    context.Result = new RedirectResult("../Public/SignIn");
                }
            }
            catch
            {
                context.Result = new RedirectResult("../Public/SignIn");
            }

        }
    }
}
