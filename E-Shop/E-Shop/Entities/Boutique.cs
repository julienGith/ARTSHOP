using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("BOUTIQUE")]
    [Index(nameof(Politiqueid), Name = "APPLIQUER_FK")]
    [Index(nameof(Id), Name = "CREER_FK")]
    public partial class Boutique
    {
        public Boutique()
        {
            Avis = new HashSet<Avi>();
            Boutiquecommandes = new HashSet<Boutiquecommande>();
            Echanges = new HashSet<Echange>();
            Localisations = new HashSet<Localisation>();
            Media = new HashSet<Medium>();
            Produits = new HashSet<Produit>();
            RelaisLocBs = new HashSet<RelaisLocB>();
            Livraisontypes = new HashSet<Livraisontype>();
        }

        [Key]
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        [Column("POLITIQUEID")]
        public int Politiqueid { get; set; }
        [Column("B_DESCRIPTION_C")]
        public string BDescriptionC { get; set; }
        [Column("B_DESCRIPTION_L")]
        public string BDescriptionL { get; set; }
        [Column("RAISONSOCIALE")]
        [StringLength(255)]
        public string Raisonsociale { get; set; }
        [Column("SIRET")]
        [StringLength(14)]
        public string Siret { get; set; }
        [Column("SIREN")]
        [StringLength(9)]
        public string Siren { get; set; }
        [Column("BTQTEL")]
        [StringLength(15)]
        public string Btqtel { get; set; }
        [Column("CODENAF")]
        [StringLength(6)]
        public string Codenaf { get; set; }
        [Column("CODEBANQUE")]
        [StringLength(5)]
        public string Codebanque { get; set; }
        [Column("CODEGUICHET")]
        [StringLength(5)]
        public string Codeguichet { get; set; }
        [Column("NUMCOMPTE")]
        [StringLength(11)]
        public string Numcompte { get; set; }
        [Column("CLERIB")]
        [StringLength(2)]
        public string Clerib { get; set; }
        [Column("DOMICILIATION")]
        public string Domiciliation { get; set; }
        [Column("IBAN")]
        [StringLength(27)]
        public string Iban { get; set; }
        [Column("BIC")]
        [StringLength(11)]
        public string Bic { get; set; }
        [Column("TITULAIRE")]
        [StringLength(140)]
        public string Titulaire { get; set; }
        [Column("BTQTMAIL")]
        [StringLength(255)]
        public string Btqtmail { get; set; }
        [Column("BTQMESSAGE")]
        [StringLength(255)]
        public string Btqmessage { get; set; }
        [Column("BTQNOM")]
        [StringLength(255)]
        public string BtqNom { get; set; }
        [Column("CA")]
        public int? Ca { get; set; }
        [Column("NBSALARIE")]
        public int? Nbsalarie { get; set; }
        [Column("SITEWEB")]
        [StringLength(100)]
        public string Siteweb { get; set; }
        [Column("STATUTJURIDIQUE")]
        [StringLength(25)]
        public string Statutjuridique { get; set; }
        [Column("BTQSEO")]
        [StringLength(450)]
        public string Btqseo { get; set; }
        [Column("DATECREATION")]
        [StringLength(50)]
        public string DateCreation { get; set; }
        [Column("STRIPEACCT")]
        [StringLength(255)]
        public string StripeAcct { get; set; }


        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Partenaire.Boutiques))]
        public virtual Partenaire IdNavigation { get; set; }
        [ForeignKey(nameof(Politiqueid))]
        [InverseProperty("Boutiques")]
        public virtual Politique Politique { get; set; }
        [InverseProperty(nameof(Avi.Btq))]
        public virtual ICollection<Avi> Avis { get; set; }
        [InverseProperty(nameof(Boutiquecommande.Btq))]
        public virtual ICollection<Boutiquecommande> Boutiquecommandes { get; set; }
        [InverseProperty(nameof(Echange.Btq))]
        public virtual ICollection<Echange> Echanges { get; set; }
        [InverseProperty(nameof(Localisation.Btq))]
        public virtual ICollection<Localisation> Localisations { get; set; }
        [InverseProperty(nameof(Medium.Btq))]
        public virtual ICollection<Medium> Media { get; set; }
        [InverseProperty(nameof(Produit.Btq))]
        public virtual ICollection<Produit> Produits { get; set; }
        [InverseProperty(nameof(RelaisLocB.Btq))]
        public virtual ICollection<RelaisLocB> RelaisLocBs { get; set; }

        [InverseProperty(nameof(Livraisontype.Btq))]
        public virtual ICollection<Livraisontype> Livraisontypes { get; set; }
    }
}
