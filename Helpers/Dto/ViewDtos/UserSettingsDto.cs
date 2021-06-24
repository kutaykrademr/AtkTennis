using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class UserSettingsDto
    {
       
        public int UserSettingsId { get; set; }
        public string RoleName { get; set; }
        public bool Advisory { get; set; }
        public bool Reservations { get; set; }
        public bool DebtandPayment { get; set; }
        public bool SystemSettings { get; set; }
        public string RoleId { get; set; }
    }
}
