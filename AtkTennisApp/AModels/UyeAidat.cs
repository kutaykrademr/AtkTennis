using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeAidat
    {
        public UyeAidat()
        {
            UyeAidatOdemes = new HashSet<UyeAidatOdeme>();
            UyeAidatTarihces = new HashSet<UyeAidatTarihce>();
        }

        public int Id { get; set; }
        public double Miktar { get; set; }
        public int Durumu { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Aciklama { get; set; }
        public int IslemYapanKullaniciId { get; set; }
        public int? UyeFiyatlandirmaId { get; set; }
        public int UyeId { get; set; }
        public int OdemeDurumu { get; set; }

        public virtual Uye Uye { get; set; }
        public virtual UyeFiyatlandirma UyeFiyatlandirma { get; set; }
        public virtual ICollection<UyeAidatOdeme> UyeAidatOdemes { get; set; }
        public virtual ICollection<UyeAidatTarihce> UyeAidatTarihces { get; set; }
    }
}
