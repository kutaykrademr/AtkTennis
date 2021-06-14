using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
   public class ReservationViewDto
    {
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        public List<ResTimeDto> resTimes { get; set; } = new List<ResTimeDto>();
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
        public List<ReservationSettingsDto> reservationSettings { get; set; } = new List<ReservationSettingsDto>();
       
      
        public string u_id{ get; set; }
        public string u_fullname{ get; set; }



    }
}
