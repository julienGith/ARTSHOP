using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("PAIEMENT")]
    [Index(nameof(Cltcmdid), Name = "PRENDRE_FK")]
    [Index(nameof(Mdpid), Name = "REGLER_FK")]
    public partial class Paiement
    {
        public Paiement()
        {
            Clientcommandes = new HashSet<Clientcommande>();
            PaieTransacts = new HashSet<PaieTransact>();
        }

        [Key]
        [Column("PAIEMENTID")]
        public int Paiementid { get; set; }
        [Column("MDPID")]
        public int Mdpid { get; set; }
        [Column("CLTCMDID")]
        public int Cltcmdid { get; set; }
        [Column("P_MONTANT", TypeName = "decimal(9, 2)")]
        public decimal? PMontant { get; set; }

        [ForeignKey(nameof(Cltcmdid))]
        [InverseProperty(nameof(Clientcommande.Paiements))]
        public virtual Clientcommande Cltcmd { get; set; }
        [ForeignKey(nameof(Mdpid))]
        [InverseProperty(nameof(Moyendepaiement.Paiements))]
        public virtual Moyendepaiement Mdp { get; set; }
        [InverseProperty(nameof(Clientcommande.Paiement))]
        public virtual ICollection<Clientcommande> Clientcommandes { get; set; }
        [InverseProperty(nameof(PaieTransact.Paiement))]
        public virtual ICollection<PaieTransact> PaieTransacts { get; set; }
    }
}
