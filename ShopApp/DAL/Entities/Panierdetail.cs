using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("PANIERDETAIL")]
    [Index(nameof(Prodid), Name = "CONTENIR2_FK")]
    [Index(nameof(Panierid), Name = "CONTENIR_FK")]
    public partial class Panierdetail
    {
        [Key]
        [Column("PANIERID")]
        public int Panierid { get; set; }
        [Key]
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Column("P_QTEPROD")]
        public short? PQteprod { get; set; }

        [ForeignKey(nameof(Panierid))]
        [InverseProperty("Panierdetails")]
        public virtual Panier Panier { get; set; }
        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.Panierdetails))]
        public virtual Produit Prod { get; set; }
    }
}
