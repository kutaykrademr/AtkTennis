using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class CourtTimeInfDto
    {
        public int CourtTimeInfId { get; set; }
        public int CourtId { get; set; }
        public string CourtStartTime { get; set; }
        public string CourtFinishTime { get; set; }
        public string CourtTimePeriod { get; set; }
    }
}
