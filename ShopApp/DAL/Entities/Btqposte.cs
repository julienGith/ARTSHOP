using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Btqposte
    {
        public int Btqid { get; set; }
        public int Localisationid { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Localisation Localisation { get; set; }
    }
}
