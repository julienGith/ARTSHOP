﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("CATEGORIE")]
    public partial class Categorie
    {
        public Categorie()
        {
            CatnavCatParents = new HashSet<Catnav>();
            CatnavCategories = new HashSet<Catnav>();
            Produits = new HashSet<Produit>();
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
    }
}
