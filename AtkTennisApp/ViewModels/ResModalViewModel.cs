using AtkTennisApp.Models;
using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisApp.ViewModels
{
    public class ResModalViewModel
    {
        public List<CourtPriceList> courtPriceLists { get; set; } = new List<CourtPriceList>();
        public ResSchemaModalDto resSchemaModal { get; set; } = new ResSchemaModalDto();

    }
}
