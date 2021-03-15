using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Produit
    {
        public Produit()
        {
            Btqcmddetails = new HashSet<Btqcmddetail>();
            Cltcmddetails = new HashSet<Cltcmddetail>();
            Echanges = new HashSet<Echange>();
            Media = new HashSet<Medium>();
            Opinions = new HashSet<Opinion>();
            Panierdetails = new HashSet<Panierdetail>();
        }

        public int Prodid { get; set; }
        public int Btqid { get; set; }
        public int Categorieid { get; set; }
        public int Lvrtypid { get; set; }
        public decimal? Prix { get; set; }
        public string PNom { get; set; }
        public string PDescriptionC { get; set; }
        public string PDescriptionL { get; set; }
        public short? Stock { get; set; }
        public short? Disponibilite { get; set; }
        public short? Rabais { get; set; }
        public short? Preparation { get; set; }
        public string PSeo { get; set; }
        public string PMetaKeywords { get; set; }
        public string PMetaTitre { get; set; }
        public bool? Publier { get; set; }

        public virtual Boutique Btq { get; set; }
        public virtual Categorie Categorie { get; set; }
        public virtual Livraisontype Lvrtyp { get; set; }
        public virtual ICollection<Btqcmddetail> Btqcmddetails { get; set; }
        public virtual ICollection<Cltcmddetail> Cltcmddetails { get; set; }
        public virtual ICollection<Echange> Echanges { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
        public virtual ICollection<Panierdetail> Panierdetails { get; set; }
    }
}
