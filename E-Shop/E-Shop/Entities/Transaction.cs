﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("TRANSACTION")]
    public partial class Transaction
    {
        public Transaction()
        {
            PaieTransacts = new HashSet<PaieTransact>();
            RembTransacts = new HashSet<RembTransact>();
        }

        [Key]
        [Column("TRANSACTIONID")]
        public int Transactionid { get; set; }
        [Column("CODE")]
        [StringLength(100)]
        public string Code { get; set; }
        [Column("TYPE")]
        public short? Type { get; set; }
        [Column("MODE")]
        public short? Mode { get; set; }
        [Column("TRANSACTSTATUT")]
        public short? Transactstatut { get; set; }
        [Column("TRANSACTCREA", TypeName = "datetime")]
        public DateTime? Transactcrea { get; set; }
        [Column("TRANSACTMODIF", TypeName = "datetime")]
        public DateTime? Transactmodif { get; set; }
        [Column("TRANSACTCONTENU")]
        public string Transactcontenu { get; set; }

        [InverseProperty(nameof(PaieTransact.Transaction))]
        public virtual ICollection<PaieTransact> PaieTransacts { get; set; }
        [InverseProperty(nameof(RembTransact.Transaction))]
        public virtual ICollection<RembTransact> RembTransacts { get; set; }
    }
}
