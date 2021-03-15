using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Medium
    {
        public int Mediaid { get; set; }
        public int? Prodid { get; set; }
        public int? Litigeid { get; set; }
        public int? Btqid { get; set; }
        public string Lien { get; set; }
        public string Description { get; set; }
        public bool? Image { get; set; }
        public bool? Video { get; set; }
        public string Html { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Litige Litige { get; set; }
        public virtual Produit Prod { get; set; }
    }
}
