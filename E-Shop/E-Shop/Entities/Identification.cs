﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace E_Shop.Entities
{
    [Table("IDENTIFICATION")]
    [Index(nameof(Civid), Name = "ETRE_FK")]
    [Index(nameof(Id), Name = "IDENTIFIER_FK")]
    public partial class Identification
    {
        [Key]
        [Column("IDENTID")]
        public int Identid { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        [Column("CIVID")]
        public int Civid { get; set; }
        [Column("NOM")]
        [StringLength(70)]
        public string Nom { get; set; }
        [Column("PRENOM")]
        [StringLength(70)]
        public string Prenom { get; set; }
        [Column("EMAIL")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("TEL")]
        [StringLength(15)]
        public string Tel { get; set; }

        [ForeignKey(nameof(Civid))]
        [InverseProperty(nameof(Civilite.Identifications))]
        public virtual Civilite Civ { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Partenaire.Identifications))]
        public virtual Partenaire IdNavigation { get; set; }
    }
}
