using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("CMDETAT")]
    public partial class Cmdetat
    {
        public Cmdetat()
        {
            Boutiquecommandes = new HashSet<Boutiquecommande>();
            Clientcommandes = new HashSet<Clientcommande>();
        }

        [Key]
        [Column("CMDETATID")]
        public int Cmdetatid { get; set; }
        [Column("CMDETAT")]
        [StringLength(15)]
        public string Cmdetat1 { get; set; }

        [InverseProperty(nameof(Boutiquecommande.Cmdetat))]
        public virtual ICollection<Boutiquecommande> Boutiquecommandes { get; set; }
        [InverseProperty(nameof(Clientcommande.Cmdetat))]
        public virtual ICollection<Clientcommande> Clientcommandes { get; set; }
    }
}
