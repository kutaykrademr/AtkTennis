﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class HomeModelDto
    {
        public int? TotalUserCount { get; set; }
        public int? TotalRoleCount { get; set; }
        public int? TotalResCount { get; set; }
        public int? TodayResCount { get; set; }
        public List<ToDoListDto> toDoLists { get; set; } = new List<ToDoListDto>();
    }
}
