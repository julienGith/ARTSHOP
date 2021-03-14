using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Cmdbtqdetail
    {
        public int Cmdbtqid { get; set; }
        public int Prodid { get; set; }
        public int Livraisonid { get; set; }
        public short? BCmdQteprod { get; set; }

        public virtual Commandeboutique Cmdbtq { get; set; }
        public virtual Livraison Livraison { get; set; }
        public virtual Produit Prod { get; set; }
    }
}
