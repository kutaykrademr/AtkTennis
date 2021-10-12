using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class CourtPriceListDto
    {
        public int CourtPriceListId { get; set; }
        public string Name { get; set; }
        public int CourtPrice { get; set; }
        public string PriceType { get; set; }
        public string RecipeType { get; set; }
        public string RecipeTypeId { get; set; }
        public string Condition { get; set; }
        public string MonthInf { get; set; }
        public string DayInf { get; set; }
        public string TimeInf { get; set; }
    }
}
