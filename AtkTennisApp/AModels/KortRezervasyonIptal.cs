using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class KortRezervasyonIptal
    {
        public int Id { get; set; }
        public string SaatSecimi { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public int IslemYapanKullaniciId { get; set; }
        public int KortRezervasyonId { get; set; }

        public virtual KortRezervasyon KortRezervasyon { get; set; }
    }
}
