using System;
using System.Collections.Generic;
using System.Text;
using Helpers.Dto.ViewDtos;

namespace Helpers.Dto.PartialViewDtos
{
    public class ReservationSettingsViewDto
    {
        public List<ReservationSettingsDto> reservationSettings { get; set; } = new List<ReservationSettingsDto>();
    }
}

