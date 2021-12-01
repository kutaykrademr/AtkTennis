using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeAile
    {
        public int Id { get; set; }
        public string Tckimlik { get; set; }
        public string Rumuz { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string CepTel { get; set; }
        public string Meslegi { get; set; }
        public int Turu { get; set; }
        public string Aciklama { get; set; }
        public int Durumu { get; set; }
        public int? DolapId { get; set; }
        public int UyeId { get; set; }

        public virtual Dolap Dolap { get; set; }
        public virtual Uye Uye { get; set; }
    }
}
