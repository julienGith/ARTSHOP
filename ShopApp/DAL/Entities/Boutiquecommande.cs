using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Boutiquecommande
    {
        public Boutiquecommande()
        {
            Btqcmddetails = new HashSet<Btqcmddetail>();
            Litiges = new HashSet<Litige>();
        }

        public int Btqcmdid { get; set; }
        public int Cmdetatid { get; set; }
        public int? Litigeid { get; set; }
        public int? Cltcmdid { get; set; }
        public int Btqid { get; set; }
        public DateTime? Btqcmddatecrea { get; set; }
        public DateTime? Btqcmddatedebut { get; set; }
        public DateTime? Btqcmddatefin { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Clientcommande Cltcmd { get; set; }
        public virtual Cmdetat Cmdetat { get; set; }
        public virtual Litige Litige { get; set; }
        public virtual ICollection<Btqcmddetail> Btqcmddetails { get; set; }
        public virtual ICollection<Litige> Litiges { get; set; }
    }
}
