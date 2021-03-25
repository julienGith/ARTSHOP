using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("PARTENAIRE")]
    [Index(nameof(Panierid), Name = "DISPOSER2_FK")]
    public partial class Partenaire : IdentityUser<int>
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

            Claims = new HashSet<UserClaim>();
            Logins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
        }

        //[Key]
        //[Column("ID")]
        //new public int Id { get; set; }
        [Column("PANIERID")]
        public int? Panierid { get; set; }

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

        public virtual ICollection<UserClaim> Claims { get; private set; }
        public virtual ICollection<UserLogin> Logins { get; private set; }
        public virtual ICollection<UserRole> UserRoles { get; private set; }
    }
}
