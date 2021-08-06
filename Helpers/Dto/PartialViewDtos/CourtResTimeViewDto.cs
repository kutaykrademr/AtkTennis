using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class CourtResTimeViewDto
    {
        public CourtDto Courts { get; set; } = new CourtDto();
        public CourtTimeInfDto CourtTimeInf { get; set; } = new CourtTimeInfDto();
    }
}
