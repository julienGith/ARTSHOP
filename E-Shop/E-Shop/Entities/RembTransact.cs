using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("REMB_TRANSACT")]
    [Index(nameof(Transactionid), Name = "TRAQUER2_FK")]
    [Index(nameof(Remboursementid), Name = "TRAQUER_FK")]
    public partial class RembTransact
    {
        [Key]
        [Column("REMBOURSEMENTID")]
        public int Remboursementid { get; set; }
        [Key]
        [Column("TRANSACTIONID")]
        public int Transactionid { get; set; }

        [ForeignKey(nameof(Remboursementid))]
        [InverseProperty("RembTransacts")]
        public virtual Remboursement Remboursement { get; set; }
        [ForeignKey(nameof(Transactionid))]
        [InverseProperty("RembTransacts")]
        public virtual Transaction Transaction { get; set; }
    }
}
