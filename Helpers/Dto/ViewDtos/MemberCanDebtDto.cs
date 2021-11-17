using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class MemberCanDebtDto
    {
        public int MemberCanDebtId { get; set; }
        public bool CanDebt { get; set; }
        public string CompanyId { get; set; }
    }
}
