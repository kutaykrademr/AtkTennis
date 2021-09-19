using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class MemberDebtType
    {
        [Key]
        public int MemberDebtTypeId { get; set; }
        public string Type { get; set; }
    }
}
