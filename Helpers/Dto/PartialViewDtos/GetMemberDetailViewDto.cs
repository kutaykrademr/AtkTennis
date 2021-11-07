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
        public List<MemberDuesInfTableDto> memberDuesInfs { get; set; } = new List<MemberDuesInfTableDto>();
        public List<AppIdentityUserDto> AppIdentityUsers { get; set; } = new List<AppIdentityUserDto>();
        public List<AppIdentityRoleDto> AppIdentityRoles { get; set; } = new List<AppIdentityRoleDto>();

        public MemberListDto memberLists { get; set; } = new MemberListDto();
        public List<MemberListDto> memberLists2 { get; set; } = new List<MemberListDto>();
        public int totalPrice { get; set; }
    }
}
