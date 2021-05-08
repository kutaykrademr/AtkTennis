using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class PerformanceType
    {
        [Key]
        public int PerformanceTypesId { get; set; }
        public string PerformanceCode { get; set; }
        public string PerformanceTypes { get; set; }
    }
}
