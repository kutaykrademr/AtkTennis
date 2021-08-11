﻿using AtkTennisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class CourtSettingsViewModel
    {
        public List<Court> Courts { get; set; } = new List<Court>();
        public List<CourtPriceList> courtPriceLists { get; set; } = new List<CourtPriceList>();
        public List<CourtTimeInf> courtTimeInfs { get; set; } = new List<CourtTimeInf>();
        public List<ResTime> resTimes { get; set; } = new List<ResTime>();
        public List<CourtRecipeType> courtRecipeTypes { get; set; } = new List<CourtRecipeType>();
    }
}
