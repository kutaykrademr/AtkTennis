using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
   public class IdentityRoleSettingsViewDto
    {
        public List<UserSettingsDto> userSettings { get; set; } = new List<UserSettingsDto>();
        public List<AppIdentityRoleDto> appIdentityRoles { get; set; } = new List<AppIdentityRoleDto>();
    }
}
