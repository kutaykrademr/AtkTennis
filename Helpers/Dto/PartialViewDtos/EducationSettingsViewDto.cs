using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
   public class EducationSettingsViewDto
    {
        public List<SchoolLevelDto> schoolLevels { get; set; } = new List<SchoolLevelDto>();
        public List<SchoolTypeDto> schoolTypes { get; set; } = new List<SchoolTypeDto>();
        public List<PerformanceLevelDto> performanceLevels { get; set; } = new List<PerformanceLevelDto>();
        public List<PerformanceTypeDto> performanceTypes { get; set; } = new List<PerformanceTypeDto>();
        public List<PrivateLessonDto> privateLessons { get; set; } = new List<PrivateLessonDto>();
    }
}
