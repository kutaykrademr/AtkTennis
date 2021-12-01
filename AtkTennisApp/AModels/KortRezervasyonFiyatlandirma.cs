using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class KortRezervasyonFiyatlandirma
    {
        public int Id { get; set; }
        public int KortRezervasyonId { get; set; }
        public int RezervasyonFiyatlandirmaId { get; set; }
        public double Fiyat { get; set; }

        public virtual KortRezervasyon KortRezervasyon { get; set; }
        public virtual RezervasyonFiyatlandirma RezervasyonFiyatlandirma { get; set; }
    }
}
