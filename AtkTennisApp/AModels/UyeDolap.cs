using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeDolap
    {
        public UyeDolap()
        {
            UyeDolapOdemes = new HashSet<UyeDolapOdeme>();
        }

        public int Id { get; set; }
        public double Miktar { get; set; }
        public int Durumu { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Aciklama { get; set; }
        public int IslemYapanKullaniciId { get; set; }
        public int Turu { get; set; }
        public int Yil { get; set; }
        public int OdemeDurumu { get; set; }
        public int DolapId { get; set; }
        public int UyeId { get; set; }

        public virtual Dolap Dolap { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual ICollection<UyeDolapOdeme> UyeDolapOdemes { get; set; }
    }
}
