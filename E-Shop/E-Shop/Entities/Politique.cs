using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("POLITIQUE")]
    public partial class Politique
    {
        public Politique()
        {
            Boutiques = new HashSet<Boutique>();
        }

        [Key]
        [Column("POLITIQUEID")]
        public int Politiqueid { get; set; }
        [Column("ECHANGE")]
        public bool? Echange { get; set; }
        [Column("REMBOURSEMENT")]
        public bool? Remboursement { get; set; }
        [Column("PLTQDESCRIPTION")]
        public string Pltqdescription { get; set; }

        [InverseProperty(nameof(Boutique.Politique))]
        public virtual ICollection<Boutique> Boutiques { get; set; }
    }
}
