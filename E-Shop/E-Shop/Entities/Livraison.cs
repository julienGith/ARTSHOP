using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("LIVRAISON")]
    [Index(nameof(Lvretatid), Name = "CARACTERISER_FK")]
    [Index(nameof(Lvrtypid), Name = "DEFINIR_FK")]
    [Index(nameof(Localisationid), Name = "DESTINER_FK")]
    public partial class Livraison
    {
        public Livraison()
        {
            BcDetails = new HashSet<BcDetail>();
            CcDetails = new HashSet<CcDetail>();
        }

        [Key]
        [Column("LIVRAISONID")]
        public int Livraisonid { get; set; }
        [Column("LVRTYPID")]
        public int Lvrtypid { get; set; }
        [Column("LVRETATID")]
        public int Lvretatid { get; set; }
        [Column("LOCALISATIONID")]
        public int Localisationid { get; set; }
        [Column("SUIVINUM")]
        public string Suivinum { get; set; }
        [Column("SUIVILIEN")]
        public string Suivilien { get; set; }
        [Column("DATEENVOI", TypeName = "datetime")]
        public DateTime? Dateenvoi { get; set; }

        [ForeignKey(nameof(Localisationid))]
        [InverseProperty("Livraisons")]
        public virtual Localisation Localisation { get; set; }
        [ForeignKey(nameof(Lvretatid))]
        [InverseProperty(nameof(Livraisonetat.Livraisons))]
        public virtual Livraisonetat Lvretat { get; set; }
        [ForeignKey(nameof(Lvrtypid))]
        [InverseProperty(nameof(Livraisontype.Livraisons))]
        public virtual Livraisontype Lvrtyp { get; set; }
        [InverseProperty(nameof(BcDetail.Livraison))]
        public virtual ICollection<BcDetail> BcDetails { get; set; }
        [InverseProperty(nameof(CcDetail.Livraison))]
        public virtual ICollection<CcDetail> CcDetails { get; set; }
    }
}
