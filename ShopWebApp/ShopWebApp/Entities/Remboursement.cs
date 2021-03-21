using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShopWebApp.Entities
{
    [Table("REMBOURSEMENT")]
    [Index(nameof(Litigeid), Name = "DONNER_FK")]
    public partial class Remboursement
    {
        public Remboursement()
        {
            Litiges = new HashSet<Litige>();
            Rtransacts = new HashSet<Rtransact>();
        }

        [Key]
        [Column("REMBOURSEMENTID")]
        public int Remboursementid { get; set; }
        [Column("LITIGEID")]
        public int Litigeid { get; set; }
        [Column("R_MONTANT", TypeName = "decimal(9, 2)")]
        public decimal? RMontant { get; set; }

        [ForeignKey(nameof(Litigeid))]
        [InverseProperty("Remboursements")]
        public virtual Litige Litige { get; set; }
        [InverseProperty("Remboursement")]
        public virtual ICollection<Litige> Litiges { get; set; }
        [InverseProperty(nameof(Rtransact.Remboursement))]
        public virtual ICollection<Rtransact> Rtransacts { get; set; }
    }
}
