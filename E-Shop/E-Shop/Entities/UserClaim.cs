using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Entities
{
    public class UserClaim : IdentityUserClaim<int>
    {
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Claims")]
        public virtual Partenaire Partenaire { get; set; }
    }
}
