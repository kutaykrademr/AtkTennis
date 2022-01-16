using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class BalanceOpModel
    {
        [Key]
        public int BalanceId { get; set; }
        public string MemberId { get; set; }
        public string AdminId { get; set; }
        public string Date { get; set; }
        public string Price { get; set; }
    }
}
