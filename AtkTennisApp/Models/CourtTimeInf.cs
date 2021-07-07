using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class CourtTimeInf
    {
        [Key]
        public int CourtTimeInfId { get; set; }
        public int CourtId { get; set; }
        public string CourtStartTime { get; set; }
        public string CourtFinishTime { get; set; }
        public string CourtTimePeriod { get; set; }

       
    }
}
