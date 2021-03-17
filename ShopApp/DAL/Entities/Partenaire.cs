﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DAL.Entities
{
    [Table("PARTENAIRE")]
    [Index(nameof(Panierid), Name = "DISPOSER2_FK")]
    public partial class Partenaire
    {
        public Partenaire()
        {
            Boutiques = new HashSet<Boutique>();
            Clientcommandes = new HashSet<Clientcommande>();
            Echanges = new HashSet<Echange>();
            Identifications = new HashSet<Identification>();
            Localisations = new HashSet<Localisation>();
            Moyendepaiements = new HashSet<Moyendepaiement>();
            Opinions = new HashSet<Opinion>();
            Paniers = new HashSet<Panier>();
        }

        [Key]
        [Column("PARTENAIREID")]
        public int Partenaireid { get; set; }
        [Column("PANIERID")]
        public int? Panierid { get; set; }
        [Column("ADMIN")]
        public bool? Admin { get; set; }
        [Column("VENDEUR")]
        public bool? Vendeur { get; set; }
        [Column("DATEENR", TypeName = "datetime")]
        public DateTime? Dateenr { get; set; }
        [Column("DATECON", TypeName = "datetime")]
        public DateTime? Datecon { get; set; }
        [Column("USERID")]
        public int Userid { get; set; }

        [ForeignKey(nameof(Panierid))]
        [InverseProperty("Partenaires")]
        public virtual Panier Panier { get; set; }
        [InverseProperty(nameof(Boutique.Partenaire))]
        public virtual ICollection<Boutique> Boutiques { get; set; }
        [InverseProperty(nameof(Clientcommande.Partenaire))]
        public virtual ICollection<Clientcommande> Clientcommandes { get; set; }
        [InverseProperty(nameof(Echange.Partenaire))]
        public virtual ICollection<Echange> Echanges { get; set; }
        [InverseProperty(nameof(Identification.Partenaire))]
        public virtual ICollection<Identification> Identifications { get; set; }
        [InverseProperty(nameof(Localisation.Partenaire))]
        public virtual ICollection<Localisation> Localisations { get; set; }
        [InverseProperty(nameof(Moyendepaiement.Partenaire))]
        public virtual ICollection<Moyendepaiement> Moyendepaiements { get; set; }
        [InverseProperty(nameof(Opinion.Partenaire))]
        public virtual ICollection<Opinion> Opinions { get; set; }
        [InverseProperty("Partenaire")]
        public virtual ICollection<Panier> Paniers { get; set; }
    }
}
