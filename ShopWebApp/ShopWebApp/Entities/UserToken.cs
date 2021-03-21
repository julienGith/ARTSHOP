using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApp.Entities
{
    public class UserToken : IdentityUserToken<int>
    {
        [Key]
        public int UserTokenID { get; set; }
        public virtual Partenaire Partenaire { get; set; }

        //[Column("PARTENAIREID")]
        public int Partenaireid { get; set; }
    }
}
