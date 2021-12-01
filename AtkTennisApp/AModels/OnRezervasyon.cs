using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class OnRezervasyon
    {
        public int Id { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public string GunSecimi { get; set; }
        public string SaatSecimi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int Durumu { get; set; }
        public int IslemTuru { get; set; }
        public int UyeId { get; set; }
        public int KortId { get; set; }
        public int IslemYapanKullaniciId { get; set; }

        public virtual Kullanici IslemYapanKullanici { get; set; }
        public virtual Kort Kort { get; set; }
        public virtual Uye Uye { get; set; }
    }
}
