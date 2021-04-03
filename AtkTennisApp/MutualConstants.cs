using System;
using System.Collections.Generic;
using System.Text;

namespace AtkTennisApp
{
    [Serializable]
    public class MutualConstants
    {

        public static int Id { get; set; }
        public static string SunucuIp { get; set; }
        public static bool? M1 { get; set; }
        public static bool? M2 { get; set; }
        public static bool? M3 { get; set; }
        public static bool? M4 { get; set; }
        public static bool? M5 { get; set; }
        public static bool? M6 { get; set; }
        public static int CourtCount { get; set; }
        public static string PhotoUrl { get; set; }
        public static string CompanyName { get; set; }
        public static DateTime ExpirationDate { get; set; }

    }
}
