using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Dolap
    {
        public Dolap()
        {
            UyeAiles = new HashSet<UyeAile>();
            UyeDolaps = new HashSet<UyeDolap>();
            Uyes = new HashSet<Uye>();
        }

        public int Id { get; set; }
        public string Kodu { get; set; }
        public double Tahsis { get; set; }
        public double Aidat { get; set; }
        public int? Turu { get; set; }

        public virtual ICollection<UyeAile> UyeAiles { get; set; }
        public virtual ICollection<UyeDolap> UyeDolaps { get; set; }
        public virtual ICollection<Uye> Uyes { get; set; }
    }
}
