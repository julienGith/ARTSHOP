using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Btqcmddetail
    {
        public int Btqcmdid { get; set; }
        public int Prodid { get; set; }
        public int Livraisonid { get; set; }
        public short? BCmdQteprod { get; set; }

        public virtual Boutiquecommande Btqcmd { get; set; }
        public virtual Livraison Livraison { get; set; }
        public virtual Produit Prod { get; set; }
    }
}
