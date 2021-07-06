using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class ResSchemaModalDto
    {
        public int ResId { get; set; }
        public string ResDate { get; set; }
        public string ResTime { get; set; }
        public string ResStartTime { get; set; }
        public string ResFinishTime { get; set; }
        public string ResEvent { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string CourtName { get; set; }
        public string ResNowDate { get; set; }
        public bool PriceInf { get; set; }

    }
}
