using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
   public class EducationSettingsViewDto
    {
        public List<SchoolLevelDto> schoolLevels { get; set; } = new List<SchoolLevelDto>();
        public List<SchoolTypeDto> schoolTypes { get; set; } = new List<SchoolTypeDto>();
    }
}
