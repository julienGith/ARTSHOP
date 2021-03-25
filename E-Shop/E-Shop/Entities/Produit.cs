using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("PRODUIT")]
    [Index(nameof(Categorieid), Name = "APPARTENIR_FK")]
    [Index(nameof(Lvrtypid), Name = "AVOIR_FK")]
    [Index(nameof(Btqid), Name = "VENDRE_FK")]
    public partial class Produit
    {
        public Produit()
        {
            Avis = new HashSet<Avi>();
            BcDetails = new HashSet<BcDetail>();
            CcDetails = new HashSet<CcDetail>();
            Echanges = new HashSet<Echange>();
            Media = new HashSet<Medium>();
            PDetails = new HashSet<PDetail>();
        }

        [Key]
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Column("CATEGORIEID")]
        public int Categorieid { get; set; }
        [Column("LVRTYPID")]
        public int Lvrtypid { get; set; }
        [Column("PRIX", TypeName = "decimal(9, 2)")]
        public decimal? Prix { get; set; }
        [Column("P_NOM")]
        [StringLength(20)]
        public string PNom { get; set; }
        [Column("P_DESCRIPTION_C")]
        [StringLength(100)]
        public string PDescriptionC { get; set; }
        [Column("P_DESCRIPTION_L")]
        [StringLength(255)]
        public string PDescriptionL { get; set; }
        [Column("STOCK")]
        public short? Stock { get; set; }
        [Column("DISPONIBILITE")]
        public short? Disponibilite { get; set; }
        [Column("RABAIS")]
        public short? Rabais { get; set; }
        [Column("PREPARATION")]
        public short? Preparation { get; set; }
        [Column("P_SEO")]
        [StringLength(100)]
        public string PSeo { get; set; }
        [Column("P_META_KEYWORDS")]
        [StringLength(100)]
        public string PMetaKeywords { get; set; }
        [Column("P_META_TITRE")]
        [StringLength(100)]
        public string PMetaTitre { get; set; }
        [Column("PUBLIER")]
        public bool? Publier { get; set; }

        [ForeignKey(nameof(Btqid))]
        [InverseProperty(nameof(Boutique.Produits))]
        public virtual Boutique Btq { get; set; }
        [ForeignKey(nameof(Categorieid))]
        [InverseProperty("Produits")]
        public virtual Categorie Categorie { get; set; }
        [ForeignKey(nameof(Lvrtypid))]
        [InverseProperty(nameof(Livraisontype.Produits))]
        public virtual Livraisontype Lvrtyp { get; set; }
        [InverseProperty(nameof(Avi.Prod))]
        public virtual ICollection<Avi> Avis { get; set; }
        [InverseProperty(nameof(BcDetail.Prod))]
        public virtual ICollection<BcDetail> BcDetails { get; set; }
        [InverseProperty(nameof(CcDetail.Prod))]
        public virtual ICollection<CcDetail> CcDetails { get; set; }
        [InverseProperty(nameof(Echange.Prod))]
        public virtual ICollection<Echange> Echanges { get; set; }
        [InverseProperty(nameof(Medium.Prod))]
        public virtual ICollection<Medium> Media { get; set; }
        [InverseProperty(nameof(PDetail.Prod))]
        public virtual ICollection<PDetail> PDetails { get; set; }
    }
}
