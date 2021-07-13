using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class SignIn
    {
        [Required]
        [Display(Name="Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string custom_userid { get; set; }
        public string custom_name { get; set; }
        public string custom_role { get; set; }
        public string custom_roleId { get; set; }
        public string custom_nickName { get; set; }
    }
}
