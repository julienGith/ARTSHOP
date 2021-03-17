using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("LIVRAISON")]
    [Index(nameof(Lvretatid), Name = "CARACTERISER_FK")]
    [Index(nameof(Lvrtypid), Name = "DEFINIR_FK")]
    [Index(nameof(Localisationid), Name = "DESTINER_FK")]
    public partial class Livraison
    {
        public Livraison()
        {
            Btqcmddetails = new HashSet<Btqcmddetail>();
            Cltcmddetails = new HashSet<Cltcmddetail>();
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
        [StringLength(255)]
        public string Suivinum { get; set; }
        [Column("SUIVILIEN")]
        [StringLength(255)]
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
        [InverseProperty(nameof(Btqcmddetail.Livraison))]
        public virtual ICollection<Btqcmddetail> Btqcmddetails { get; set; }
        [InverseProperty(nameof(Cltcmddetail.Livraison))]
        public virtual ICollection<Cltcmddetail> Cltcmddetails { get; set; }
    }
}
