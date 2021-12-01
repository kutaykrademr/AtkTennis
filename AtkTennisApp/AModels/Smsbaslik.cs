using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Smsbaslik
    {
        public Smsbaslik()
        {
            Smsmesajs = new HashSet<Smsmesaj>();
        }

        public int Id { get; set; }
        public int Durumu { get; set; }
        public string Adi { get; set; }
        public int SmshesapId { get; set; }

        public virtual Smshesap Smshesap { get; set; }
        public virtual ICollection<Smsmesaj> Smsmesajs { get; set; }
    }
}
