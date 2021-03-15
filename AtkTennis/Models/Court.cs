using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennis.Models
{
    public class Court
    {
        public int CourtId { get; set; }
        public string CourtName { get; set; }


        public List<Reservation> reservations { get; set; }
    }
}
