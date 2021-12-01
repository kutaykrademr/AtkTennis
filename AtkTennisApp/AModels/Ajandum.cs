using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Ajandum
    {
        public Ajandum()
        {
            AjandaDetays = new HashSet<AjandaDetay>();
            AjandaDosyas = new HashSet<AjandaDosya>();
            AjandaKullanicis = new HashSet<AjandaKullanici>();
            AjandaNots = new HashSet<AjandaNot>();
        }

        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int KullaniciId { get; set; }
        public int AjandaIslemGrubuId { get; set; }
        public int? Durumu { get; set; }
        public int EkleyenKullaniciId { get; set; }

        public virtual AjandaIslemGrubu AjandaIslemGrubu { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual ICollection<AjandaDetay> AjandaDetays { get; set; }
        public virtual ICollection<AjandaDosya> AjandaDosyas { get; set; }
        public virtual ICollection<AjandaKullanici> AjandaKullanicis { get; set; }
        public virtual ICollection<AjandaNot> AjandaNots { get; set; }
    }
}
