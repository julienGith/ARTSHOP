using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Categorie
    {
        public Categorie()
        {
            CatnavCatParents = new HashSet<Catnav>();
            CatnavCategories = new HashSet<Catnav>();
            Produits = new HashSet<Produit>();
        }

        public int Categorieid { get; set; }
        public string Categorienom { get; set; }

        public virtual ICollection<Catnav> CatnavCatParents { get; set; }
        public virtual ICollection<Catnav> CatnavCategories { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
