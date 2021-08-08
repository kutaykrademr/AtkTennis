using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisWeb.Providers
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        public AuthorizeUserAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            DateTime today = DateTime.Now;
            var date = today.ToString("yyyy-MM-dd");

            try
            {
                bool control = true;

                if (context.HttpContext.Session.GetString("UserId") == null)
                {
                    control = false;
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
