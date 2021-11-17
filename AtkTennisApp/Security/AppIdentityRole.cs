using AtkTennisApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Security
{
    public class AppIdentityRole : IdentityRole
    {
        public string Description { get; set; }
        public string CompanyId { get; set; }

    }
}
