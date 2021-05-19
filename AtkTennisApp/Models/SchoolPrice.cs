using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class SchoolPrice
    {
        [Key]
        public int Id { get; set; }
        public int price{ get; set; }
        

      
        public SchoolLevel schoolLevel { get; set; }
        public SchoolType schoolType { get; set; }
        public SchoolPriceType schoolPriceType { get; set; }
      
    }
}
