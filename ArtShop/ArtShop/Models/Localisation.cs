using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Localisation
    {
        public Localisation()
        {
            Livraisons = new HashSet<Livraison>();
            Pointrelais = new HashSet<Pointrelai>();
        }

        public int Localisationid { get; set; }
        public int Btqid { get; set; }
        public int Partenaireid { get; set; }
        public string Adresse { get; set; }
        public string Rue { get; set; }
        public string Num { get; set; }
        public string Ville { get; set; }
        public string Codepostal { get; set; }
        public string Pays { get; set; }
        public string PrNom { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Partenaire Partenaire { get; set; }
        public virtual ICollection<Livraison> Livraisons { get; set; }
        public virtual ICollection<Pointrelai> Pointrelais { get; set; }
    }
}
