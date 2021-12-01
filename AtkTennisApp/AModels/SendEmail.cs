using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class SendEmail
    {
        public int Id { get; set; }
        public DateTime GondermeTarihi { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int Durumu { get; set; }
        public int? GonderenKullaniciId { get; set; }

        public virtual Kullanici GonderenKullanici { get; set; }
    }
}
