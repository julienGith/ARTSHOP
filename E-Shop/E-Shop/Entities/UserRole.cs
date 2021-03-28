using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Index(nameof(RoleId), Name = "IX_UserRoles_RoleId")]
    public partial class UserRole
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("UserRoles")]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Partenaire.UserRoles))]
        public virtual Partenaire User { get; set; }
    }
}
