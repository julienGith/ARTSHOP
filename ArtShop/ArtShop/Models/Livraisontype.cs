using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Livraisontype
    {
        public Livraisontype()
        {
            Livraisons = new HashSet<Livraison>();
            Produits = new HashSet<Produit>();
        }

        public int Lvrtypid { get; set; }
        public string Lvrdesignation { get; set; }
        public short? Lvrdelai { get; set; }
        public decimal? Lvrcout { get; set; }

        public virtual ICollection<Livraison> Livraisons { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
