using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class SchoolType
    {
        [Key]
        public int SchoolTypesId { get; set; }
        public string Code { get; set; }
        public string Types { get; set; }
        
    }
}
