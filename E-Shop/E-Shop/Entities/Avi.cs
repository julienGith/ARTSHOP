using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("AVIS")]
    [Index(nameof(Id), Name = "AVIS2_FK")]
    [Index(nameof(Btqid), Name = "AVIS3_FK")]
    [Index(nameof(Prodid), Name = "AVIS_FK")]
    public partial class Avi
    {
        [Key]
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }
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
        [InverseProperty(nameof(Boutique.Avis))]
        public virtual Boutique Btq { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Partenaire.Avis))]
        public virtual Partenaire IdNavigation { get; set; }
        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.Avis))]
        public virtual Produit Prod { get; set; }
    }
}
