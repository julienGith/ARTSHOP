using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
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
        [Column("RETOURID")]
        public int Retourid { get; set; }
        [Column("LITIGEID")]
        public int Litigeid { get; set; }
        [Column("R_SUIVINUM")]
        [StringLength(255)]
        public string RSuivinum { get; set; }
        [Column("R_SUIVILIEN")]
        [StringLength(255)]
        public string RSuivilien { get; set; }

        [ForeignKey(nameof(Litigeid))]
        [InverseProperty("Remplacements")]
        public virtual Litige Litige { get; set; }
        [InverseProperty("Retour")]
        public virtual ICollection<Litige> Litiges { get; set; }
    }
}
