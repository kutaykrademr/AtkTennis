using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class SmssablonMesaj
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public string Baslik { get; set; }
        public int Turu { get; set; }
    }
}
