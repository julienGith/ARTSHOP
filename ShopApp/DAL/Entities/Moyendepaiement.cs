using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Moyendepaiement
    {
        public Moyendepaiement()
        {
            Paiements = new HashSet<Paiement>();
        }

        public int Mdpid { get; set; }
        public int Partenaireid { get; set; }
        public string CbNum { get; set; }
        public string Cvc { get; set; }
        public DateTime? Dateexp { get; set; }
        public string CbTitulaire { get; set; }
        public string CbType { get; set; }

        public virtual Partenaire Partenaire { get; set; }
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
