using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("BC_DETAIL")]
    [Index(nameof(Prodid), Name = "COMPORTER2_FK")]
    [Index(nameof(Livraisonid), Name = "COMPORTER3_FK")]
    [Index(nameof(Btqcmdid), Name = "COMPORTER_FK")]
    public partial class BcDetail
    {
        [Key]
        [Column("BTQCMDID")]
        public int Btqcmdid { get; set; }
        [Key]
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Key]
        [Column("LIVRAISONID")]
        public int Livraisonid { get; set; }
        [Column("B_CMD_QTEPROD")]
        public short? BCmdQteprod { get; set; }

        [ForeignKey(nameof(Btqcmdid))]
        [InverseProperty(nameof(Boutiquecommande.BcDetails))]
        public virtual Boutiquecommande Btqcmd { get; set; }
        [ForeignKey(nameof(Livraisonid))]
        [InverseProperty("BcDetails")]
        public virtual Livraison Livraison { get; set; }
        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.BcDetails))]
        public virtual Produit Prod { get; set; }
    }
}
