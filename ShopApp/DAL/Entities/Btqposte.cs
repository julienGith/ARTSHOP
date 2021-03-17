using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("BTQPOSTE")]
    [Index(nameof(Localisationid), Name = "PROPOSER2_FK")]
    [Index(nameof(Btqid), Name = "PROPOSER_FK")]
    public partial class Btqposte
    {
        [Key]
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Key]
        [Column("LOCALISATIONID")]
        public int Localisationid { get; set; }

        [ForeignKey(nameof(Btqid))]
        [InverseProperty(nameof(Boutique.Btqpostes))]
        public virtual Boutique Btq { get; set; }
        [ForeignKey(nameof(Localisationid))]
        [InverseProperty("Btqpostes")]
        public virtual Localisation Localisation { get; set; }
    }
}
