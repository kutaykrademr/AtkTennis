using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class RezervasyonFiyatlandirma
    {
        public RezervasyonFiyatlandirma()
        {
            KortRezervasyonFiyatlandirmas = new HashSet<KortRezervasyonFiyatlandirma>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }
        public int Turu { get; set; }
        public int Tipi { get; set; }
        public int Gosterim { get; set; }
        public string GunBilgisi { get; set; }
        public string SaatBilgisi { get; set; }
        public string AyBilgisi { get; set; }

        public virtual ICollection<KortRezervasyonFiyatlandirma> KortRezervasyonFiyatlandirmas { get; set; }
    }
}
