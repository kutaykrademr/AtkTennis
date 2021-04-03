using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.Models
{
    public partial class QueryLog
    {
        public int QueryLogId { get; set; }
        public string QueryClass { get; set; }
        public string QueryName { get; set; }
        public string Parameters { get; set; }
        public int? ElapsedMilisecond { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }
    }
}
