using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Kort
    {
        public Kort()
        {
            KortRezervasyons = new HashSet<KortRezervasyon>();
            OnRezervasyons = new HashSet<OnRezervasyon>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Kodu { get; set; }
        public int Durumu { get; set; }
        public int WebDurumu { get; set; }
        public int Turu { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Aciklama { get; set; }
        public int Sira { get; set; }
        public string Pt1 { get; set; }
        public string Pt2 { get; set; }
        public string Pt3 { get; set; }
        public string Pt4 { get; set; }
        public string Pt5 { get; set; }
        public string Pt6 { get; set; }
        public string Pt0 { get; set; }

        public virtual ICollection<KortRezervasyon> KortRezervasyons { get; set; }
        public virtual ICollection<OnRezervasyon> OnRezervasyons { get; set; }
    }
}
