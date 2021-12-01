using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeRehberGrup
    {
        public int Id { get; set; }
        public int UyeId { get; set; }
        public int UyeRehberKategoriId { get; set; }

        public virtual Uye Uye { get; set; }
        public virtual UyeRehberKategori UyeRehberKategori { get; set; }
    }
}
