using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Identification
    {
        public int Identid { get; set; }
        public int Partenaireid { get; set; }
        public int Civid { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        public virtual Civilite Civ { get; set; }
        public virtual Partenaire Partenaire { get; set; }
    }
}
