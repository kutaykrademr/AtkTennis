using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
   public class CheckResTableViewDto
    {
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        public List<ResTimeDto> resTimes { get; set; } = new List<ResTimeDto>();
    }
}
