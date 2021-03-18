using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserClaim :IdentityUserClaim<int>
    {
        [Key]
        public int UserClaimID { get; set; }
        //[Column("PARTENAIREID")]
        public int Partenaireid { get; set; }
        //[ForeignKey(nameof(Partenaireid))]
        //[InverseProperty("Claims")]
        public virtual Partenaire Partenaire { get; set; }
    }
}
