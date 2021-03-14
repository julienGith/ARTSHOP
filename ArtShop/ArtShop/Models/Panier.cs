using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Panier
    {
        public Panier()
        {
            Pandetails = new HashSet<Pandetail>();
            Partenaires = new HashSet<Partenaire>();
        }

        public int Panierid { get; set; }
        public int? Partenaireid { get; set; }

        public virtual Partenaire Partenaire { get; set; }
        public virtual ICollection<Pandetail> Pandetails { get; set; }
        public virtual ICollection<Partenaire> Partenaires { get; set; }
    }
}
