using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Etatcmd
    {
        public Etatcmd()
        {
            Commandeboutiques = new HashSet<Commandeboutique>();
            Commandeclients = new HashSet<Commandeclient>();
        }

        public int Etatid { get; set; }
        public string Etatcmd1 { get; set; }

        public virtual ICollection<Commandeboutique> Commandeboutiques { get; set; }
        public virtual ICollection<Commandeclient> Commandeclients { get; set; }
    }
}
