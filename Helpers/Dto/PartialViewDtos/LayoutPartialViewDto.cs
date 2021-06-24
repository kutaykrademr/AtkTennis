using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class LayoutPartialViewDto
    {
        public List<AppIdentityUserDto> AppIdentityUsers { get; set; } = new List<AppIdentityUserDto>();
        public List<AppIdentityRoleDto> AppIdentityRoles { get; set; } = new List<AppIdentityRoleDto>();
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
    }
}
