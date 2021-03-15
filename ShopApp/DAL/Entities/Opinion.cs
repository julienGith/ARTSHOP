using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Opinion
    {
        public int Prodid { get; set; }
        public int Partenaireid { get; set; }
        public int Btqid { get; set; }
        public short? ANote { get; set; }
        public DateTime? ADate { get; set; }
        public string ATexte { get; set; }
        public string AReponse { get; set; }
        public DateTime? ARepdate { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Partenaire Partenaire { get; set; }
        public virtual Produit Prod { get; set; }
    }
}
