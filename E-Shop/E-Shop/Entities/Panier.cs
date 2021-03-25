using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("PANIER")]
    [Index(nameof(Id), Name = "DISPOSER_FK")]
    public partial class Panier
    {
        public Panier()
        {
            PDetails = new HashSet<PDetail>();
            Partenaires = new HashSet<Partenaire>();
        }

        [Key]
        [Column("PANIERID")]
        public int Panierid { get; set; }
        [Column("ID")]
        public int? Id { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Partenaire.Paniers))]
        public virtual Partenaire IdNavigation { get; set; }
        [InverseProperty(nameof(PDetail.Panier))]
        public virtual ICollection<PDetail> PDetails { get; set; }
        [InverseProperty(nameof(Partenaire.Panier))]
        public virtual ICollection<Partenaire> Partenaires { get; set; }
    }
}
