using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class UyeRehber
    {
        public UyeRehber()
        {
            SendEmailAliciUyes = new HashSet<SendEmailAliciUye>();
            SmsmesajAliciUyes = new HashSet<SmsmesajAliciUye>();
        }

        public int Id { get; set; }
        public string Bilgi { get; set; }
        public string BilgiAciklama { get; set; }
        public bool? Smsgonderme { get; set; }
        public int UyeRehberTuru { get; set; }
        public int? KaraListe { get; set; }
        public int? SehirId { get; set; }
        public int? IlceId { get; set; }
        public int UyeId { get; set; }

        public virtual Ilce Ilce { get; set; }
        public virtual Sehir Sehir { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual ICollection<SendEmailAliciUye> SendEmailAliciUyes { get; set; }
        public virtual ICollection<SmsmesajAliciUye> SmsmesajAliciUyes { get; set; }
    }
}
