using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("REMPLACEMENT")]
    [Index(nameof(Litigeid), Name = "ENVOYER_FK")]
    public partial class Remplacement
    {
        public Remplacement()
        {
            Litiges = new HashSet<Litige>();
        }

        [Key]
        [Column("REMPID")]
        public int Rempid { get; set; }
        [Column("LITIGEID")]
        public int Litigeid { get; set; }
        [Column("R_SUIVINUM")]
        public string RSuivinum { get; set; }
        [Column("R_SUIVILIEN")]
        public string RSuivilien { get; set; }

        [ForeignKey(nameof(Litigeid))]
        [InverseProperty("Remplacements")]
        public virtual Litige Litige { get; set; }
        [InverseProperty("Remp")]
        public virtual ICollection<Litige> Litiges { get; set; }
    }
}
