using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Cltcmddetail
    {
        public int Cltcmdid { get; set; }
        public int Prodid { get; set; }
        public int Livraisonid { get; set; }
        public short? CCmdQteprod { get; set; }

        public virtual Clientcommande Cltcmd { get; set; }
        public virtual Livraison Livraison { get; set; }
        public virtual Produit Prod { get; set; }
    }
}
