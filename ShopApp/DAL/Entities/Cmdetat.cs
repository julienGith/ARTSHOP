using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Cmdetat
    {
        public Cmdetat()
        {
            Boutiquecommandes = new HashSet<Boutiquecommande>();
            Clientcommandes = new HashSet<Clientcommande>();
        }

        public int Cmdetatid { get; set; }
        public string Cmdetat1 { get; set; }

        public virtual ICollection<Boutiquecommande> Boutiquecommandes { get; set; }
        public virtual ICollection<Clientcommande> Clientcommandes { get; set; }
    }
}
