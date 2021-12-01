using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeBakiyeHarcama
    {
        public int Id { get; set; }
        public double Miktar { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Aciklama { get; set; }
        public int HarcamaTuru { get; set; }
        public int IlgiliId { get; set; }
        public int IslemYapanKullaniciId { get; set; }
        public int UyeBakiyeId { get; set; }

        public virtual Kullanici IslemYapanKullanici { get; set; }
        public virtual UyeBakiye UyeBakiye { get; set; }
    }
}
