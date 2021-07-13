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
        public string ResTime { get; set; }
        public string UserId { get; set; }     
        public string ResNowDate { get; set; }
        public bool PriceInf { get; set; }
        public int Price { get; set; }
        public string PriceIds { get; set; }
        public bool CancelRes { get; set; }
        public bool Procedure { get; set; }
        

        public Court Court { get; set; }
        

    }
}
