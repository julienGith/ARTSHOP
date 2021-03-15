using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Facture
    {
        public Facture()
        {
            Clientcommandes = new HashSet<Clientcommande>();
        }

        public int Factureid { get; set; }
        public int Cltcmdid { get; set; }
        public string Factlien { get; set; }

        public virtual Clientcommande Cltcmd { get; set; }
        public virtual ICollection<Clientcommande> Clientcommandes { get; set; }
    }
}
