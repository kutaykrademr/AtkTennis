using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class GeneralDebtViewDto
    {
        public List<MemberDebtTypeDto> memberDebtTypes { get; set; } = new List<MemberDebtTypeDto>();
        public List<MemberDuesInfTableDto> memberDuesInfTables { get; set; } = new List<MemberDuesInfTableDto>();
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
    }
}
