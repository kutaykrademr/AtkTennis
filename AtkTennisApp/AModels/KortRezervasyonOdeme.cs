using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class KortRezervasyonOdeme
    {
        public int Id { get; set; }
        public double OdenenFiyat { get; set; }
        public int OdemeTipi { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public string MakbuzNumarasi { get; set; }
        public DateTime? MakbuzTarihi { get; set; }
        public string Aciklama { get; set; }
        public int KortRezervasyonId { get; set; }

        public virtual KortRezervasyon KortRezervasyon { get; set; }
    }
}
