using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Ilce
    {
        public Ilce()
        {
            UyeRehbers = new HashSet<UyeRehber>();
            Uyes = new HashSet<Uye>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public int SehirId { get; set; }

        public virtual Sehir Sehir { get; set; }
        public virtual ICollection<UyeRehber> UyeRehbers { get; set; }
        public virtual ICollection<Uye> Uyes { get; set; }
    }
}
