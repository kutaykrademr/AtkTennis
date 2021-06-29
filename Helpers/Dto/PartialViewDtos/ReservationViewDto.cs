using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class ReservationViewDto
    {
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        public List<CourtPriceListDto> courtPriceLists {get ;set;} = new List<CourtPriceListDto>();
        public List<ResTimeDto> resTimes { get; set; } = new List<ResTimeDto>();
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
        public List<ReservationSettingsDto> reservationSettings { get; set; } = new List<ReservationSettingsDto>();
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
       
    }
}
