using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Clientcommande
    {
        public Clientcommande()
        {
            Boutiquecommandes = new HashSet<Boutiquecommande>();
            Cltcmddetails = new HashSet<Cltcmddetail>();
            Factures = new HashSet<Facture>();
            Paiements = new HashSet<Paiement>();
        }

        public int Cltcmdid { get; set; }
        public int Partenaireid { get; set; }
        public int Cmdetatid { get; set; }
        public int? Paiementid { get; set; }
        public int? Factureid { get; set; }
        public DateTime? Cltcmddate { get; set; }
        public DateTime? Cltcmddatedebut { get; set; }
        public DateTime? Cltcmddatefin { get; set; }

        public virtual Cmdetat Cmdetat { get; set; }
        public virtual Facture Facture { get; set; }
        public virtual Paiement Paiement { get; set; }
        public virtual Partenaire Partenaire { get; set; }
        public virtual ICollection<Boutiquecommande> Boutiquecommandes { get; set; }
        public virtual ICollection<Cltcmddetail> Cltcmddetails { get; set; }
        public virtual ICollection<Facture> Factures { get; set; }
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
