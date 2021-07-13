using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class HomeModelView
    {
        public int? TotalUserCount { get; set; }
        public int? TotalRoleCount { get; set; }
        public int? TotalResCount { get; set; }
        public int? TodayResCount { get; set; }
        public List<ToDoList> toDoLists { get; set; } = new List<ToDoList>();
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<Court> courts { get; set; } = new List<Court>();
        
    }
}
