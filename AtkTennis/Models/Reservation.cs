using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennis.Models
{
    public class Reservation
    {
        [Key]
        public int ResId { get; set; }
        public string ResDate { get; set; }
        public string ResStartTime { get; set; }
        public string ResFinishTime { get; set; }
        public string ResEvent { get; set; }
        public string userId { get ; set;} 

        


        public Court courts { get; set; }

    }

}
