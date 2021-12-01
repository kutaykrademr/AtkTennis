using System;
using System.Collections.Generic;

#nullable disable

namespace AtkTennisApp.AModels
{
    public partial class OkulTuru
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int Durumu { get; set; }
        public int ZamanDilimi { get; set; }
        public int? CizelgeSkalasiId { get; set; }

        public virtual CizelgeSkalasi CizelgeSkalasi { get; set; }
    }
}
