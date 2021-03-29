using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Entities
{
    public class RoleClaim : IdentityRoleClaim<int>
    {
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}
