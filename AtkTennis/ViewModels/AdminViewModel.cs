using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtkTennis.Models;

namespace AtkTennis.ViewModels
{
    public class AdminViewModel
    {
        public List<Reservation> Res { get; set; } = new List<Reservation>();
        public List<Court> Courts { get; set; } = new List<Court>();
        public List<ResTime> Times { get; set; } = new List<ResTime>();



    }
}
