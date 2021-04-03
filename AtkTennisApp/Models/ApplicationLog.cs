using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.Models
{
    public partial class ApplicationLog
    {
        public int ApplicationLogId { get; set; }
        public string Application { get; set; }
        public string Server { get; set; }
        public DateTime? Date { get; set; }
        public string IdFieldName { get; set; }
        public int? IdField { get; set; }
        public string Type { get; set; }
        public string Explanation { get; set; }
    }
}
