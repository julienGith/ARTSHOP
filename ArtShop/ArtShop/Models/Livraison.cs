using System;
using System.Collections.Generic;

#nullable disable

namespace ArtShop.Models
{
    public partial class Livraison
    {
        public Livraison()
        {
            Cmdbtqdetails = new HashSet<Cmdbtqdetail>();
            Cmdcltdetails = new HashSet<Cmdcltdetail>();
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
        public virtual ICollection<Cmdbtqdetail> Cmdbtqdetails { get; set; }
        public virtual ICollection<Cmdcltdetail> Cmdcltdetails { get; set; }
    }
}
