﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.Models
{
    public class Court
    {


        public int CourtId { get; set; }
        public string CourtName { get; set; }
        public string CourtType { get; set; }
        public int CourtConditions { get; set; }
        public int CourtWebConditions { get; set; }
        public string CourtStartTime { get; set; }
        public string CourtFinishTime { get; set; }
        public string CourtTimePeriod { get; set; }

    }
}
