using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("OPINION")]
    [Index(nameof(Partenaireid), Name = "AVIS2_FK")]
    [Index(nameof(Btqid), Name = "AVIS3_FK")]
    [Index(nameof(Prodid), Name = "AVIS_FK")]
    public partial class Opinion
    {
        [Key]
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Key]
        [Column("PARTENAIREID")]
        public int Partenaireid { get; set; }
        [Key]
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Column("A_NOTE")]
        public short? ANote { get; set; }
        [Column("A_DATE", TypeName = "datetime")]
        public DateTime? ADate { get; set; }
        [Column("A_TEXTE")]
        [StringLength(255)]
        public string ATexte { get; set; }
        [Column("A_REPONSE")]
        [StringLength(255)]
        public string AReponse { get; set; }
        [Column("A_REPDATE", TypeName = "datetime")]
        public DateTime? ARepdate { get; set; }

        [ForeignKey(nameof(Btqid))]
        [InverseProperty(nameof(Boutique.Opinions))]
        public virtual Boutique Btq { get; set; }
        [ForeignKey(nameof(Partenaireid))]
        [InverseProperty("Opinions")]
        public virtual Partenaire Partenaire { get; set; }
        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.Opinions))]
        public virtual Produit Prod { get; set; }
    }
}
