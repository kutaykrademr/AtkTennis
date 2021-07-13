using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class ReservationListViewDto
    {
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
    }
}
