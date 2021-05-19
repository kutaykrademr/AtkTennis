using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class SchoolPriceType
    {
        [Key]
        public int Id { get; set; }
        public string PriceTypeDescription { get; set; }
    }
}
