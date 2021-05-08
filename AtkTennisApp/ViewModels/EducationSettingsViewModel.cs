using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class EducationSettingsViewModel
    {
        public List<SchoolLevel> schoolLevels { get; set; } = new List<SchoolLevel>();
        public List<SchoolType> schoolTypes { get; set; } = new List<SchoolType>();
        public List<PerformanceLevel> performanceLevels { get; set; } = new List<PerformanceLevel>();
        public List<PerformanceType> performanceTypes { get; set; } = new List<PerformanceType>();
        public List<PrivateLesson> privateLessons  { get; set; } = new List<PrivateLesson>();
    }
}
