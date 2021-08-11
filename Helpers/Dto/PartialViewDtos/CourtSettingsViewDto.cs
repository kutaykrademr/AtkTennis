﻿using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class CourtSettingsViewDto
    {
        public List<CourtDto> Courts { get; set; } = new List<CourtDto>();
        public List<CourtPriceListDto> courtPriceLists { get; set; } = new List<CourtPriceListDto>();
        public List<CourtTimeInfDto> courtTimeInfs { get; set; } = new List<CourtTimeInfDto>();
        public List<ResTimeDto> resTimes { get; set; } = new List<ResTimeDto>();
        public List<CourtRecipeTypeDto> courtRecipeTypes { get; set; } = new List<CourtRecipeTypeDto>();

    }
}
