using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Pointrelai
    {
        public int Btqid { get; set; }
        public int Localisationid { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Localisation Localisation { get; set; }
    }
}
