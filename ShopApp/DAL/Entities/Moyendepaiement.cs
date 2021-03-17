using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("MOYENDEPAIEMENT")]
    [Index(nameof(Partenaireid), Name = "UTILISER_FK")]
    public partial class Moyendepaiement
    {
        public Moyendepaiement()
        {
            Paiements = new HashSet<Paiement>();
        }

        [Key]
        [Column("MDPID")]
        public int Mdpid { get; set; }
        [Column("PARTENAIREID")]
        public int Partenaireid { get; set; }
        [Column("CB_NUM")]
        [StringLength(16)]
        public string CbNum { get; set; }
        [Column("CVC")]
        [StringLength(4)]
        public string Cvc { get; set; }
        [Column("DATEEXP", TypeName = "datetime")]
        public DateTime? Dateexp { get; set; }
        [Column("CB_TITULAIRE")]
        [StringLength(140)]
        public string CbTitulaire { get; set; }
        [Column("CB_TYPE")]
        [StringLength(30)]
        public string CbType { get; set; }

        [ForeignKey(nameof(Partenaireid))]
        [InverseProperty("Moyendepaiements")]
        public virtual Partenaire Partenaire { get; set; }
        [InverseProperty(nameof(Paiement.Mdp))]
        public virtual ICollection<Paiement> Paiements { get; set; }
    }
}
