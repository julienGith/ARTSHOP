using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class ProduitViewModel
    {
        public int Prodid { get; set; }
        public int Btqid { get; set; }
        public int Categorieid { get; set; }
        public int Lvrtypid { get; set; }
        public decimal? Prix { get; set; }
        public string PNom { get; set; }
        public string PDescriptionC { get; set; }
        public string PDescriptionL { get; set; }
        public short? Stock { get; set; }
        public short? Disponibilite { get; set; }
        public short? Rabais { get; set; }
        public short? Preparation { get; set; }
        public string PSeo { get; set; }
        public string PMetaKeywords { get; set; }
        public string PMetaTitre { get; set; }
        public bool? Publier { get; set; }
    }
}
