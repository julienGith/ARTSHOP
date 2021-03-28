using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("PARTENAIRE")]
    [Index(nameof(Panierid), Name = "DISPOSER2_FK")]
    public partial class Partenaire
    {
        public Partenaire()
        {
            Avis = new HashSet<Avi>();
            Boutiques = new HashSet<Boutique>();
            Clientcommandes = new HashSet<Clientcommande>();
            Echanges = new HashSet<Echange>();
            Identifications = new HashSet<Identification>();
            Localisations = new HashSet<Localisation>();
            Moyendepaiements = new HashSet<Moyendepaiement>();
            Paniers = new HashSet<Panier>();
            UserClaims = new HashSet<UserClaim>();
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        public int Id { get; set; }
        [Column("PANIERID")]
        public int? Panierid { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        [ForeignKey(nameof(Panierid))]
        [InverseProperty("Partenaires")]
        public virtual Panier Panier { get; set; }
        [InverseProperty(nameof(Avi.IdNavigation))]
        public virtual ICollection<Avi> Avis { get; set; }
        [InverseProperty(nameof(Boutique.IdNavigation))]
        public virtual ICollection<Boutique> Boutiques { get; set; }
        [InverseProperty(nameof(Clientcommande.IdNavigation))]
        public virtual ICollection<Clientcommande> Clientcommandes { get; set; }
        [InverseProperty(nameof(Echange.IdNavigation))]
        public virtual ICollection<Echange> Echanges { get; set; }
        [InverseProperty(nameof(Identification.IdNavigation))]
        public virtual ICollection<Identification> Identifications { get; set; }
        [InverseProperty(nameof(Localisation.IdNavigation))]
        public virtual ICollection<Localisation> Localisations { get; set; }
        [InverseProperty(nameof(Moyendepaiement.IdNavigation))]
        public virtual ICollection<Moyendepaiement> Moyendepaiements { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual ICollection<Panier> Paniers { get; set; }
        [InverseProperty(nameof(UserClaim.User))]
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        [InverseProperty(nameof(UserLogin.User))]
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        [InverseProperty(nameof(UserRole.User))]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
