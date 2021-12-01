using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class SmsmesajAliciKullanici
    {
        public int Id { get; set; }
        public string ReceiverId { get; set; }
        public int Durumu { get; set; }
        public string Gsmno { get; set; }
        public int KullaniciId { get; set; }
        public int SmsmesajId { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual Smsmesaj Smsmesaj { get; set; }
    }
}
