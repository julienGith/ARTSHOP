using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("CATNAV")]
    [Index(nameof(Categorieid), Name = "REGROUPER2_FK")]
    [Index(nameof(CatParentid), Name = "REGROUPER3_FK")]
    public partial class Catnav
    {
        [Key]
        [Column("CATEGORIEID")]
        public int Categorieid { get; set; }
        [Key]
        [Column("CAT_PARENTID")]
        public int CatParentid { get; set; }

        [ForeignKey(nameof(CatParentid))]
        [InverseProperty("CatnavCatParents")]
        public virtual Categorie CatParent { get; set; }
        [ForeignKey(nameof(Categorieid))]
        [InverseProperty("CatnavCategories")]
        public virtual Categorie Categorie { get; set; }
    }
}
