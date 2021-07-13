using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto
{
    public class SignInDto
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string custom_userid { get; set; }
        public string custom_name { get; set; }
        public string custom_role { get; set; }
        public string custom_roleId { get; set; }
        public string custom_nickName { get; set; }

    }
}
