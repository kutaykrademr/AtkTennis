using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class CabinetListUserViewDto
    {
        public List<CabinetListUserDto> cabinetListUsers { get; set; } = new List<CabinetListUserDto>();
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
    }
}
