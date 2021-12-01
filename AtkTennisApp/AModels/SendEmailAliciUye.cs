using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class SendEmailAliciUye
    {
        public int Id { get; set; }
        public int Durumu { get; set; }
        public int UyeRehberId { get; set; }
        public int SendEmailId { get; set; }

        public virtual UyeRehber UyeRehber { get; set; }
    }
}
