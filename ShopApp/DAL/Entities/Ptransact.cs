using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Ptransact
    {
        public int Paiementid { get; set; }
        public int Transactionid { get; set; }

        public virtual Paiement Paiement { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
