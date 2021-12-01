using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class KortRezervasyon
    {
        public KortRezervasyon()
        {
            KortRezervasyonFiyatlandirmas = new HashSet<KortRezervasyonFiyatlandirma>();
            KortRezervasyonIptals = new HashSet<KortRezervasyonIptal>();
            KortRezervasyonOdemes = new HashSet<KortRezervasyonOdeme>();
            KortRezervasyonTarihces = new HashSet<KortRezervasyonTarihce>();
        }

        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
        public int IslemTuru { get; set; }
        public int Durumu { get; set; }
        public int OdemeDurumu { get; set; }
        public int Online { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int Kendi { get; set; }
        public int KortId { get; set; }
        public int UyeId { get; set; }

        public virtual CizelgeSkalasi IslemTuruNavigation { get; set; }
        public virtual Kort Kort { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual ICollection<KortRezervasyonFiyatlandirma> KortRezervasyonFiyatlandirmas { get; set; }
        public virtual ICollection<KortRezervasyonIptal> KortRezervasyonIptals { get; set; }
        public virtual ICollection<KortRezervasyonOdeme> KortRezervasyonOdemes { get; set; }
        public virtual ICollection<KortRezervasyonTarihce> KortRezervasyonTarihces { get; set; }
    }
}
