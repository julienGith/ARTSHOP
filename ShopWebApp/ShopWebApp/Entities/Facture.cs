using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShopWebApp.Entities
{
    [Table("FACTURE")]
    [Index(nameof(Cltcmdid), Name = "GENERER_FK")]
    public partial class Facture
    {
        public Facture()
        {
            Clientcommandes = new HashSet<Clientcommande>();
        }

        [Key]
        [Column("FACTUREID")]
        public int Factureid { get; set; }
        [Column("CLTCMDID")]
        public int Cltcmdid { get; set; }
        [Column("FACTLIEN")]
        [StringLength(255)]
        public string Factlien { get; set; }

        [ForeignKey(nameof(Cltcmdid))]
        [InverseProperty(nameof(Clientcommande.Factures))]
        public virtual Clientcommande Cltcmd { get; set; }
        [InverseProperty(nameof(Clientcommande.Facture))]
        public virtual ICollection<Clientcommande> Clientcommandes { get; set; }
    }
}
