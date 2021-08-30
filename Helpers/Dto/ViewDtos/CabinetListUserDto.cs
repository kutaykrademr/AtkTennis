using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
   public class CabinetListUserDto
    {
        public int CabinetOpId { get; set; }
        public string CabinetCode { get; set; }
        public string CabinetOpTypes { get; set; }
        public int CabinetOpPrice { get; set; }
        public string CabinetWho { get; set; }
        public string CabinetUserId { get; set; }
        public string Date { get; set; }
    }
}
