using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("LIVRAISONETAT")]
    public partial class Livraisonetat
    {
        public Livraisonetat()
        {
            Livraisons = new HashSet<Livraison>();
        }

        [Key]
        [Column("LVRETATID")]
        public int Lvretatid { get; set; }
        [Column("LVRETAT")]
        [StringLength(15)]
        public string Lvretat { get; set; }

        [InverseProperty(nameof(Livraison.Lvretat))]
        public virtual ICollection<Livraison> Livraisons { get; set; }
    }
}
