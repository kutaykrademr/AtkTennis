using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class SchoolLevel
    {
        [Key]
        public int SchoolLevelId { get; set; }
        public string Levels { get; set; }
     
    }
}
