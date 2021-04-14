using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("LIVRAISONTYPE")]
    public partial class Livraisontype
    {
        public Livraisontype()
        {
            Livraisons = new HashSet<Livraison>();
            ProdLivraisonTypes = new HashSet<ProdLvrType>();
        }

        [Key]
        [Column("LVRTYPID")]
        public int Lvrtypid { get; set; }
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Column("LVRDESIGNATION")]
        public string Lvrdesignation { get; set; }
        [Column("LVRDELAI")]
        public short? Lvrdelai { get; set; }
        [Column("LVRCOUT", TypeName = "decimal(9, 2)")]
        public decimal? Lvrcout { get; set; }
        [Column("LVRCOUTPSUP", TypeName = "decimal(9, 2)")]
        public decimal? LvrcoutPsup { get; set; }

        [InverseProperty(nameof(Livraison.Lvrtyp))]
        public virtual ICollection<Livraison> Livraisons { get; set; }


        [InverseProperty(nameof(Boutique.Livraisontypes))]
        public virtual Boutique Btq { get; set; }

        [InverseProperty(nameof(ProdLvrType.Livraisontype))]
        public virtual ICollection<ProdLvrType> ProdLivraisonTypes { get; set; }
    }
}
