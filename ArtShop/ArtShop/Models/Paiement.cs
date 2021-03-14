using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Paiement
    {
        public Paiement()
        {
            Commandeclients = new HashSet<Commandeclient>();
            Ptransacts = new HashSet<Ptransact>();
        }

        public int Paiementid { get; set; }
        public int Mdpid { get; set; }
        public int Cmdcltid { get; set; }
        public decimal? PMontant { get; set; }

        public virtual Commandeclient Cmdclt { get; set; }
        public virtual Moyendepaiement Mdp { get; set; }
        public virtual ICollection<Commandeclient> Commandeclients { get; set; }
        public virtual ICollection<Ptransact> Ptransacts { get; set; }
    }
}
