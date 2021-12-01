using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Smsmesaj
    {
        public Smsmesaj()
        {
            SmsmesajAliciKullanicis = new HashSet<SmsmesajAliciKullanici>();
            SmsmesajAliciUyes = new HashSet<SmsmesajAliciUye>();
        }

        public int Id { get; set; }
        public DateTime GondermeTarihi { get; set; }
        public string Icerik { get; set; }
        public int Unicode { get; set; }
        public int International { get; set; }
        public double Ucretlendirme { get; set; }
        public int Smssayisi { get; set; }
        public int BasariliAlici { get; set; }
        public int BasarisizAlici { get; set; }
        public string DonenMesajId { get; set; }
        public int Durumu { get; set; }
        public int SmsbaslikId { get; set; }
        public int GonderenKullaniciId { get; set; }

        public virtual Kullanici GonderenKullanici { get; set; }
        public virtual Smsbaslik Smsbaslik { get; set; }
        public virtual ICollection<SmsmesajAliciKullanici> SmsmesajAliciKullanicis { get; set; }
        public virtual ICollection<SmsmesajAliciUye> SmsmesajAliciUyes { get; set; }
    }
}
