using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class IdentityPartialViewDto
    {
        public List<AppIdentityUserDto> AppIdentityUsers { get; set; } = new List<AppIdentityUserDto>();
        public List<AppIdentityRoleDto> AppIdentityRoles { get; set; } = new List<AppIdentityRoleDto>();
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
        public List<CourtDto> courts { get; set; } = new List<CourtDto>();
        public List<ReservationDto> reservations { get; set; } = new List<ReservationDto>();
    }
}
