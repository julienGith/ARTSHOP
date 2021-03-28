using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Index(nameof(RoleId), Name = "IX_RoleClaims_RoleId")]
    public partial class RoleClaim
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("RoleClaims")]
        public virtual Role Role { get; set; }
    }
}
