using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShopWebApp.Entities
{
    [Table("LOCALISATION")]
    [Index(nameof(Partenaireid), Name = "POSSEDER_FK")]
    [Index(nameof(Btqid), Name = "SITUER_FK")]
    public partial class Localisation
    {
        public Localisation()
        {
            Btqpostes = new HashSet<Btqposte>();
            Livraisons = new HashSet<Livraison>();
        }

        [Key]
        [Column("LOCALISATIONID")]
        public int Localisationid { get; set; }
        [Column("BTQID")]
        public int Btqid { get; set; }
        [Column("PARTENAIREID")]
        public int Partenaireid { get; set; }
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
        [ForeignKey(nameof(Partenaireid))]
        [InverseProperty("Localisations")]
        public virtual Partenaire Partenaire { get; set; }
        [InverseProperty(nameof(Btqposte.Localisation))]
        public virtual ICollection<Btqposte> Btqpostes { get; set; }
        [InverseProperty(nameof(Livraison.Localisation))]
        public virtual ICollection<Livraison> Livraisons { get; set; }
    }
}
