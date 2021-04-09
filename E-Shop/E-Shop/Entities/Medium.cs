using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("MEDIA")]
    [Index(nameof(Btqid), Name = "BOUTMEDIA_FK")]
    [Index(nameof(Categorieid), Name = "CATMEDIA_FK")]
    [Index(nameof(Litigeid), Name = "LTGMEDIA_FK")]
    [Index(nameof(Prodid), Name = "PRODMEDIA_FK")]
    public partial class Medium
    {
        [Key]
        [Column("MEDIAID")]
        public int Mediaid { get; set; }
        [Column("CATEGORIEID")]
        public int? Categorieid { get; set; }
        [Column("PRODID")]
        public int? Prodid { get; set; }
        [Column("LITIGEID")]
        public int? Litigeid { get; set; }
        [Column("BTQID")]
        public int? Btqid { get; set; }
        [Column("LIEN")]
        [StringLength(255)]
        public string Lien { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(255)]
        public string Description { get; set; }
        [Column("IMAGE")]
        public bool? Image { get; set; }
        [Column("VIDEO")]
        public bool? Video { get; set; }
        [Column("LIENCOMPLET")]
        public string LienComplet { get; set; }

        [ForeignKey(nameof(Btqid))]
        [InverseProperty(nameof(Boutique.Media))]
        public virtual Boutique Btq { get; set; }
        [ForeignKey(nameof(Categorieid))]
        [InverseProperty("Media")]
        public virtual Categorie Categorie { get; set; }
        [ForeignKey(nameof(Litigeid))]
        [InverseProperty("Media")]
        public virtual Litige Litige { get; set; }
        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.Media))]
        public virtual Produit Prod { get; set; }
    }
}
