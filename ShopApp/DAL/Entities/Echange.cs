using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Echange
    {
        public int Partenaireid { get; set; }
        public int Prodid { get; set; }
        public int Btqid { get; set; }
        public string EQuest { get; set; }
        public string ERep { get; set; }
        public DateTime? EQuestdate { get; set; }
        public DateTime? ERepdate { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Partenaire Partenaire { get; set; }
        public virtual Produit Prod { get; set; }
    }
}
