using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Cmdcltdetail
    {
        public int Cmdcltid { get; set; }
        public int Prodid { get; set; }
        public int Livraisonid { get; set; }
        public short? CCmdQteprod { get; set; }

        public virtual Commandeclient Cmdclt { get; set; }
        public virtual Livraison Livraison { get; set; }
        public virtual Produit Prod { get; set; }
    }
}
