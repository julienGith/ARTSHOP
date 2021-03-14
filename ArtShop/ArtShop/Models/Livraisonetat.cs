using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Livraisonetat
    {
        public Livraisonetat()
        {
            Livraisons = new HashSet<Livraison>();
        }

        public int Lvretatid { get; set; }
        public string Lvretat { get; set; }

        public virtual ICollection<Livraison> Livraisons { get; set; }
    }
}
