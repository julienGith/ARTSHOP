using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Remplacement
    {
        public Remplacement()
        {
            Litiges = new HashSet<Litige>();
        }

        public int Retourid { get; set; }
        public int Litigeid { get; set; }
        public string RSuivinum { get; set; }
        public string RSuivilien { get; set; }

        public virtual Litige Litige { get; set; }
        public virtual ICollection<Litige> Litiges { get; set; }
    }
}
