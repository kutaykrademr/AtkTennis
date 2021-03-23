using AtkTennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennis.ViewModels
{
    public class CourtSettingsViewModel
    {
        public List<Court> Courts { get; set; } = new List<Court>();
        public List<CourtPriceList> courtPriceLists { get; set; } = new List<CourtPriceList>();

    }
}
