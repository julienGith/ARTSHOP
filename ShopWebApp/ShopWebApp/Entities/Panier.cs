using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShopWebApp.Entities
{
    [Table("PANIER")]
    [Index(nameof(Partenaireid), Name = "DISPOSER_FK")]
    public partial class Panier
    {
        public Panier()
        {
            Panierdetails = new HashSet<Panierdetail>();
            Partenaires = new HashSet<Partenaire>();
        }

        [Key]
        [Column("PANIERID")]
        public int Panierid { get; set; }
        [Column("PARTENAIREID")]
        public int? Partenaireid { get; set; }

        [ForeignKey(nameof(Partenaireid))]
        [InverseProperty("Paniers")]
        public virtual Partenaire Partenaire { get; set; }
        [InverseProperty(nameof(Panierdetail.Panier))]
        public virtual ICollection<Panierdetail> Panierdetails { get; set; }
        [InverseProperty("Panier")]
        public virtual ICollection<Partenaire> Partenaires { get; set; }
    }
}
