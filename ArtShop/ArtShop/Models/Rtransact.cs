using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Rtransact
    {
        public int Remboursementid { get; set; }
        public int Transactionid { get; set; }

        public virtual Remboursement Remboursement { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
