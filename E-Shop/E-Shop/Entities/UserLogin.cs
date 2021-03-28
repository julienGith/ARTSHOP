using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Index(nameof(UserId), Name = "IX_UserLogins_UserId")]
    public partial class UserLogin
    {
        [Key]
        public string LoginProvider { get; set; }
        [Key]
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Partenaire.UserLogins))]
        public virtual Partenaire User { get; set; }
    }
}
