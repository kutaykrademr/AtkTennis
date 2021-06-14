using Helpers.Dto.ViewDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Dto.PartialViewDtos
{
    public class LayoutViewDto
    {
        public SignInDto signIns { get; set; } = new SignInDto();
        public HomeModelDto homeModel { get; set; } = new HomeModelDto();
       
    }
}
