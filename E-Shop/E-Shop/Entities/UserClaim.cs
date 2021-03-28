using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Index(nameof(UserId), Name = "IX_UserClaims_UserId")]
    public partial class UserClaim
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Partenaire.UserClaims))]
        public virtual Partenaire User { get; set; }
    }
}
