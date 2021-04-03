using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Helpers
{
    [DataContract]
    public partial class UserLogsDto
    {
        [DataMember]
        public int UserLogId { get; set; }
        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Explanation { get; set; }
        [DataMember]
        public string Application { get; set; }
        [DataMember]
        public string Ip { get; set; }
        [DataMember]
        public string Port { get; set; }

    }
}
