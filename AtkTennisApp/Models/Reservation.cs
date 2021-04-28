using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AtkTennisApp.Models
{
    public partial class Reservation
    {
        [Key]
        public int ResId { get; set; }
        public string ResDate { get; set; }
        public string ResStartTime { get; set; }
        public string ResFinishTime { get; set; }
        public string ResEvent { get; set; }
        public string UserId { get; set; }
        public int? CourtsCourtId { get; set; }

        public virtual Court CourtsCourt { get; set; }
    }
}
