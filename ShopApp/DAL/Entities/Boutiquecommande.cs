using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("BOUTIQUECOMMANDE")]
    [Index(nameof(Cltcmdid), Name = "ASSOCIER_FK")]
    [Index(nameof(Cmdetatid), Name = "COMPRENDRE_FK")]
    [Index(nameof(Litigeid), Name = "ENGENDRER2_FK")]
    [Index(nameof(Btqid), Name = "RECEVOIR_FK")]
    public partial class Boutiquecommande
    {
        public Boutiquecommande()
        {
            Btqcmddetails = new HashSet<Btqcmddetail>();
            Litiges = new HashSet<Litige>();
        }

        [Key]
        [Column("BTQCMDID")]
        public int Btqcmdid { get; set; }
        [Column("CMDETATID")]
        public int Cmdetatid { get; set; }
        [Column("LITIGEID")]
        public int? Litigeid { get; set; }
        [Column("CLTCMDID")]
        public int? Cltcmdid { get; set; }
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Column("BTQCMDDATECREA", TypeName = "datetime")]
        public DateTime? Btqcmddatecrea { get; set; }
        [Column("BTQCMDDATEDEBUT", TypeName = "datetime")]
        public DateTime? Btqcmddatedebut { get; set; }
        [Column("BTQCMDDATEFIN", TypeName = "datetime")]
        public DateTime? Btqcmddatefin { get; set; }

        [ForeignKey(nameof(Btqid))]
        [InverseProperty(nameof(Boutique.Boutiquecommandes))]
        public virtual Boutique Btq { get; set; }
        [ForeignKey(nameof(Cltcmdid))]
        [InverseProperty(nameof(Clientcommande.Boutiquecommandes))]
        public virtual Clientcommande Cltcmd { get; set; }
        [ForeignKey(nameof(Cmdetatid))]
        [InverseProperty("Boutiquecommandes")]
        public virtual Cmdetat Cmdetat { get; set; }
        [ForeignKey(nameof(Litigeid))]
        [InverseProperty("Boutiquecommandes")]
        public virtual Litige Litige { get; set; }
        [InverseProperty(nameof(Btqcmddetail.Btqcmd))]
        public virtual ICollection<Btqcmddetail> Btqcmddetails { get; set; }
        [InverseProperty("Btqcmd")]
        public virtual ICollection<Litige> Litiges { get; set; }
    }
}
