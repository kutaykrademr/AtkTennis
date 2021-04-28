﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.Models
{
    public partial class Court
    {
        public Court()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int CourtId { get; set; }
        public string CourtName { get; set; }
        public string CourtType { get; set; }
        public string CourtConditions { get; set; }
        public string CourtWebConditions { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
