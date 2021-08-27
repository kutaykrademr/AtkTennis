using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class RegisterStudentViewDto
    {
        public List<SchoolTypeDto> schoolTypes { get; set; } = new List<SchoolTypeDto>();
        public List<SchoolLevelDto> schoolLevels { get; set; } = new List<SchoolLevelDto>();
        public List<PerformanceLevelDto> performanceLevels { get; set; } = new List<PerformanceLevelDto>();
        public List<PerformanceTypeDto> performanceTypes { get; set; } = new List<PerformanceTypeDto>();
    }
}
