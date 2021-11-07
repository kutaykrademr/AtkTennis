using System;
using System.Collections.Generic;
using System.Text;

namespace AtkTennisApp
{
    [Serializable]
    public class MutualConstants
    {

        public  int Id { get; set; }
        public  string SunucuIp { get; set; }
        public  bool? M1 { get; set; }
        public  bool? M2 { get; set; }
        public  bool? M3 { get; set; }
        public  bool? M4 { get; set; }
        public  bool? M5 { get; set; }
        public  bool? M6 { get; set; }
        public  int CourtCount { get; set; }
        public  string PhotoUrl { get; set; }
        public  string CompanyName { get; set; }
        public  DateTime ExpirationDate { get; set; }

    }
}
