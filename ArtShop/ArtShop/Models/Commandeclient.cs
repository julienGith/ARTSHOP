using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Commandeclient
    {
        public Commandeclient()
        {
            Cmdcltdetails = new HashSet<Cmdcltdetail>();
            Commandeboutiques = new HashSet<Commandeboutique>();
            Factures = new HashSet<Facture>();
            Paiements = new HashSet<Paiement>();
        }

        public int Cmdcltid { get; set; }
        public int Partenaireid { get; set; }
        public int Etatid { get; set; }
        public int? Paiementid { get; set; }
        public int? Factureid { get; set; }
        public DateTime? Cmdcltdate { get; set; }
        public DateTime? Cmdcltdatedebut { get; set; }
        public DateTime? Cmdcltdatefin { get; set; }

        public virtual Etatcmd Etat { get; set; }
        public virtual Facture Facture { get; set; }
        public virtual Paiement Paiement { get; set; }
        public virtual Partenaire Partenaire { get; set; }
        public virtual ICollection<Cmdcltdetail> Cmdcltdetails { get; set; }
        public virtual ICollection<Commandeboutique> Commandeboutiques { get; set; }
        public virtual ICollection<Facture> Factures { get; set; }
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
