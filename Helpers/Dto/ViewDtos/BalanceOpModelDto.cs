using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class BalanceOpModelDto
    {
        [Key]
        public int BalanceId { get; set; }
        public string MemberId { get; set; }
        public string AdminId { get; set; }
        public string Date { get; set; }
        public string Price { get; set; }
        public string CompanyId { get; set; }
    }
}
