using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("CATNAV")]
    [Index(nameof(CatCategorieid), Name = "REGROUPER2_FK")]
    [Index(nameof(Categorieid), Name = "REGROUPER_FK")]
    public partial class Catnav
    {
        [Key]
        [Column("CATEGORIEID")]
        public int Categorieid { get; set; }
        [Key]
        [Column("CAT_CATEGORIEID")]
        public int CatCategorieid { get; set; }

        [ForeignKey(nameof(CatCategorieid))]
        [InverseProperty("CatnavCatCategories")]
        public virtual Categorie CatCategorie { get; set; }
        [ForeignKey(nameof(Categorieid))]
        [InverseProperty("CatnavCategories")]
        public virtual Categorie Categorie { get; set; }
    }
}
