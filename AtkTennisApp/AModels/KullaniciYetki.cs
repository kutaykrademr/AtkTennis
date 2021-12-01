using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class KullaniciYetki
    {
        public int KullaniciId { get; set; }
        public int YetkiId { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual Yetki Yetki { get; set; }
    }
}
