using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Uye
    {
        public Uye()
        {
            KortRezervasyons = new HashSet<KortRezervasyon>();
            N2Logs = new HashSet<N2Log>();
            OnRezervasyons = new HashSet<OnRezervasyon>();
            UyeAidatTarihces = new HashSet<UyeAidatTarihce>();
            UyeAidats = new HashSet<UyeAidat>();
            UyeAiles = new HashSet<UyeAile>();
            UyeBakiyes = new HashSet<UyeBakiye>();
            UyeDolaps = new HashSet<UyeDolap>();
            UyeRehberGrups = new HashSet<UyeRehberGrup>();
            UyeRehbers = new HashSet<UyeRehber>();
        }

        public int Id { get; set; }
        public int UyelikNumarasi { get; set; }
        public string Tckimlik { get; set; }
        public string Rumuz { get; set; }
        public string Sifre { get; set; }
        public int Durumu { get; set; }
        public int WebDurumu { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string BabaAdi { get; set; }
        public string AnneAdi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public int Turu { get; set; }
        public string Gorsel { get; set; }
        public string Aciklama { get; set; }
        public int? Cinsiyet { get; set; }
        public string Meslek { get; set; }
        public DateTime UyelikBaslamaTarihi { get; set; }
        public DateTime? UyelikBitisTarihi { get; set; }
        public string DogumYeri { get; set; }
        public DateTime? SonGirisTarihi { get; set; }
        public string Ipadresi { get; set; }
        public int? ReferansUye1Id { get; set; }
        public int? ReferansUye2Id { get; set; }
        public int? IlceId { get; set; }
        public int? SehirId { get; set; }
        public int? DolapId { get; set; }
        public int Sekli { get; set; }
        public string RenkKodu { get; set; }
        public string RenkKoduFn { get; set; }

        public virtual Dolap Dolap { get; set; }
        public virtual Ilce Ilce { get; set; }
        public virtual Sehir Sehir { get; set; }
        public virtual ICollection<KortRezervasyon> KortRezervasyons { get; set; }
        public virtual ICollection<N2Log> N2Logs { get; set; }
        public virtual ICollection<OnRezervasyon> OnRezervasyons { get; set; }
        public virtual ICollection<UyeAidatTarihce> UyeAidatTarihces { get; set; }
        public virtual ICollection<UyeAidat> UyeAidats { get; set; }
        public virtual ICollection<UyeAile> UyeAiles { get; set; }
        public virtual ICollection<UyeBakiye> UyeBakiyes { get; set; }
        public virtual ICollection<UyeDolap> UyeDolaps { get; set; }
        public virtual ICollection<UyeRehberGrup> UyeRehberGrups { get; set; }
        public virtual ICollection<UyeRehber> UyeRehbers { get; set; }
    }
}
