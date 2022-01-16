using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class SecretaryOp
    {
        [Key]
        public int SecretaryOpId { get; set; }
        public string AdminId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string CompId { get; set; }

    }
}
