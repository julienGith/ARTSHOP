using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("TRANSACTION")]
    public partial class Transaction
    {
        public Transaction()
        {
            Ptransacts = new HashSet<Ptransact>();
            Rtransacts = new HashSet<Rtransact>();
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
        [StringLength(255)]
        public string Transactcontenu { get; set; }

        [InverseProperty(nameof(Ptransact.Transaction))]
        public virtual ICollection<Ptransact> Ptransacts { get; set; }
        [InverseProperty(nameof(Rtransact.Transaction))]
        public virtual ICollection<Rtransact> Rtransacts { get; set; }
    }
}
