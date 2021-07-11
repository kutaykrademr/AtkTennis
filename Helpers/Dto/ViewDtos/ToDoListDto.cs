using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class ToDoListDto
    {
        public int ListId { get; set; }
        public string ToDo { get; set; }
        public string Date { get; set; }
    }
}
