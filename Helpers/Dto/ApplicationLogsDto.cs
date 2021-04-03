using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Helpers
{
    [DataContract]
    public partial class ApplicationLogsDto
    {
        [DataMember]
        public int ApplicationLogId { get; set; }

        [DataMember]
        public string Application { get; set; }

        [DataMember]
        public string Server { get; set; }

        [DataMember]
        public DateTime? Date { get; set; }

        [DataMember]
        public string IdFieldName { get; set; }

        [DataMember]
        public int? IdField { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Explanation { get; set; }
    }
}
