using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class MemberDuesInfTableDto
    {
        public int MemberDuesInfTableId { get; set; }
        public string MemberId { get; set; }
        public string MemberFullName { get; set; }
        public int DuesYear { get; set; }
        public string DuesType { get; set; }
        public int DuesPrice { get; set; }
        public int PaidPrice { get; set; }
        public int RemainingPrice { get; set; }
        public string Date { get; set; }
        public string Explain { get; set; }
        public bool DuesInfType { get; set; }
        public bool PriceCondition { get; set; }
        public bool CancelCondition { get; set; }
        public string CompanyId { get; set; }
    }
}
