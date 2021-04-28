using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.ViewDtos
{
    public class CourtSettingsViewDto
    {
        public List<CourtDto> Courts { get; set; } = new List<CourtDto>();
        public List<CourtPriceListDto> courtPriceLists { get; set; } = new List<CourtPriceListDto>();

    }
}
