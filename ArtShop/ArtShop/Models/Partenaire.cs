using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Partenaire
    {
        public Partenaire()
        {
            Avis = new HashSet<Avi>();
            Boutiques = new HashSet<Boutique>();
            Commandeclients = new HashSet<Commandeclient>();
            Echanges = new HashSet<Echange>();
            Identifications = new HashSet<Identification>();
            Localisations = new HashSet<Localisation>();
            Moyendepaiements = new HashSet<Moyendepaiement>();
            Paniers = new HashSet<Panier>();
        }

        public int Partenaireid { get; set; }
        public int? Panierid { get; set; }
        public bool? Admin { get; set; }
        public bool? Vendeur { get; set; }
        public DateTime? Dateenr { get; set; }
        public DateTime? Datecon { get; set; }
        public int Userid { get; set; }

        public virtual AspNetUser NetUser { get; set; }
        public virtual Panier Panier { get; set; }
        public virtual ICollection<Avi> Avis { get; set; }
        public virtual ICollection<Boutique> Boutiques { get; set; }
        public virtual ICollection<Commandeclient> Commandeclients { get; set; }
        public virtual ICollection<Echange> Echanges { get; set; }
        public virtual ICollection<Identification> Identifications { get; set; }
        public virtual ICollection<Localisation> Localisations { get; set; }
        public virtual ICollection<Moyendepaiement> Moyendepaiements { get; set; }
        public virtual ICollection<Panier> Paniers { get; set; }
    }
}
