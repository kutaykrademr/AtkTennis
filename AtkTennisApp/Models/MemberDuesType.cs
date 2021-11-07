using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class MemberDuesType
    {
        [Key]
        public int MemberDuesTypeId { get; set; }
        public int Age { get; set; }
        public int Year { get; set; }
        public int Discount { get; set; }
        public string CompanyId { get; set; }

    }
}
