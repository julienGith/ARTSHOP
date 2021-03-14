using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Politique
    {
        public Politique()
        {
            Boutiques = new HashSet<Boutique>();
        }

        public int Politiqueid { get; set; }
        public bool? Echange { get; set; }
        public bool? Remboursement { get; set; }
        public string Pltqdescription { get; set; }

        public virtual ICollection<Boutique> Boutiques { get; set; }
    }
}
