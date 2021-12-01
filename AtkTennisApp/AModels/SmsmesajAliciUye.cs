using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class SmsmesajAliciUye
    {
        public int Id { get; set; }
        public string ReceiverId { get; set; }
        public int Durumu { get; set; }
        public int UyeRehberId { get; set; }
        public int SmsmesajId { get; set; }

        public virtual Smsmesaj Smsmesaj { get; set; }
        public virtual UyeRehber UyeRehber { get; set; }
    }
}
