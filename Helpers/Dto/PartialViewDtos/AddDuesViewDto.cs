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
    }
}
