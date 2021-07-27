using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class ReservationTotal
    {
        public int Id { get; set; }
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
        public int CourtId { get; set; }
        public string PriceIds { get; set; }
        public string NickName { get; set; }
        public bool CancelRes { get; set; }
        public string? CancelResUserId { get; set; }
        public bool Procedure { get; set; }
    }
}
