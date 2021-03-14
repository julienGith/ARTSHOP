using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Catnav
    {
        public int Categorieid { get; set; }
        public int CatParentid { get; set; }

        public virtual Categorie CatParent { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}
