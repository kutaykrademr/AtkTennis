using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class checkResViewDto
    {
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
        public List<ResTimeDto> resTimes { get; set; } = new List<ResTimeDto>();
    }
}
