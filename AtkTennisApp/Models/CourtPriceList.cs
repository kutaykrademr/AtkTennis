﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.Models
{
    public partial class CourtPriceList
    {
        public int CourtPriceListId { get; set; }
        public string Name { get; set; }
        public int CourtPrice { get; set; }
        public string PriceType { get; set; }
        public string RecipeType { get; set; }
        public string Condition { get; set; }
    }
}