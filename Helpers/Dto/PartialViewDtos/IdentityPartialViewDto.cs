using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class IdentityPartialViewDto
    {
        public List<AppIdentityUserDto> AppIdentityUsers { get; set; } = new List<AppIdentityUserDto>();
        public List<AppIdentityRoleDto> AppIdentityRoles { get; set; } = new List<AppIdentityRoleDto>();
    }
}
