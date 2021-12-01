using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeRehberKategori
    {
        public UyeRehberKategori()
        {
            UyeRehberGrups = new HashSet<UyeRehberGrup>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public int? Sira { get; set; }
        public int UstUyeRehberKategoriId { get; set; }

        public virtual ICollection<UyeRehberGrup> UyeRehberGrups { get; set; }
    }
}
