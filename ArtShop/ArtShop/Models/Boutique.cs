using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Boutique
    {
        public Boutique()
        {
            Avis = new HashSet<Avi>();
            Commandeboutiques = new HashSet<Commandeboutique>();
            Echanges = new HashSet<Echange>();
            Localisations = new HashSet<Localisation>();
            Media = new HashSet<Medium>();
            Pointrelais = new HashSet<Pointrelai>();
            Produits = new HashSet<Produit>();
        }

        public int Btqid { get; set; }
        public int Partenaireid { get; set; }
        public int Politiqueid { get; set; }
        public string BDescriptionC { get; set; }
        public string BDescriptionL { get; set; }
        public string Raisonsociale { get; set; }
        public string Siret { get; set; }
        public string Siren { get; set; }
        public string Btqtel { get; set; }
        public string Codenaf { get; set; }
        public string Codebanque { get; set; }
        public string Codeguichet { get; set; }
        public string Numcompte { get; set; }
        public string Clerib { get; set; }
        public string Domiciliation { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string Titulaire { get; set; }
        public string Btqtmail { get; set; }
        public string Btqmessage { get; set; }
        public int? Ca { get; set; }
        public int? Nbsalarie { get; set; }
        public string Siteweb { get; set; }
        public string Statutjuridique { get; set; }
        public string Btqseo { get; set; }

        public virtual Partenaire Partenaire { get; set; }
        public virtual Politique Politique { get; set; }
        public virtual ICollection<Avi> Avis { get; set; }
        public virtual ICollection<Commandeboutique> Commandeboutiques { get; set; }
        public virtual ICollection<Echange> Echanges { get; set; }
        public virtual ICollection<Localisation> Localisations { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Pointrelai> Pointrelais { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
