using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class BalanceOpViewModel
    {
        public List<MemberListDto> memberLists { get; set; } = new List<MemberListDto>();
        public List<BalanceOpModelDto> balanceOpModels { get; set; } = new List<BalanceOpModelDto>();
    }
}
