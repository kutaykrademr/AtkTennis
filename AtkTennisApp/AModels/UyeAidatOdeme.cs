using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeAidatOdeme
    {
        public int Id { get; set; }
        public double OdenenFiyat { get; set; }
        public int OdemeTipi { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public string MakbuzNumarasi { get; set; }
        public DateTime? MakbuzTarihi { get; set; }
        public string Aciklama { get; set; }
        public int IslemYapanKullaniciId { get; set; }
        public int UyeAidatId { get; set; }

        public virtual Kullanici IslemYapanKullanici { get; set; }
        public virtual UyeAidat UyeAidat { get; set; }
    }
}
