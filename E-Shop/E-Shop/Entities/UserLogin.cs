using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Entities
{
    public class UserLogin : IdentityUserLogin<int>
    {
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Logins")]
        public virtual Partenaire Partenaire { get; set; }
    }
}
