using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class CabinetListUser
    {
        [Key]
        public int CabinetOpId { get; set; }
        public string CabinetCode { get; set; }
        public string CabinetOpTypes { get; set; }
        public int CabinetOpPrice { get; set; }
        public string CabinetWho { get; set; }
        public string CabinetUserId { get; set; }
        public string Date { get; set; }
        public bool PriceCondition { get; set; }
        public bool CabinetCondition { get; set; }
    }
}
