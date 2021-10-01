using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class ResandResCancelViewDto
    {
        public ReservationDto reservation { get; set; } = new ReservationDto();
        public ReservationCancelDto reservationCancel { get; set; } = new ReservationCancelDto();
    }
}
