using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
   public class ReservationCourtViewDto
    {
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        public ReservationDto reservations { get; set; } = new ReservationDto();
    }
}

