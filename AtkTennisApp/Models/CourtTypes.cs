using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class CourtTypes
    {
        [Key]
        public int CourtTypesId { get; set; }
        public string Types { get; set; }
    }
}
