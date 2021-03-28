using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("ECHANGE")]
    [Index(nameof(Prodid), Name = "ECHANGE2_FK")]
    [Index(nameof(Btqid), Name = "ECHANGE3_FK")]
    [Index(nameof(Id), Name = "ECHANGE_FK")]
    public partial class Echange
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Key]
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Key]
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Column("E_QUEST")]
        [StringLength(450)]
        public string EQuest { get; set; }
        [Column("E_REP")]
        [StringLength(450)]
        public string ERep { get; set; }
        [Column("E_QUESTDATE", TypeName = "datetime")]
        public DateTime? EQuestdate { get; set; }
        [Column("E_REPDATE", TypeName = "datetime")]
        public DateTime? ERepdate { get; set; }

        [ForeignKey(nameof(Btqid))]
        [InverseProperty(nameof(Boutique.Echanges))]
        public virtual Boutique Btq { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Partenaire.Echanges))]
        public virtual Partenaire IdNavigation { get; set; }
        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.Echanges))]
        public virtual Produit Prod { get; set; }
    }
}
