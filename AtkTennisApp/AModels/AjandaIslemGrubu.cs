using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class AjandaIslemGrubu
    {
        public AjandaIslemGrubu()
        {
            Ajanda = new HashSet<Ajandum>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string RenkKodu { get; set; }
        public int Turu { get; set; }

        public virtual ICollection<Ajandum> Ajanda { get; set; }
    }
}
