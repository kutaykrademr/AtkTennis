using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class ResandResCancelViewModel
    {
        public Reservation reservation { get; set; } = new Reservation();
        public ReservationCancel reservationCancel { get; set; } = new ReservationCancel();
    }
}
