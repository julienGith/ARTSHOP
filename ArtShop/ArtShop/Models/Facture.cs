using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Facture
    {
        public Facture()
        {
            Commandeclients = new HashSet<Commandeclient>();
        }

        public int Factureid { get; set; }
        public int Cmdcltid { get; set; }
        public string Factlien { get; set; }

        public virtual Commandeclient Cmdclt { get; set; }
        public virtual ICollection<Commandeclient> Commandeclients { get; set; }
    }
}
