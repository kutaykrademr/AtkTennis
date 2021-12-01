using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class SendEmailAliciKullanici
    {
        public int Id { get; set; }
        public int Durumu { get; set; }
        public int KullaniciId { get; set; }
        public int SendEmailId { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
