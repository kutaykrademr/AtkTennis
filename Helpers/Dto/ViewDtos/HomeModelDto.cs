using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class HomeModelDto
    {
        public int? TotalUserCount { get; set; }
        public int? TotalRoleCount { get; set; }
        public int? TotalResCount { get; set; }
        public int? TodayResCount { get; set; }
        public List<ToDoListDto> toDoLists { get; set; } = new List<ToDoListDto>();
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();




       //Reservations//
        public List<CourtPriceListDto> courtPriceLists { get; set; } = new List<CourtPriceListDto>();
        public List<ResTimeDto> resTimes { get; set; } = new List<ResTimeDto>();
        public List<ReservationCancelDto> reservationCancels { get; set; } = new List<ReservationCancelDto>();
        public List<ReservationSettingsDto> reservationSettings { get; set; } = new List<ReservationSettingsDto>();
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
        public List<CourtTimeInfDto> courtTimeInfs { get; set; } = new List<CourtTimeInfDto>();
        public List<CourtScaleDto> courtScaleLists{ get; set; } = new List<CourtScaleDto>();
    }
}
