using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkTennisWeb
{
    public class Mutuals
    {
        public static string AppUrl { get; set; }

        public static bool? M1 { get; set; }
        public static bool? M2 { get; set; }
        public static bool? M3 { get; set; }
        public static bool? M4 { get; set; }
        public static bool? M5 { get; set; }
        public static bool? M6 { get; set; }
        public static string CompName { get; set; }
        public static string CompanyId { get; set; }
        public static Dictionary<string, Helpers.Dto.ViewDtos.UserSettingsDto> UserSettings = new Dictionary<string, Helpers.Dto.ViewDtos.UserSettingsDto>();
    }
}
