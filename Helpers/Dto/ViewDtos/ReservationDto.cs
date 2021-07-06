﻿using System;
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
        public string CourtId { get; set; }
        public string ResNowDate { get; set; }
        public bool PriceInf { get; set; }


        public CourtDto Court { get; set; }
    }
}
