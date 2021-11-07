using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class CourtRecipeType
    {
        [Key]
        public int CourtRecipeTypeId { get; set; }
        public string CourtRecipeTypes { get; set; }
        public string CompanyId { get; set; }
 

    }
}
