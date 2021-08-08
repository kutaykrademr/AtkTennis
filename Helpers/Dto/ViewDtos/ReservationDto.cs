using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class ReservationDto
    {
        public int ResId { get; set; }
        public string ResDate { get; set; }
        public string ResTime { get; set; }
        public string ResStartTime { get; set; }
        public string ResFinishTime { get; set; }
        public string ResEvent { get; set; }
        public string UserId { get; set; }
        public string doResUserId { get; set; }
        public string CourtId { get; set; }
        public string ResNowDate { get; set; }
        public bool PriceInf { get; set; }
        public int Price { get; set; }
        public string PriceIds { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public bool CancelRes { get; set; }
        public string? CancelResUserId { get; set; }
        public bool Procedure { get; set; }
       

        
        public CourtDto Court { get; set; }

      
    }
}
