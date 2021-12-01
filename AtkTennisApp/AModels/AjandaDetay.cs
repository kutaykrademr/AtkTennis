using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class AjandaDetay
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public int AjandaId { get; set; }
        public int KullaniciId { get; set; }

        public virtual Ajandum Ajanda { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
