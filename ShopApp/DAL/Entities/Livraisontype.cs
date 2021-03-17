using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("LIVRAISONTYPE")]
    public partial class Livraisontype
    {
        public Livraisontype()
        {
            Livraisons = new HashSet<Livraison>();
            Produits = new HashSet<Produit>();
        }

        [Key]
        [Column("LVRTYPID")]
        public int Lvrtypid { get; set; }
        [Column("LVRDESIGNATION")]
        [StringLength(15)]
        public string Lvrdesignation { get; set; }
        [Column("LVRDELAI")]
        public short? Lvrdelai { get; set; }
        [Column("LVRCOUT", TypeName = "decimal(9, 2)")]
        public decimal? Lvrcout { get; set; }

        [InverseProperty(nameof(Livraison.Lvrtyp))]
        public virtual ICollection<Livraison> Livraisons { get; set; }
        [InverseProperty(nameof(Produit.Lvrtyp))]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
