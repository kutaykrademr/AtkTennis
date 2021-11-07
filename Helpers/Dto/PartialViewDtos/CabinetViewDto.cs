using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
   public class CabinetViewDto
    {
        public List<CabinetListUserDto> cabinetListUsers { get; set; } = new List<CabinetListUserDto>();
        public List<MemberDuesInfTableDto> memberDuesInfTables { get; set; } = new List<MemberDuesInfTableDto>();

    }
}
