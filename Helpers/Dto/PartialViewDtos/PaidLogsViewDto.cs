using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class PaidLogsViewDto
    {
        public AllGetPaidLogsDto allGetPaid { get; set; } = new AllGetPaidLogsDto();
        public ReservationDto reservation { get; set; } = new ReservationDto();
        public ReservationCancelDto reservationCancel { get; set; } = new ReservationCancelDto();
        public MemberDuesInfTableDto memberDuesInf { get; set; } = new MemberDuesInfTableDto();
        public CabinetListUserDto cabinetListUser { get; set; } = new CabinetListUserDto();
    }
}
