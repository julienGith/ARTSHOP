using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("CLIENTCOMMANDE")]
    [Index(nameof(Cmdetatid), Name = "DETENIR_FK")]
    [Index(nameof(Factureid), Name = "GENERER2_FK")]
    [Index(nameof(Id), Name = "PASSER_FK")]
    [Index(nameof(Paiementid), Name = "PRENDRE2_FK")]
    public partial class Clientcommande
    {
        public Clientcommande()
        {
            Boutiquecommandes = new HashSet<Boutiquecommande>();
            CcDetails = new HashSet<CcDetail>();
            Factures = new HashSet<Facture>();
            Paiements = new HashSet<Paiement>();
        }

        [Key]
        [Column("CLTCMDID")]
        public int Cltcmdid { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        [Column("CMDETATID")]
        public int Cmdetatid { get; set; }
        [Column("PAIEMENTID")]
        public int? Paiementid { get; set; }
        [Column("FACTUREID")]
        public int? Factureid { get; set; }
        [Column("CLTCMDDATE", TypeName = "datetime")]
        public DateTime? Cltcmddate { get; set; }
        [Column("CLTCMDDATEDEBUT", TypeName = "datetime")]
        public DateTime? Cltcmddatedebut { get; set; }
        [Column("CLTCMDDATEFIN", TypeName = "datetime")]
        public DateTime? Cltcmddatefin { get; set; }

        [ForeignKey(nameof(Cmdetatid))]
        [InverseProperty("Clientcommandes")]
        public virtual Cmdetat Cmdetat { get; set; }
        [ForeignKey(nameof(Factureid))]
        [InverseProperty("Clientcommandes")]
        public virtual Facture Facture { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Partenaire.Clientcommandes))]
        public virtual Partenaire IdNavigation { get; set; }
        [ForeignKey(nameof(Paiementid))]
        [InverseProperty("Clientcommandes")]
        public virtual Paiement Paiement { get; set; }
        [InverseProperty(nameof(Boutiquecommande.Cltcmd))]
        public virtual ICollection<Boutiquecommande> Boutiquecommandes { get; set; }
        [InverseProperty(nameof(CcDetail.Cltcmd))]
        public virtual ICollection<CcDetail> CcDetails { get; set; }
        [InverseProperty("Cltcmd")]
        public virtual ICollection<Facture> Factures { get; set; }
        [InverseProperty("Cltcmd")]
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
