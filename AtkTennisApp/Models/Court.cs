using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class Court
    {
        public int CourtId { get; set; }
        public string CourtName { get; set; }
        public string CourtType { get; set; }
        public string CourtConditions { get; set; }
        public string CourtWebConditions { get; set; }



        public List<Reservation> reservations { get; set; }
    }
}
