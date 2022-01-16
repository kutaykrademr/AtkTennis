using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class SecretaryOp
    {
        public int SecretaryOpId { get; set; }
        public string AdminId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string CompId { get; set; }
    }
}
