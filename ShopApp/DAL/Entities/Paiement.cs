using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Paiement
    {
        public Paiement()
        {
            Clientcommandes = new HashSet<Clientcommande>();
            Ptransacts = new HashSet<Ptransact>();
        }

        public int Paiementid { get; set; }
        public int Mdpid { get; set; }
        public int Cltcmdid { get; set; }
        public decimal? PMontant { get; set; }

        public virtual Clientcommande Cltcmd { get; set; }
        public virtual Moyendepaiement Mdp { get; set; }
        public virtual ICollection<Clientcommande> Clientcommandes { get; set; }
        public virtual ICollection<Ptransact> Ptransacts { get; set; }
    }
}
