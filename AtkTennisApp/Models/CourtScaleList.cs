using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class CourtScaleList
    {
        [Key]
        public int CourtScaleListId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public string CompanyId { get; set; }

    }
}
