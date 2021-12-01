using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeBakiye
    {
        public UyeBakiye()
        {
            UyeBakiyeHarcamas = new HashSet<UyeBakiyeHarcama>();
        }

        public int Id { get; set; }
        public double Miktar { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int YuklemeTuru { get; set; }
        public string Aciklama { get; set; }
        public string MakbuzNumarasi { get; set; }
        public DateTime? MakbuzTarihi { get; set; }
        public int UyeId { get; set; }
        public int EkleyenKullaniciId { get; set; }

        public virtual Kullanici EkleyenKullanici { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual ICollection<UyeBakiyeHarcama> UyeBakiyeHarcamas { get; set; }
    }
}
