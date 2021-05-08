using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtkTennisApp.Models;

namespace AtkTennisApp.ViewModels
{
    public class ReservationSettingsViewModel
    {
        public List<ReservationSettings> reservationSettings { get; set; } = new List<ReservationSettings>();
    }
}
