using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("LOCALISATION")]
    [Index(nameof(Id), Name = "POSSEDER_FK")]
    [Index(nameof(Btqid), Name = "SITUER_FK")]
    public partial class Localisation
    {
        public Localisation()
        {
            Livraisons = new HashSet<Livraison>();
            RelaisLocBs = new HashSet<RelaisLocB>();
        }

        [Key]
        [Column("LOCALISATIONID")]
        public int Localisationid { get; set; }
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        [Column("ADRESSE")]
        [StringLength(255)]
        public string Adresse { get; set; }
        [Column("RUE")]
        [StringLength(255)]
        public string Rue { get; set; }
        [Column("NUM")]
        [StringLength(255)]
        public string Num { get; set; }
        [Column("VILLE")]
        [StringLength(255)]
        public string Ville { get; set; }
        [Column("CODEPOSTAL")]
        [StringLength(255)]
        public string Codepostal { get; set; }
        [Column("PAYS")]
        [StringLength(255)]
        public string Pays { get; set; }
        [Column("PR_NOM")]
        [StringLength(255)]
        public string PrNom { get; set; }

        [ForeignKey(nameof(Btqid))]
        [InverseProperty(nameof(Boutique.Localisations))]
        public virtual Boutique Btq { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Partenaire.Localisations))]
        public virtual Partenaire IdNavigation { get; set; }
        [InverseProperty(nameof(Livraison.Localisation))]
        public virtual ICollection<Livraison> Livraisons { get; set; }
        [InverseProperty(nameof(RelaisLocB.Localisation))]
        public virtual ICollection<RelaisLocB> RelaisLocBs { get; set; }
    }
}
