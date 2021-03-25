using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("LITIGE")]
    [Index(nameof(Remboursementid), Name = "DONNER2_FK")]
    [Index(nameof(Btqcmdid), Name = "ENGENDRER_FK")]
    [Index(nameof(Rempid), Name = "ENVOYER2_FK")]
    public partial class Litige
    {
        public Litige()
        {
            Boutiquecommandes = new HashSet<Boutiquecommande>();
            Media = new HashSet<Medium>();
            Remboursements = new HashSet<Remboursement>();
            Remplacements = new HashSet<Remplacement>();
        }

        [Key]
        [Column("LITIGEID")]
        public int Litigeid { get; set; }
        [Column("REMBOURSEMENTID")]
        public int? Remboursementid { get; set; }
        [Column("REMPID")]
        public int? Rempid { get; set; }
        [Column("BTQCMDID")]
        public int Btqcmdid { get; set; }
        [Column("LTGMSG")]
        [StringLength(255)]
        public string Ltgmsg { get; set; }

        [ForeignKey(nameof(Btqcmdid))]
        [InverseProperty(nameof(Boutiquecommande.Litiges))]
        public virtual Boutiquecommande Btqcmd { get; set; }
        [ForeignKey(nameof(Remboursementid))]
        [InverseProperty("Litiges")]
        public virtual Remboursement Remboursement { get; set; }
        [ForeignKey(nameof(Rempid))]
        [InverseProperty(nameof(Remplacement.Litiges))]
        public virtual Remplacement Remp { get; set; }
        [InverseProperty(nameof(Boutiquecommande.Litige))]
        public virtual ICollection<Boutiquecommande> Boutiquecommandes { get; set; }
        [InverseProperty(nameof(Medium.Litige))]
        public virtual ICollection<Medium> Media { get; set; }
        [InverseProperty("Litige")]
        public virtual ICollection<Remboursement> Remboursements { get; set; }
        [InverseProperty(nameof(Remplacement.Litige))]
        public virtual ICollection<Remplacement> Remplacements { get; set; }
    }
}
