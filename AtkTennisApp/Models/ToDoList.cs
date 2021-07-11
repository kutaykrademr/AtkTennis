﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.Models
{
    public class ToDoList
    {
        [Key]
        public int ListId { get; set; }
        public string ToDo { get; set; }
        public string Date { get; set; }
    
    }
}
