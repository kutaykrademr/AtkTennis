using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class KortRezervasyonTarihce
    {
        public int Id { get; set; }
        public int IslemTuru { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public int? KullaniciId { get; set; }
        public int KortRezervasyonId { get; set; }

        public virtual KortRezervasyon KortRezervasyon { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
