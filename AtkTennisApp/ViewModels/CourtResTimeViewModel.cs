using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class CourtResTimeViewModel
    {
        public Court Courts { get; set; } = new Court();
        public CourtTimeInf CourtTimeInf { get; set; } = new CourtTimeInf();
    }
}
