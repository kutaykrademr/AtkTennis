using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
   public class ResSchemaViewDto
    {
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
        public List<CourtScaleDto> courtScales { get; set; } = new List<CourtScaleDto>();

    }
}
