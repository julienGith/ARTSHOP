using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("PAIE_TRANSACT")]
    [Index(nameof(Transactionid), Name = "TRACER2_FK")]
    [Index(nameof(Paiementid), Name = "TRACER_FK")]
    public partial class PaieTransact
    {
        [Key]
        [Column("PAIEMENTID")]
        public int Paiementid { get; set; }
        [Key]
        [Column("TRANSACTIONID")]
        public int Transactionid { get; set; }

        [ForeignKey(nameof(Paiementid))]
        [InverseProperty("PaieTransacts")]
        public virtual Paiement Paiement { get; set; }
        [ForeignKey(nameof(Transactionid))]
        [InverseProperty("PaieTransacts")]
        public virtual Transaction Transaction { get; set; }
    }
}
