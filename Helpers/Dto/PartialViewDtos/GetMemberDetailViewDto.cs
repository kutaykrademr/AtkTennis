using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class GetMemberDetailViewDto
    {
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
        public List<ReservationCancelDto> reservationCancels { get; set; } = new List<ReservationCancelDto>();
        public List<CabinetOperationsDto> cabinetOperations { get; set; } = new List<CabinetOperationsDto>();
        public List<CabinetTypesDto> cabinetTypes { get; set; } = new List<CabinetTypesDto>();
        public List<CabinetListUserDto> cabinetListUsers { get; set; } = new List<CabinetListUserDto>();

        public MemberListDto memberLists { get; set; } = new MemberListDto();
        public int totalPrice { get; set; }
    }
}
