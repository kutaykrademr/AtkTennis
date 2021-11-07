using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class ReservationSettings
    {
        [Key]
        public int? ReservationSettingsId { get; set; }
        public string ReservationSettingsInf { get; set; }
        public string ReservationValue { get; set; }
        public string CompanyId { get; set; }

    }
}
