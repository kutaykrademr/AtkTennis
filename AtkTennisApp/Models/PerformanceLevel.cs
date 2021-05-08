using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class PerformanceLevel
    {
        [Key]
        public int PerLevelId { get; set; }
        public string PerLevel { get; set; }
        public int? PerQuotaInf { get; set; }
    }
}
