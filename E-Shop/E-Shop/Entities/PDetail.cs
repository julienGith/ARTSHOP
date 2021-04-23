using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("P_DETAIL")]
    [Index(nameof(Prodid), Name = "CONTENIR2_FK")]
    [Index(nameof(Panierid), Name = "CONTENIR_FK")]
    public partial class PDetail
    {
        [Key]
        [Column("PANIERID")]
        public int Panierid { get; set; }
        [Key]
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Key]
        [Column("FORMATID")]
        public int Formatid { get; set; }
        [Column("P_QTEPROD")]
        public short? PQteprod { get; set; }

        [ForeignKey(nameof(Panierid))]
        [InverseProperty("PDetails")]
        public virtual Panier Panier { get; set; }
        [ForeignKey(nameof(Formatid))]
        [InverseProperty("PDetails")]
        public virtual Format Format { get; set; }
        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.PDetails))]
        public virtual Produit Prod { get; set; }
    }
}
