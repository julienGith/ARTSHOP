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
    public class UserLogin : IdentityUserLogin<int>
    {public UserLogin()
        {
            
        }
        [Key]
        public int UserLoginID { get; set; }
        //[Column("PARTENAIREID")]
        public int Partenaireid { get; set; }
        public virtual Partenaire Partenaire { get; set; }
    }
}
