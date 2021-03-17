using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("PTRANSACT")]
    [Index(nameof(Transactionid), Name = "TRACER2_FK")]
    [Index(nameof(Paiementid), Name = "TRACER_FK")]
    public partial class Ptransact
    {
        [Key]
        [Column("PAIEMENTID")]
        public int Paiementid { get; set; }
        [Key]
        [Column("TRANSACTIONID")]
        public int Transactionid { get; set; }

        [ForeignKey(nameof(Paiementid))]
        [InverseProperty("Ptransacts")]
        public virtual Paiement Paiement { get; set; }
        [ForeignKey(nameof(Transactionid))]
        [InverseProperty("Ptransacts")]
        public virtual Transaction Transaction { get; set; }
    }
}
