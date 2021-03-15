using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Panier
    {
        public Panier()
        {
            Panierdetails = new HashSet<Panierdetail>();
            Partenaires = new HashSet<Partenaire>();
        }

        public int Panierid { get; set; }
        public int? Partenaireid { get; set; }

        public virtual Partenaire Partenaire { get; set; }
        public virtual ICollection<Panierdetail> Panierdetails { get; set; }
        public virtual ICollection<Partenaire> Partenaires { get; set; }
    }
}
