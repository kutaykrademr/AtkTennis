using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeFiyatlandirma
    {
        public UyeFiyatlandirma()
        {
            UyeAidats = new HashSet<UyeAidat>();
        }

        public int Id { get; set; }
        public int Yil { get; set; }
        public double Miktar { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Aciklama { get; set; }
        public int Durumu { get; set; }
        public int Turu { get; set; }
        public int IslemYapanKullaniciId { get; set; }

        public virtual ICollection<UyeAidat> UyeAidats { get; set; }
    }
}
