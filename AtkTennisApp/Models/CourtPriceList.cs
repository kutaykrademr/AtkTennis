using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class CourtPriceList
    {
        [Key]
        public int CourtPriceListId { get; set; }
        public string Name { get; set; }
        public int CourtPrice { get; set; }
        public string PriceType { get; set; }
        public string RecipeType { get; set; }
        public string Condition { get; set; }    
    }
}
