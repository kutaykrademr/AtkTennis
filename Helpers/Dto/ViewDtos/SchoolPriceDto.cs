using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class SchoolPriceDto
    {
        public int Id { get; set; }
        public int price { get; set; }
        

        public SchoolLevelDto schoolLevel { get; set; }
        public SchoolTypeDto schoolType { get; set; }
        public SchoolPriceTypeDto schoolPriceType { get; set; }
    }
}
