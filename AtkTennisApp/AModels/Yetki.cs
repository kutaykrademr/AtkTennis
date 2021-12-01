using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Yetki
    {
        public Yetki()
        {
            KullaniciYetkis = new HashSet<KullaniciYetki>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public int UstYetkiId { get; set; }

        public virtual ICollection<KullaniciYetki> KullaniciYetkis { get; set; }
    }
}
