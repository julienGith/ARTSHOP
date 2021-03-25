using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("CC_DETAIL")]
    [Index(nameof(Prodid), Name = "LISTER2_FK")]
    [Index(nameof(Livraisonid), Name = "LISTER3_FK")]
    [Index(nameof(Cltcmdid), Name = "LISTER_FK")]
    public partial class CcDetail
    {
        [Key]
        [Column("CLTCMDID")]
        public int Cltcmdid { get; set; }
        [Key]
        [Column("PRODID")]
        public int Prodid { get; set; }
        [Key]
        [Column("LIVRAISONID")]
        public int Livraisonid { get; set; }
        [Column("C_CMD_QTEPROD")]
        public short? CCmdQteprod { get; set; }

        [ForeignKey(nameof(Cltcmdid))]
        [InverseProperty(nameof(Clientcommande.CcDetails))]
        public virtual Clientcommande Cltcmd { get; set; }
        [ForeignKey(nameof(Livraisonid))]
        [InverseProperty("CcDetails")]
        public virtual Livraison Livraison { get; set; }
        [ForeignKey(nameof(Prodid))]
        [InverseProperty(nameof(Produit.CcDetails))]
        public virtual Produit Prod { get; set; }
    }
}
