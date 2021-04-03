using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Helpers
{
    [DataContract]
    public partial class QueryLogsDto
    {
        [DataMember]
        public int QueryLogId { get; set; }
        [DataMember]
        public string QueryClass { get; set; }
        [DataMember]
        public string QueryName { get; set; }
        [DataMember]
        public string Parameters { get; set; }
        [DataMember]
        public int? ElapsedMilisecond { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public int? UserId { get; set; }
    }
}
