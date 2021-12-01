using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Sehir
    {
        public Sehir()
        {
            Ilces = new HashSet<Ilce>();
            UyeRehbers = new HashSet<UyeRehber>();
            Uyes = new HashSet<Uye>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public int Plaka { get; set; }

        public virtual ICollection<Ilce> Ilces { get; set; }
        public virtual ICollection<UyeRehber> UyeRehbers { get; set; }
        public virtual ICollection<Uye> Uyes { get; set; }
    }
}
