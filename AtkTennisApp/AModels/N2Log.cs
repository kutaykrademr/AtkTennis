using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class N2Log
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklamasi { get; set; }
        public string Url { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int IslemTuru { get; set; }
        public int IslemSekli { get; set; }
        public int? KullaniciId { get; set; }
        public int? KortRezervasyonId { get; set; }
        public int? UyeId { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual Uye Uye { get; set; }
    }
}
