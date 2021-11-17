using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class MemberSettingsViewDto
    {
        public List<CabinetTypesDto> cabinetTypes { get; set; } = new List<CabinetTypesDto>();
        public List<CabinetOperationsDto> cabinetOperations { get; set; } = new List<CabinetOperationsDto>();
        public List<MemberDuesTypeDto> memberDuesTypes { get; set; } = new List<MemberDuesTypeDto>();
        public List<MemberCanDebtDto> memberCanDebts { get; set; } = new List<MemberCanDebtDto>();
    }
}
