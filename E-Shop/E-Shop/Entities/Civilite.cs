using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("CIVILITE")]
    public partial class Civilite
    {
        public Civilite()
        {
            Identifications = new HashSet<Identification>();
        }

        [Key]
        [Column("CIVID")]
        public int Civid { get; set; }
        [Column("ABREGE")]
        [StringLength(5)]
        public string Abrege { get; set; }
        [Column("COMPLET")]
        [StringLength(15)]
        public string Complet { get; set; }

        [InverseProperty(nameof(Identification.Civ))]
        public virtual ICollection<Identification> Identifications { get; set; }
    }
}
