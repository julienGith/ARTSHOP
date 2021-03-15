using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Civilite
    {
        public Civilite()
        {
            Identifications = new HashSet<Identification>();
        }

        public int Civid { get; set; }
        public string Abrege { get; set; }
        public string Complet { get; set; }

        public virtual ICollection<Identification> Identifications { get; set; }
    }
}
