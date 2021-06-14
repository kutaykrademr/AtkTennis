using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class CourtDto
    {

        public int CourtId { get; set; }
        public string CourtName { get; set; }
        public string CourtType { get; set; }
        public int CourtConditions { get; set; }
        public int CourtWebConditions { get; set; }

    }
}
