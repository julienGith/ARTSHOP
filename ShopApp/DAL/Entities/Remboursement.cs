using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Remboursement
    {
        public Remboursement()
        {
            Litiges = new HashSet<Litige>();
            Rtransacts = new HashSet<Rtransact>();
        }

        public int Remboursementid { get; set; }
        public int Litigeid { get; set; }
        public decimal? RMontant { get; set; }

        public virtual Litige Litige { get; set; }
        public virtual ICollection<Litige> Litiges { get; set; }
        public virtual ICollection<Rtransact> Rtransacts { get; set; }
    }
}
