using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
   public class ResModalViewDto
    {
        public List<CourtPriceListDto> courtPriceLists { get; set; } = new List<CourtPriceListDto>();
        public ResSchemaModalDto resSchemaModal { get; set; } = new ResSchemaModalDto();

    }
}
