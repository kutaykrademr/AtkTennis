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
        public List<ReservationCancelDto> reservationCancels { get; set; } = new List<ReservationCancelDto>();
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
        public List<string> date { get; set; }
        public int debtCount { get; set; }
        public int debtNotCount { get; set; }
        public int cancelResCount { get; set; }
    }
}
