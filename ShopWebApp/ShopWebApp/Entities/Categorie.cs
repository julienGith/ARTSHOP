using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShopWebApp.Entities
{
    [Table("CATEGORIE")]
    public partial class Categorie
    {
        public Categorie()
        {
            CatnavCatParents = new HashSet<Catnav>();
            CatnavCategories = new HashSet<Catnav>();
            Produits = new HashSet<Produit>();
            //Media = new HashSet<Medium>();
        }

        [Key]
        [Column("CATEGORIEID")]
        public int Categorieid { get; set; }
        [Column("CATEGORIENOM")]
        [StringLength(255)]
        public string Categorienom { get; set; }

        [InverseProperty(nameof(Catnav.CatParent))]
        public virtual ICollection<Catnav> CatnavCatParents { get; set; }
        [InverseProperty(nameof(Catnav.Categorie))]
        public virtual ICollection<Catnav> CatnavCategories { get; set; }
        [InverseProperty(nameof(Produit.Categorie))]
        public virtual ICollection<Produit> Produits { get; set; }
        //[InverseProperty(nameof(Medium.Categorieid))]
        //public virtual ICollection<Medium> Media { get; set; }

    }
}
