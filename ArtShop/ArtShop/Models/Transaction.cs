using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            Ptransacts = new HashSet<Ptransact>();
            Rtransacts = new HashSet<Rtransact>();
        }

        public int Transactionid { get; set; }
        public string Code { get; set; }
        public short? Type { get; set; }
        public short? Mode { get; set; }
        public short? Transactstatut { get; set; }
        public DateTime? Transactcrea { get; set; }
        public DateTime? Transactmodif { get; set; }
        public string Transactcontenu { get; set; }

        public virtual ICollection<Ptransact> Ptransacts { get; set; }
        public virtual ICollection<Rtransact> Rtransacts { get; set; }
    }
}
