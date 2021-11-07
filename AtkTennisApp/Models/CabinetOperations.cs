using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class CabinetOperations
    {
        [Key]
        public int CabinetOpId { get; set; }
        public string CabinetCode { get; set; }
        public string CabinetOpTypes { get; set; }
        public string CompanyId { get; set; }


    }
}
