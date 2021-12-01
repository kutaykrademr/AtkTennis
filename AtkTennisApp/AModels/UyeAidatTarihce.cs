using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeAidatTarihce
    {
        public int Id { get; set; }
        public int IslemTuru { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public int? KullaniciId { get; set; }
        public int? UyeId { get; set; }
        public int UyeAidatId { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual UyeAidat UyeAidat { get; set; }
    }
}
