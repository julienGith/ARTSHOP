using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Entities
{
    [Table("PRODLVRTYPE")]
    [Index(nameof(LvrTypeId), Name = "LVRTYPE_FK")]
    [Index(nameof(ProdId), Name = "PROD_FK")]
    public partial class ProdLvrType
    {
        [Key]
        [Column("PRODID")]
        public int ProdId { get; set; }
        [Key]
        [Column("LVRTYPEID")]
        public int LvrTypeId { get; set; }

        [ForeignKey(nameof(ProdId))]
        [InverseProperty(nameof(Produit.ProdLivraisonTypes))]
        public virtual Produit Prod { get; set; }
        [ForeignKey(nameof(LvrTypeId))]
        [InverseProperty("ProdLivraisonTypes")]
        public virtual Livraisontype Livraisontype { get; set; }

    }
}
