using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class MonitizerResult
    {
        public int fatalCounter { get; set; }

        public int exceptionCounter { get; set; }

        public int startSuccesful { get; set; }

        public List<ErrorLogsDto> exceptions { get; set; }

        public List<ApplicationLogsDto> logs { get; set; }

        public string AppName { get; set; }

        public string IpAddress { get; set; }

        public List<string> console { get; set; }
    }
}
