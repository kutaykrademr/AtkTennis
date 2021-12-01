using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class CizelgeSkalasi
    {
        public CizelgeSkalasi()
        {
            KortRezervasyons = new HashSet<KortRezervasyon>();
            OkulTurus = new HashSet<OkulTuru>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string KisaKod { get; set; }
        public string ClassName { get; set; }
        public string Style { get; set; }
        public int Turu { get; set; }

        public virtual ICollection<KortRezervasyon> KortRezervasyons { get; set; }
        public virtual ICollection<OkulTuru> OkulTurus { get; set; }
    }
}
