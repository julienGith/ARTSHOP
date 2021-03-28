using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    public partial class Role
    {
        public Role()
        {
            RoleClaims = new HashSet<RoleClaim>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        [InverseProperty(nameof(RoleClaim.Role))]
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
        [InverseProperty(nameof(UserRole.Role))]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
