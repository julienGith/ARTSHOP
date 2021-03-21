using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShopWebApp.Entities
{
    [Table("RTRANSACT")]
    [Index(nameof(Transactionid), Name = "TRAQUER2_FK")]
    [Index(nameof(Remboursementid), Name = "TRAQUER_FK")]
    public partial class Rtransact
    {
        [Key]
        [Column("REMBOURSEMENTID")]
        public int Remboursementid { get; set; }
        [Key]
        [Column("TRANSACTIONID")]
        public int Transactionid { get; set; }

        [ForeignKey(nameof(Remboursementid))]
        [InverseProperty("Rtransacts")]
        public virtual Remboursement Remboursement { get; set; }
        [ForeignKey(nameof(Transactionid))]
        [InverseProperty("Rtransacts")]
        public virtual Transaction Transaction { get; set; }
    }
}
