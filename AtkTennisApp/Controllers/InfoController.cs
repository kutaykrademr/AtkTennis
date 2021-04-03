using Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class InfoController : Controller
    {
        [HttpGet("GetAppInfo", Name = "GetAppInfo")]
        public MonitizerResult GetAppInfo()
        {
            return Mutuals.monitizer.GetMonitizerResult();
        }
    }
}
