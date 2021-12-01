using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class Smshesap
    {
        public Smshesap()
        {
            Smsbasliks = new HashSet<Smsbaslik>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Smskredi { get; set; }
        public double KontorKredi { get; set; }
        public double AlphanumericPrice { get; set; }
        public double NumericPrice { get; set; }
        public double InternationalPrice { get; set; }

        public virtual ICollection<Smsbaslik> Smsbasliks { get; set; }
    }
}
