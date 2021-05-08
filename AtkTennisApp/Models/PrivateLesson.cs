using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class PrivateLesson
    {
        [Key]
        public int PrivateLessonId { get; set; }
        public string TariffeInf { get; set; }
        public int? PrivateLessonPrice { get; set; }
        public int? TeacherPrice { get; set; }
        public string PrivateLessonType { get; set; }
    }
}
