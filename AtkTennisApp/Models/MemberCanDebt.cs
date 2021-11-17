using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class MemberCanDebt
    {
        [Key]
        public int MemberCanDebtId { get; set; }
        public bool CanDebt { get; set; }      
        public string CompanyId { get; set; }
    }
}
