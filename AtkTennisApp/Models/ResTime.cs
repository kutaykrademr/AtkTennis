using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class ResTime
    {
        [Key]
        public int ResTimeId { get; set; }
        public string ResTimes { get; set; }
    }
}
