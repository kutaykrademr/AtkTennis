using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class CabinetType
    {
        [Key]
        public int CabinetId { get; set; }
        public string CabinetTypes { get; set; }
        public int CabinetTypesPrice { get; set; }
    }
}
