using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class AjandaKullanici
    {
        public int Id { get; set; }
        public int Durumu { get; set; }
        public DateTime? OkunmaTarihi { get; set; }
        public int AjandaId { get; set; }
        public int KullaniciId { get; set; }

        public virtual Ajandum Ajanda { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
