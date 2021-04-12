using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Entities
{
    [Table("FORMAT")]
    [Index(nameof(Prodid), Name = "PESER_FK")]
    public partial class Format
    {
        [Key]
        [Column("FORMATID")]
        public int Formatid { get; set; }
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Column("PRIX", TypeName = "decimal(9, 2)")]
        public decimal? Prix { get; set; }
        [Column("POIDS")]
        public decimal? Poids { get; set; }
        [Column("LITRE")]
        public decimal? Litre { get; set; }

        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.Formats))]
        public virtual Produit Prod { get; set; }
    }
}
