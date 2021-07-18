using AtkTennisApp.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public  class UserSettings
    {
        [Key]
        public int UserSettingsId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Dashboard { get; set; }
        public bool Advisory { get; set; }
        public bool Reservations { get; set; }
        public bool DebtandPayment { get; set; }
        public bool SystemSettings { get; set; }
        
     
    }
}