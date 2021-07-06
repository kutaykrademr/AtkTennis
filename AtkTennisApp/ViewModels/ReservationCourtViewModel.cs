using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class ReservationCourtViewModel
    {
        public List<Court> courts { get; set; } = new List<Court>();
        public Reservation reservations { get; set; } = new Reservation();
    }
}
