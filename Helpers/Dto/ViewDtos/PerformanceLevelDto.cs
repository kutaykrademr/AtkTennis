using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class PerformanceLevelDto
    {   
        public int PerLevelId { get; set; }
        public string PerLevel { get; set; }
        public int? PerQuotaInf { get; set; }
    }
}
