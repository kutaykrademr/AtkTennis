using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class MemberSchoolPerViewDto
    {
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
        public List<SchoolTypeDto> schoolTypes { get; set; } = new List<SchoolTypeDto>();
        public List<PerformanceTypeDto> performanceTypes { get; set; } = new List<PerformanceTypeDto>();
    }
}
