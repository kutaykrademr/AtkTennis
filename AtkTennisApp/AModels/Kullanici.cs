using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Kullanici
    {
        public Kullanici()
        {
            Ajanda = new HashSet<Ajandum>();
            AjandaDetays = new HashSet<AjandaDetay>();
            AjandaDosyas = new HashSet<AjandaDosya>();
            AjandaKullanicis = new HashSet<AjandaKullanici>();
            AjandaNots = new HashSet<AjandaNot>();
            KortRezervasyonTarihces = new HashSet<KortRezervasyonTarihce>();
            KullaniciYetkis = new HashSet<KullaniciYetki>();
            N2Logs = new HashSet<N2Log>();
            OnRezervasyons = new HashSet<OnRezervasyon>();
            SendEmailAliciKullanicis = new HashSet<SendEmailAliciKullanici>();
            SendEmails = new HashSet<SendEmail>();
            SmsmesajAliciKullanicis = new HashSet<SmsmesajAliciKullanici>();
            Smsmesajs = new HashSet<Smsmesaj>();
            UyeAidatOdemes = new HashSet<UyeAidatOdeme>();
            UyeAidatTarihces = new HashSet<UyeAidatTarihce>();
            UyeBakiyeHarcamas = new HashSet<UyeBakiyeHarcama>();
            UyeBakiyes = new HashSet<UyeBakiye>();
            UyeDolapOdemes = new HashSet<UyeDolapOdeme>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Sifre { get; set; }
        public string AdiSoyadi { get; set; }
        public string Email { get; set; }
        public int Durumu { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Ipadresi { get; set; }
        public string CepTelefon { get; set; }
        public string Avatar { get; set; }
        public int? Smslogin { get; set; }
        public string Tckimlik { get; set; }
        public int? MedeniDurumu { get; set; }
        public int? Ehliyet { get; set; }
        public string EvTelefon { get; set; }
        public int? Cinsiyet { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string EvAdresi { get; set; }

        public virtual ICollection<Ajandum> Ajanda { get; set; }
        public virtual ICollection<AjandaDetay> AjandaDetays { get; set; }
        public virtual ICollection<AjandaDosya> AjandaDosyas { get; set; }
        public virtual ICollection<AjandaKullanici> AjandaKullanicis { get; set; }
        public virtual ICollection<AjandaNot> AjandaNots { get; set; }
        public virtual ICollection<KortRezervasyonTarihce> KortRezervasyonTarihces { get; set; }
        public virtual ICollection<KullaniciYetki> KullaniciYetkis { get; set; }
        public virtual ICollection<N2Log> N2Logs { get; set; }
        public virtual ICollection<OnRezervasyon> OnRezervasyons { get; set; }
        public virtual ICollection<SendEmailAliciKullanici> SendEmailAliciKullanicis { get; set; }
        public virtual ICollection<SendEmail> SendEmails { get; set; }
        public virtual ICollection<SmsmesajAliciKullanici> SmsmesajAliciKullanicis { get; set; }
        public virtual ICollection<Smsmesaj> Smsmesajs { get; set; }
        public virtual ICollection<UyeAidatOdeme> UyeAidatOdemes { get; set; }
        public virtual ICollection<UyeAidatTarihce> UyeAidatTarihces { get; set; }
        public virtual ICollection<UyeBakiyeHarcama> UyeBakiyeHarcamas { get; set; }
        public virtual ICollection<UyeBakiye> UyeBakiyes { get; set; }
        public virtual ICollection<UyeDolapOdeme> UyeDolapOdemes { get; set; }
    }
}
