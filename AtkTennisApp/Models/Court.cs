using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.Models
{
    public class Court
    {
 

        public int CourtId { get; set; }
        public string CourtName { get; set; }
        public string CourtType { get; set; }
        public string CourtConditions { get; set; }
        public string CourtWebConditions { get; set; }

        
    }
}
