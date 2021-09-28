using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class AddDuesViewDto
    {
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
        public MemberDuesInfTableDto memberDuesInfTable { get; set; } = new MemberDuesInfTableDto();
        public List<CabinetListUserDto> cabinetListUsers { get; set; } = new List<CabinetListUserDto>();
        public List<CabinetTypesDto> cabinetTypes { get; set; } = new List<CabinetTypesDto>();
        public List<MemberDuesInfTableDto> memberDuesInfs { get; set; } = new List<MemberDuesInfTableDto>();
        public List<MemberDuesTypeDto> memberDuesTypes { get; set; } = new List<MemberDuesTypeDto>();
    }
}
