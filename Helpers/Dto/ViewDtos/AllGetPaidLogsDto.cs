using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
   public class AllGetPaidLogsDto
    {
        public int AllGetPaidLogsId { get; set; }
        public string UserId { get; set; }
        public string DoOpUserId { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int PaidPrice { get; set; }
        public int RemainingPrice { get; set; }
        public int PaymentType { get; set; }
        public int ReceiptNo { get; set; }
        public string ReceiptDate { get; set; }
        public string Explain { get; set; }
        public string CompanyId { get; set; }

        public int RefType { get; set; }
        public int RefId { get; set; }
    }
}
