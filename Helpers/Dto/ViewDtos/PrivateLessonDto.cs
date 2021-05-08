using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class PrivateLessonDto
    {
        public int PrivateLessonId { get; set; }
        public string TariffeInf { get; set; }
        public int? PrivateLessonPrice { get; set; }
        public int? TeacherPrice { get; set; }
        public string PrivateLessonType { get; set; }
    }
}
