using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Livraison
    {
        public Livraison()
        {
            Btqcmddetails = new HashSet<Btqcmddetail>();
            Cltcmddetails = new HashSet<Cltcmddetail>();
        }

        public int Livraisonid { get; set; }
        public int Lvrtypid { get; set; }
        public int Lvretatid { get; set; }
        public int Localisationid { get; set; }
        public string Suivinum { get; set; }
        public string Suivilien { get; set; }
        public DateTime? Dateenvoi { get; set; }

        public virtual Localisation Localisation { get; set; }
        public virtual Livraisonetat Lvretat { get; set; }
        public virtual Livraisontype Lvrtyp { get; set; }
        public virtual ICollection<Btqcmddetail> Btqcmddetails { get; set; }
        public virtual ICollection<Cltcmddetail> Cltcmddetails { get; set; }
    }
}
