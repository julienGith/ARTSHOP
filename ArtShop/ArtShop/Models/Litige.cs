using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Litige
    {
        public Litige()
        {
            Commandeboutiques = new HashSet<Commandeboutique>();
            Media = new HashSet<Medium>();
            Remboursements = new HashSet<Remboursement>();
            Remplacements = new HashSet<Remplacement>();
        }

        public int Litigeid { get; set; }
        public int? Remboursementid { get; set; }
        public int? Retourid { get; set; }
        public int Cmdbtqid { get; set; }
        public string Ltgmsg { get; set; }

        public virtual Commandeboutique Cmdbtq { get; set; }
        public virtual Remboursement Remboursement { get; set; }
        public virtual Remplacement Retour { get; set; }
        public virtual ICollection<Commandeboutique> Commandeboutiques { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Remboursement> Remboursements { get; set; }
        public virtual ICollection<Remplacement> Remplacements { get; set; }
    }
}
