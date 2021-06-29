﻿using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class CheckResTableViewModel
    {
        public List<Reservation> reservations { get; set; } = new List<Reservation>();
        public List<Court> courts { get; set; } = new List<Court>();
        public List<ResTime> resTimes { get; set; } = new List<ResTime>();
    }
}