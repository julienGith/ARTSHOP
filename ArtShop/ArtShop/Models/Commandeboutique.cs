using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Commandeboutique
    {
        public Commandeboutique()
        {
            Cmdbtqdetails = new HashSet<Cmdbtqdetail>();
            Litiges = new HashSet<Litige>();
        }

        public int Cmdbtqid { get; set; }
        public int Etatid { get; set; }
        public int? Litigeid { get; set; }
        public int? Cmdcltid { get; set; }
        public int Btqid { get; set; }
        public DateTime? Datecrea { get; set; }
        public DateTime? Datedebut { get; set; }
        public DateTime? Datefin { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Commandeclient Cmdclt { get; set; }
        public virtual Etatcmd Etat { get; set; }
        public virtual Litige Litige { get; set; }
        public virtual ICollection<Cmdbtqdetail> Cmdbtqdetails { get; set; }
        public virtual ICollection<Litige> Litiges { get; set; }
    }
}
